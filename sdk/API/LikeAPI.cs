using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LoginRadius.SDK.Http;

namespace LoginRadius.SDK.API
{
    /// <summary>
    /// The Like API is used to get likes data from the user’s social account. The data will be normalized into LoginRadius' standard data format.
    /// </summary>
    public class LikeAPI : ILoginRadiusAPI
    {
        HttpClient client = new HttpClient();

        const string Endpoint = "api/v2/like?access_token={0}";
        const string RawEndpoint = "api/v2/like/raw?access_token={0}";

        /// <summary>
        /// The Like API is used to get likes data from the user’s social account. The data will be normalized into LoginRadius' standard data format.
        /// </summary>
        /// <param name="token">A valid session token,which is fetch from Access Token API.</param>
        /// <returns></returns>
        public string ExecuteAPI(Guid token)
        {
            string url = string.Format(Constants.APIRootDomain + Endpoint, token);
            return client.Request(url, null, HttpMethod.GET);
        }

        /// <summary>
        /// Get user likes data as provided by the provider. The data will not be in a consistent response type and format across providers, so you will have to parse it yourself.
        /// </summary>
        /// <param name="token">A valid session token,which is fetch from Access Token API.</param>
        /// <returns></returns>
        public string ExecuteRawAPI(Guid token)
        {
            string url = string.Format(Constants.APIRootDomain + RawEndpoint, token);
            return client.Request(url, null, HttpMethod.GET);
        }
    }
}
