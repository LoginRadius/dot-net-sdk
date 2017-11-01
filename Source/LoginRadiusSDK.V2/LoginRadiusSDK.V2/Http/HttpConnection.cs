using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using LoginRadiusSDK.V2.Exception;

namespace LoginRadiusSDK.V2.Http
{
    /// <summary>
    /// Stores details related to an HTTP request.
    /// </summary>
    public class RequestDetails
    {
        /// <summary>
        /// Gets or sets the URL for the request.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the HTTP method verb used for the request.
        /// </summary>
        public string Method { get; set; }

        /// <summary>
        /// Gets or sets the headers used in the request.
        /// </summary>
        public WebHeaderCollection Headers { get; set; }

        /// <summary>
        /// Gets or sets the request body.
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Gets or sets the number of retry attempts for sending an HTTP request.
        /// </summary>
        public int RetryAttempts { get; set; }

        /// <summary>
        /// Resets the state of this object and clears its properties.
        /// </summary>
        public void Reset()
        {
            Url = string.Empty;
            Headers = null;
            Body = string.Empty;
            RetryAttempts = 0;
        }
    }

    /// <summary>
    /// Stores details related to an HTTP response.
    /// </summary>
    public class ResponseDetails
    {
        /// <summary>
        /// Gets or sets the headers used in the response.
        /// </summary>
        public WebHeaderCollection Headers { get; set; }

        /// <summary>
        /// Gets or sets the response body.
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Gets or sets the response HTTP status code.
        /// </summary>
        public HttpStatusCode? StatusCode { get; set; }

        /// <summary>
        /// Gets or sets an exception related to the response.
        /// </summary>
        public ConnectionException Exception { get; set; }

        /// <summary>
        /// Resets the state of this object and clears its properties.
        /// </summary>
        public void Reset()
        {
            Headers = null;
            Body = string.Empty;
            StatusCode = null;
            Exception = null;
        }
    }

    /// <summary>
    /// Helper class for sending HTTP requests.
    /// </summary>
    internal class HttpConnection
    {
        private readonly Dictionary<string, string> _config;

        /// <summary>
        /// Gets the HTTP request details.
        /// </summary>
        public RequestDetails RequestDetails { get; private set; }

        /// <summary>
        /// Gets the HTTP response details.
        /// </summary>
        public ResponseDetails ResponseDetails { get; private set; }

        /// <summary>
        /// Initializes a new instance of <seealso cref="HttpConnection"/> using the given _config.
        /// </summary>
        /// <param name="config">The _config to use when making HTTP requests.</param>
        public HttpConnection(Dictionary<string, string> config)
        {
            _config = config;
            RequestDetails = new RequestDetails();
            ResponseDetails = new ResponseDetails();
        }

        /// <summary>
        /// Copying existing HttpWebRequest parameters to newly created HttpWebRequest, can't reuse the same HttpWebRequest for retries.
        /// </summary>
        /// <param name="httpRequest"></param>
        /// <param name="config"></param>
        /// <param name="url"></param>
        /// <returns>HttpWebRequest</returns>
        private HttpWebRequest CopyRequest(HttpWebRequest httpRequest, Dictionary<string, string> config, string url)
        {
            ConnectionManager connMngr = ConnectionManager.Instance;

            HttpWebRequest newHttpRequest = ConnectionManager.GetConnection(config, url);
            newHttpRequest.Method = httpRequest.Method;
            newHttpRequest.Accept = httpRequest.Accept;
            newHttpRequest.ContentType = httpRequest.ContentType;
            if (httpRequest.ContentLength > 0)
            {
                newHttpRequest.ContentLength = httpRequest.ContentLength;
            }
            newHttpRequest.UserAgent = httpRequest.UserAgent;
            newHttpRequest.ClientCertificates = httpRequest.ClientCertificates;
            newHttpRequest = CopyHttpWebRequestHeaders(httpRequest, newHttpRequest);
            return newHttpRequest;
        }

        /// <summary>
        /// Copying existing HttpWebRequest headers into newly created HttpWebRequest
        /// </summary>
        /// <param name="httpRequest"></param>
        /// <param name="newHttpRequest"></param>
        /// <returns>HttpWebRequest</returns>
        private HttpWebRequest CopyHttpWebRequestHeaders(HttpWebRequest httpRequest, HttpWebRequest newHttpRequest)
        {
            string[] allKeys = httpRequest.Headers.AllKeys;
            foreach (string key in allKeys)
            {
                switch (key.ToLower(CultureInfo.InvariantCulture))
                {
                    case "accept":
                    case "connection":
                    case "content-length":
                    case "content-type":
                    case "date":
                    case "expect":
                    case "host":
                    case "if-modified-since":
                    case "range":
                    case "referer":
                    case "transfer-encoding":
                    case "user-agent":
                    case "proxy-connection":
                        break;
                    default:
                        newHttpRequest.Headers[key] = httpRequest.Headers[key];
                        break;
                }
            }
            return newHttpRequest;
        }

