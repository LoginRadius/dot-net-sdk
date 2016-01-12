using System;
using LoginRadiusSDK.Entity;
using LoginRadiusSDK.Utility.Http;

namespace LoginRadiusSDK.API
{
    /// <summary>
    /// The User Profile API is used to get social profile data from the user’s social account after authentication. The social profile data will be retrieved via oAuth and OpenID protocols. The data will be normalized into LoginRadius' standard data format.
    /// </summary>
    public class UserProfileApi : ILoginRadiusApi
    {
        readonly HttpClient _client = new HttpClient();

        const string Endpoint = "api/v2/userprofile?access_token={0}";
        const string RawEndpoint = "api/v2/userprofile/raw?access_token={0}";

        /// <summary>
        /// The User Profile API is used to get social profile data from the user’s social account after authentication. The social profile data will be retrieved via oAuth and OpenID protocols. The data will be normalized into LoginRadius' standard data format.
        /// </summary>
        /// <param name="token">A valid session token,which is fetch from Access Token API</param>
        /// <returns></returns>
        public string ExecuteApi(Guid token)
        {
            var url = string.Format(Constants.ApiRootDomain + Endpoint, token);
            return _client.Request(url, null, HttpMethod.GET);
        }

        /// <summary>
        /// Get user profile data as provided by the provider. The data will not be in a consistent response type and format across providers, so you will have to parse it yourself.
        /// </summary>
        /// <param name="token">A valid session token,which is fetch from Access Token API</param>
        /// <returns></returns>
        public string ExecuteRawApi(Guid token)
        {
            var url = string.Format(Constants.ApiRootDomain + RawEndpoint, token);
            return _client.Request(url, null, HttpMethod.GET);
        }
    }
}
