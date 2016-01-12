using System;
using LoginRadiusSDK.Entity;
using LoginRadiusSDK.Utility.Http;

namespace LoginRadiusSDK.API
{
    /// <summary>
    /// The Post API is used to get post message data from the user’s social account. The data will be normalized into LoginRadius' standard data format.
    /// </summary>
    public class StatusApi : ILoginRadiusApi
    {
        readonly HttpClient _client = new HttpClient();

        const string Endpoint = "api/v2/status?access_token={0}";
        const string RawEndpoint = "api/v2/status/raw?access_token={0}";

        /// <summary>
        /// The Status API is used to get the status messages from the user’s social account. The data will be normalized into LoginRadius' standard data format.
        /// </summary>
        /// <param name="token">A valid session token,which is fetch from Access Token API.</param>
        /// <returns></returns>
        public string ExecuteApi(Guid token)
        {
            string url = string.Format(Constants.ApiRootDomain + Endpoint, token);
            return _client.Request(url, null, HttpMethod.GET);
        }

        /// <summary>
        /// Get status messages as provided by the provider. The data will not be in a consistent response type and format across providers, so you will have to parse it yourself.
        /// </summary>
        /// <param name="token">A valid session token,which is fetch from Access Token API.</param>
        /// <returns></returns>
        public string ExecuteRawApi(Guid token)
        {
            string url = string.Format(Constants.ApiRootDomain + RawEndpoint, token);
            return _client.Request(url, null, HttpMethod.GET);
        }
    }
}
