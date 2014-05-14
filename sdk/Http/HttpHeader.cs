using System.Collections.Generic;
using System.Net;

namespace LoginRadius.SDK.Http
{
    /// <summary>
    /// 
    /// </summary>
    internal class HttpHeader : Dictionary<string, string>
    {
        public WebHeaderCollection ToWebHeaderCollection()
        {
            WebHeaderCollection webheadercollection = new WebHeaderCollection();

            if (this.Count > 0)
            {
                foreach (var header in this)
                {
                    webheadercollection.Add(header.Key, header.Value);
                }
            }

            return webheadercollection;
        }
    }
}
