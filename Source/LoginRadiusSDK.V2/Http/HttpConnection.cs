using System;
using System.Collections.Concurrent;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using LoginRadiusSDK.V2.Common;
using LoginRadiusSDK.V2.Exception;
using Newtonsoft.Json;

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
        private readonly ConcurrentDictionary<string, string> _config;

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
        public HttpConnection(ConcurrentDictionary<string, string> config)
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
        private HttpWebRequest CopyRequest(HttpWebRequest httpRequest, ConcurrentDictionary<string, string> config, string url)
        {
            ConnectionManager connMngr = ConnectionManager.Instance;

            HttpWebRequest newHttpRequest = connMngr.GetConnection(config, url);
            newHttpRequest.Method = httpRequest.Method;
            newHttpRequest.Accept = httpRequest.Accept;
            newHttpRequest.ContentType = httpRequest.ContentType;

#if !NETSTANDARD1_3
            if (httpRequest.ContentLength > 0)
            {
                newHttpRequest.ContentLength = httpRequest.ContentLength;
            }
            newHttpRequest.UserAgent = httpRequest.UserAgent;
            newHttpRequest.ClientCertificates = httpRequest.ClientCertificates;
            newHttpRequest.AutomaticDecompression = DecompressionMethods.GZip;
#endif
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
                switch (key.ToLower())
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
        public async Task<string> Execute(string payLoad, HttpWebRequest httpRequest, int contentLength)
        {
            int retriesConfigured = _config.ContainsKey(LRConfigConstants.HttpConnectionRetryConfig)
                && int.TryParse(_config[LRConfigConstants.HttpConnectionRetryConfig], out int retriesInt)
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

#if !NETSTANDARD1_3
            if (contentLength == 0) httpRequest.ContentLength = contentLength;
#endif

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
                        switch (httpRequest.Method.ToUpper())
                        {
                            case "POST":
                            case "PUT":
                            case "DELETE":
                                if (!string.IsNullOrEmpty(payLoad))
                                {
                                    Stream stream = null;
#if NetFramework
                                    stream = httpRequest.GetRequestStream();
#else
                                    stream = await httpRequest.GetRequestStreamAsync();
#endif
                                    using (StreamWriter writerStream = new StreamWriter(stream))
                                    {
                                        writerStream.Write(payLoad);
                                        writerStream.Flush();
#if NetFramework
                                        writerStream.Close();
#endif
                                    }
                                }
                                break;
                        }
                        WebResponse webResponse = null;
#if !NetFramework
                        webResponse = await httpRequest.GetResponseAsync();
#else
                        webResponse = httpRequest.GetResponse();
#endif
                        using (WebResponse responseWeb = webResponse)
                        {
                            // Store the response information
                            ResponseDetails.Headers = responseWeb.Headers;
                            if (responseWeb is HttpWebResponse httpWebResponse)
                            {
                                ResponseDetails.StatusCode = httpWebResponse.StatusCode;
                            }

                            using (StreamReader readerStream = new StreamReader(responseWeb.GetResponseStream()))
                            {
#if NET40
                                ResponseDetails.Body = readerStream.ReadToEnd().Trim();
#else
                                ResponseDetails.Body = await readerStream.ReadToEndAsync();
#endif
                                return ResponseDetails.Body;
                            }
                        }
                    }
                    catch (WebException ex)
                    {
                        CatchException(ex, httpRequest);
                    }
#if NETSTANDARD
                    catch (System.Exception ex)
                    {
                        if (ex.InnerException is WebException webException)
                        {
                            CatchException(webException, httpRequest);
                        }
                        else
                        {
                            throw new LoginRadiusException(ex.Message, ex);
                        }
                    }
#endif
                } while (retries++ < retriesConfigured);
            }
            catch (LoginRadiusException)
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

        private void CatchException(WebException ex, HttpWebRequest httpRequest)
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
            if (ex.Status == WebExceptionStatus.ProtocolError && ex.Response is HttpWebResponse httpWebResponse)
            {
                if (httpWebResponse.StatusCode.Equals((HttpStatusCode)429))
                {
                    throw new LoginRadiusException("Too many request in particular time frame", ex, response, (HttpStatusCode)429);

                }
                // If the HTTP status code is flagged as one where we
                // should continue retrying, then ignore the exception
                // and continue with the retry attempt.
                if (httpWebResponse.StatusCode == HttpStatusCode.GatewayTimeout ||
                    httpWebResponse.StatusCode == HttpStatusCode.RequestTimeout ||
                    httpWebResponse.StatusCode == HttpStatusCode.BadGateway)
                {
                    return;
                }

                // If the httpWebResponse.StatusCode is defined in the HttpStatusCode then throw the LoginRadiusException 

                if (Enum.IsDefined(typeof(HttpStatusCode), httpWebResponse.StatusCode))
                {
                    throw new LoginRadiusException(ex.Message, ex, response, (HttpStatusCode)httpWebResponse.StatusCode);
                }

                rethrowEx = new HttpException(ex.Message, response, httpWebResponse.StatusCode, ex.Status,
                    httpWebResponse.Headers, httpRequest);
            }
            else if (ex.Status == WebExceptionStatus.Timeout)
            {
                string message;

                // For connection timeout errors, include the connection timeout value that was used.
#if NetFramework
                message = $"{ex.Message} (HTTP request timeout was set to {httpRequest.Timeout}ms)";
#else
                message = ex.Message;
#endif
                rethrowEx = new ConnectionException(message, response, ex.Status, httpRequest);
            }
            else
            {
                // Non-protocol errors indicate something happened with the underlying connection to the server.
                rethrowEx = new ConnectionException("Invalid HTTP response: " + ex.Message, response,
                    ex.Status, httpRequest);
            }

            if (ex.Response is HttpWebResponse httpWebResponse1)
            {
                ResponseDetails.StatusCode = httpWebResponse1.StatusCode;
                ResponseDetails.Headers = httpWebResponse1.Headers;
            }

            ResponseDetails.Exception = rethrowEx;
            throw rethrowEx;
        }
    }

}