using System.IO;
using System.Net;
using System.Text;

namespace LoginRadius.SDK.Http
{
    /// <summary>
    /// The HttpClient class is used to handle all http requests to loginradius api.
    /// </summary>
    internal class HttpClient
    {

        public string Request(string url, HttpRequestParameter parameter, HttpMethod method)
        {
            return Request(url, parameter, method, null);
        }

        public string Request(string url, HttpRequestParameter parameter, HttpMethod method, HttpHeader headers)
        {
            string _params = string.Empty;

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

        private string HttpGet(string URI, HttpHeader headers)
        {
            WebRequest req = WebRequest.Create(URI);

            WebResponse resp = req.GetResponse();

            if (headers != null)
            {
                req.Headers = headers.ToWebHeaderCollection();
            }

            if (resp == null)
            {
                return null;
            }

            StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());

            return sr.ReadToEnd().Trim();
        }

        private string HttpPost(string URI, string Parameters, HttpHeader headers)
        {
            WebRequest req = WebRequest.Create(URI);

            if (headers != null)
            {
                req.Headers = headers.ToWebHeaderCollection();
            }

            req.ContentType = "application/x-www-form-urlencoded";
            req.Method = "POST";

            byte[] bytes = Encoding.ASCII.GetBytes(Parameters);
            req.ContentLength = bytes.Length;

            Stream os = req.GetRequestStream();
            os.Write(bytes, 0, bytes.Length);
            os.Close();

            WebResponse resp = req.GetResponse();

            if (resp == null)
            {
                return null;
            }

            StreamReader sr = new StreamReader(resp.GetResponseStream());

            return sr.ReadToEnd().Trim();
        }
    }
}