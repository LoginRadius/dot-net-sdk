using System;
using LoginRadiusSDK.Entity;
using LoginRadiusSDK.Utility.Http;

namespace LoginRadiusSDK.API
{
    /// <summary>
    /// The Page API is used to get the page data from the user’s social account. The data will be normalized into LoginRadius' standard data format.
    /// </summary>
    public class PageApi : ILoginRadiusApi
    {
        public PageApi(string pageName)
        {
            PageName = pageName;
        }
        /// <summary>
        /// Page name
        /// </summary>
        private string PageName { get; set; }

        readonly HttpClient _client = new HttpClient();

        const string Endpoint = "api/v2/page?access_token={0}&pagename={1}";
        const string RawEndpoint = "api/v2/page/raw?access_token={0}&pagename={1}";

        /// <summary>
        /// The Page API is used to get the page data from the user’s social account. The data will be normalized into LoginRadius' standard data format.
        /// </summary>
        /// <param name="token">A valid session token,which is fetch from Access Token API.</param>
        /// <returns></returns>
        public string ExecuteApi(Guid token)
        {
            var url = string.Format(Constants.ApiRootDomain + Endpoint, token, PageName);
            return _client.Request(url, null, HttpMethod.GET);
        }

        /// <summary>
        /// Get page data as provided by the provider. The data will not be in a consistent response type and format across providers, so you will have to parse it yourself.
        /// </summary>
        /// <param name="token">A valid session token,which is fetch from Access Token API.</param>
        /// <returns></returns>
        public string ExecuteRawApi(Guid token)
        {
            var url = string.Format(Constants.ApiRootDomain + RawEndpoint, token,PageName);
            return _client.Request(url, null, HttpMethod.GET);
        }
    }
}
