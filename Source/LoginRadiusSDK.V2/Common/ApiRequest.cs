using System.Net;
using LoginRadiusSDK.V2.Http;

namespace LoginRadiusSDK.V2.Common
{
    public class ApiRequest
    {
        internal HttpConnection HttpConnection { get; set; }

        internal HttpWebRequest HttpRequest { get; set; }

        internal string Payload { get; set; }
    }
}
