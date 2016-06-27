using System.IO;
using System.Net;
using System.Text;
using LoginRadiusSDK.Exception;

namespace LoginRadiusSDK.Utility.Http
{
    /// <summary>
    /// The HttpClient class is used to handle all http requests to loginradius api.
    /// </summary>
    public class HttpClient
    {
        public HttpClient()
        {
            Headers = new HttpHeader();
        }

        public HttpHeader Headers { get; private set; }

        public HttpResponse HttpGet(string uri, HttpRequestParameter httpParameters)
        {
            if (httpParameters != null && httpParameters.Count > 0)
            {
                uri = httpParameters.ToString(uri);
            }

            return HttpRequest(uri, null, "GET", "application/json");
        }

        public HttpResponse HttpPost(string uri, HttpRequestParameter postHttpParameters)
        {
            return HttpPost(uri, null, postHttpParameters);
        }
        public HttpResponse HttpPost(string uri, HttpRequestParameter getHttpParameters, HttpRequestParameter postHttpParameters)
        {
            if (getHttpParameters != null && getHttpParameters.Count > 0)
            {
                uri = getHttpParameters.ToString(uri);
            }

            return HttpPost(uri, postHttpParameters.ToString(), "application/x-www-form-urlencoded");
        }


        public HttpResponse HttpPostXml(string uri, string xml)
        {
            return HttpPostXml(uri, null, xml);
        }

        private HttpResponse HttpPostXml(string uri, HttpRequestParameter getHttpParameters, string xml)
        {
            if (getHttpParameters != null && getHttpParameters.Count > 0)
            {
                uri = getHttpParameters.ToString(uri);
            }

            return HttpPost(uri, xml, "application/xml");
        }

        public HttpResponse HttpPutXml(string uri)
        {
            return HttpPutXml(uri,null);
        }

        private HttpResponse HttpPutXml(string uri, string xml)
        {
            return HttpPutXml(uri, null, xml);
        }

        private HttpResponse HttpPutXml(string uri, HttpRequestParameter getHttpParameters, string xml)
        {
            if (getHttpParameters != null && getHttpParameters.Count > 0)
            {
                uri = getHttpParameters.ToString(uri);
            }

            return HttpPut(uri, xml, "application/xml");
        }


        public HttpResponse HttpDeleteXml(string uri)
        {
            return HttpDeleteXml(uri, null, null);
        }

        public HttpResponse HttpDeleteXml(string uri, string xml)
        {
            return HttpDeleteXml(uri, null, xml);
        }

        public HttpResponse HttpDeleteXml(string uri, HttpRequestParameter getHttpParameters)
        {
            return HttpDeleteXml(uri, getHttpParameters, null);
        }

        private HttpResponse HttpDeleteXml(string uri, HttpRequestParameter getHttpParameters, string xml)
        {
            if (getHttpParameters != null && getHttpParameters.Count > 0)
            {
                uri = getHttpParameters.ToString(uri);
            }

            return HttpDelete(uri, xml, "application/xml");
        }


        public HttpResponse HttpPostJson(string uri, string json)
        {
            return HttpPostJson(uri, null, json);
        }
        public HttpResponse HttpPostJson(string uri, HttpRequestParameter getHttpParameters, string json)
        {
            if (getHttpParameters != null && getHttpParameters.Count > 0)
            {
                uri = getHttpParameters.ToString(uri);
            }

            return HttpPost(uri, json, "application/json");
        }


        private HttpResponse HttpPost(string uri, string postData, string contentType)
        {
            return HttpRequest(uri, postData, "POST", contentType);
        }

        private HttpResponse HttpPut(string uri, string postData, string contentType)
        {
            return HttpRequest(uri, postData, "PUT", contentType);
        }

        private HttpResponse HttpDelete(string uri, string postData, string contentType)
        {
            return HttpRequest(uri, postData, "DELETE", contentType);
        }

        private HttpResponse HttpRequest(string uri, string requestData, string method, string contentType)
        {
            var response = new HttpResponse();

            var req = (HttpWebRequest)WebRequest.Create(uri);

            const string accept = "application/json";

            if (Headers != null)
            {
                req.Headers = Headers.ToWebHeaderCollection();
            }
            req.Accept = accept;
            req.ContentType = contentType;
            req.Method = method;
            try
            {
                if (!string.IsNullOrEmpty(requestData))
                {
                    var bytes = Encoding.UTF8.GetBytes(requestData);
                    req.ContentLength = bytes.Length;

                    var os = req.GetRequestStream();
                    os.Write(bytes, 0, bytes.Length);
                    os.Close();
                }
            }
            catch (WebException exception)
            {
                throw new LoginRadiusException("Unable to connect through the Internet", exception);
            }

            try
            {
                var resp = req.GetResponse();
                var sr = new StreamReader(resp.GetResponseStream());
                response.HttpHeader = resp.Headers.ToHttpHeader();
                response.StatusCode = HttpStatusCode.OK;
                response.ResponseContent = sr.ReadToEnd().Trim();
            }
            catch (WebException e)
            {
                using (var re = e.Response)
                {
                    if (re != null)
                    {
                        using (var data = re.GetResponseStream())
                        {
                            if (data != null)
                            {
                                var text = new StreamReader(data).ReadToEnd();
                                throw new LoginRadiusException("LoginRadius API Exception", e, text);
                            }
                        }
                    }
                    else
                    {
                        throw new LoginRadiusException("LoginRadius API Exception", e);
                    }
                }
            }
         

            return response;
        }
        //imported from social code:

        public string Request(string url, HttpRequestParameter parameter, HttpMethod method)
        {
            return Request(url, parameter, method, null);
        }

        private string Request(string url, HttpRequestParameter parameter, HttpMethod method, HttpHeader headers)
        {
            var _params = string.Empty;

            if (parameter != null && parameter.Count > 0)
            {
                _params = parameter.ToString();
            }


            if (method == HttpMethod.GET)
            {
                if (url.Contains("?"))
                {
                    url = url + "&" + _params;
                }
                else
                {
                    url = url + "?" + _params;
                }

                return HttpGet(url, headers);
            }
            else
            {
                return HttpPost(url, _params, headers);
            }
        }

        private static string HttpGet(string uri, HttpHeader headers)
        {
            var req = WebRequest.Create(uri);

            var resp = req.GetResponse();

            if (headers != null)
            {
                req.Headers = headers.ToWebHeaderCollection();
            }

            var sr = new StreamReader(resp.GetResponseStream());

            return sr.ReadToEnd().Trim();
        }

        private string HttpPost(string uri, string parameters, HttpHeader headers)
        {
            var req = WebRequest.Create(uri);

            if (headers != null)
            {
                req.Headers = headers.ToWebHeaderCollection();
            }

            req.ContentType = "application/x-www-form-urlencoded";
            req.Method = "POST";

            var bytes = Encoding.UTF8.GetBytes(parameters);
            req.ContentLength = bytes.Length;

            Stream os = req.GetRequestStream();
            os.Write(bytes, 0, bytes.Length);
            os.Close();

            var resp = req.GetResponse();

            var sr = new StreamReader(resp.GetResponseStream());

            return sr.ReadToEnd().Trim();
        }
    }
}