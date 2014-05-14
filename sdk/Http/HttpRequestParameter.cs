using System.Collections.Generic;
using System.Linq;

namespace LoginRadius.SDK.Http
{
    internal class HttpRequestParameter : Dictionary<string, string>
    {
        public override string ToString()
        {
            if (this.Count > 0)
            {
                return string.Join("&", this.Select(x => x.Key + "=" + x.Value).ToArray());
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
