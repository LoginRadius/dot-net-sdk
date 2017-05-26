using System.Net;

namespace LoginRadiusSDK.V2.Http
{
    public class HttpResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public string ResponseContent { get; set; }
        public HttpHeader HttpHeader { get; set; }
    }
}