using System.Collections.Generic;
using System.Linq;

namespace LoginRadiusSDK.Utility.Http
{
    public class HttpRequestParameter : Dictionary<string, string>
    {
        public override string ToString()
        {
            return Count > 0 ? string.Join("&", this.Select(x => x.Key + "=" + x.Value).ToArray()) : string.Empty;
        }

        public string ToString(string uri)
        {
            if (uri.Contains("?"))
            {
                uri = uri + "&" + ToString();
            }
            else
            {
                uri = uri + "?" + ToString();
            }

            return uri;
        }
    }
}