        /// <summary>
        /// Executing API calls
        /// </summary>
        /// <param name="payLoad"></param>
        /// <param name="httpRequest"></param>
        /// <param name="contentLength"></param>
        /// <returns>A string containing the response from the remote host.</returns>
        public string Execute(string payLoad, HttpWebRequest httpRequest, int contentLength)
        {
            int retriesInt;
            int retriesConfigured = _config.ContainsKey(BaseConstants.HttpConnectionRetryConfig) 
                && int.TryParse(_config[BaseConstants.HttpConnectionRetryConfig], out retriesInt) 
                ? retriesInt
                : 0;
            int retries = 0;

            // Reset the request & response details
            RequestDetails.Reset();
            ResponseDetails.Reset();

            // Store the request details

            RequestDetails.Body = payLoad;
            RequestDetails.Headers = httpRequest.Headers;
            RequestDetails.Url = httpRequest.RequestUri.AbsoluteUri;
            RequestDetails.Method = httpRequest.Method;
            if (contentLength == 0)
                httpRequest.ContentLength = contentLength;
            try
            {
                do
                {
                    if (retries > 0)
                    {
                        httpRequest = CopyRequest(httpRequest, _config, httpRequest.RequestUri.ToString());
                        RequestDetails.RetryAttempts++;
                    }
                    try
                    {
                        switch (httpRequest.Method)
                        {
                            case "POST":
                            case "PUT":
                            case "Delete":
                                if (!string.IsNullOrEmpty(payLoad))
                                {
                                    using (StreamWriter writerStream = new StreamWriter(httpRequest.GetRequestStream()))
                                    {
                                        writerStream.Write(payLoad);
                                        writerStream.Flush();
                                        writerStream.Close();
                                    }
                                }
                                break;
                        }

                        using (WebResponse responseWeb = httpRequest.GetResponse())
                        {
                            // Store the response information
                            ResponseDetails.Headers = responseWeb.Headers;
                            var httpWebResponse = responseWeb as HttpWebResponse;
                            if (httpWebResponse != null)
                            {
                                ResponseDetails.StatusCode = httpWebResponse.StatusCode;
                            }

                            using (StreamReader readerStream = new StreamReader(responseWeb.GetResponseStream()))
                            {
                                ResponseDetails.Body = readerStream.ReadToEnd().Trim();
                                return ResponseDetails.Body;
                            }
                        }
                    }
                    catch (WebException ex)
                    {
                        // If provided, get and log the response from the remote host.
                        var response = string.Empty;
                        if (ex.Response != null)
                        {
                            using (var readerStream = new StreamReader(ex.Response.GetResponseStream()))
                            {
                                response = readerStream.ReadToEnd().Trim();
                            }
                        }

                        ConnectionException rethrowEx;

                        // Protocol errors indicate the remote host received the
                        // request, but responded with an error (usually a 4xx or
                        // 5xx error).
                        if (ex.Status == WebExceptionStatus.ProtocolError)
                        {
                            var httpWebResponse = (HttpWebResponse) ex.Response;

                            // If the HTTP status code is flagged as one where we
                            // should continue retrying, then ignore the exception
                            // and continue with the retry attempt.
                            if (httpWebResponse != null &&
                                (httpWebResponse.StatusCode == HttpStatusCode.GatewayTimeout ||
                                 httpWebResponse.StatusCode == HttpStatusCode.RequestTimeout ||
                                 httpWebResponse.StatusCode == HttpStatusCode.BadGateway))
                            {
                                continue;
                            }
                            if (httpWebResponse != null && httpWebResponse.StatusCode.Equals(HttpStatusCode.Forbidden))
                            {
                                throw new LoginRadiusException(ex.Message, ex, response);
                            }
                            rethrowEx = new HttpException(ex.Message, response, httpWebResponse.StatusCode, ex.Status,
                                httpWebResponse.Headers, httpRequest);
                        }
                        else if (ex.Status == WebExceptionStatus.Timeout)
                        {
                            // For connection timeout errors, include the connection timeout value that was used.
                            var message = $"{ex.Message} (HTTP request timeout was set to {httpRequest.Timeout}ms)";
                            rethrowEx = new ConnectionException(message, response, ex.Status, httpRequest);
                        }
                        else
                        {
                            // Non-protocol errors indicate something happened with the underlying connection to the server.
                            rethrowEx = new ConnectionException("Invalid HTTP response: " + ex.Message, response,
                                ex.Status, httpRequest);
                        }

                        if (ex.Response is HttpWebResponse)
                        {
                            var httpWebResponse = (HttpWebResponse) ex.Response;
                            ResponseDetails.StatusCode = httpWebResponse.StatusCode;
                            ResponseDetails.Headers = httpWebResponse.Headers;
                        }

                        ResponseDetails.Exception = rethrowEx;
                        throw rethrowEx;
                    }
                } while (retries++ < retriesConfigured);
            }
            catch (LoginRadiusException e)
            {
                // Rethrow any LoginRadiusExceptions since they already contain the
                // details of the exception.

                throw;
            }
            catch (System.Exception ex)
            {
                // Repackage any other exceptions to give a bit more context to
                // the caller.
                throw new LoginRadiusException("Exception in LoginRadius.HttpConnection.Execute(): " + ex.Message, ex);
            }

            // If we've gotten this far, it means all attempts at sending the
            // request resulted in a failed attempt.
            throw new LoginRadiusException("Retried " + retriesConfigured +
                                           " times.... Exception in LoginRadius.HttpConnection.Execute().");
        }
    }
}