using System;
using LoginRadiusSDK.Entity;
using LoginRadiusSDK.Utility.Http;

namespace LoginRadiusSDK.API
{
    /// <summary>
    /// The Group API is used to get group data from the user’s social account. The data will be normalized into LoginRadius' standard data format.
    /// </summary>
    public class GroupApi : ILoginRadiusApi
    {
        private string Nextcursor { get; set; }
        public GroupApi(string nextcursor)
        {
            Nextcursor = nextcursor;
        }
        public GroupApi() { }
        readonly HttpClient _client = new HttpClient();

        const string Endpoint = "api/v2/group?access_token={0}";
        const string EndpointWithNextcursor = "api/v2/group?access_token={0}&nextcursor={1}";
        const string RawEndpoint = "api/v2/group/raw?access_token={0}";
        const string RawEndpointWithNextcursor = "api/v2/group/raw?access_token={0}&nextcursor={1}";
        /// <summary>
        /// The Group API is used to get group data from the user’s social account. The data will be normalized into LoginRadius' standard data format.
        /// </summary>
        /// <param name="token">A valid session token,which is fetch from Access Token API.</param>
        /// <returns></returns>
        public string ExecuteApi(Guid token)
        {
            var url = string.IsNullOrEmpty(Nextcursor) ? string.Format(Constants.ApiRootDomain + Endpoint, token) : string.Format(Constants.ApiRootDomain + EndpointWithNextcursor, token, Nextcursor);
            return _client.Request(url, null, HttpMethod.GET);
        }

        /// <summary>
        /// Get Group data as provided by the provider. The data will not be in a consistent response type and format across providers, so you will have to parse it yourself.
        /// </summary>
        /// <param name="token">A valid session token,which is fetch from Access Token API.</param>
        /// <returns></returns>
        public string ExecuteRawApi(Guid token)
        {
            var url = string.IsNullOrEmpty(Nextcursor) ? string.Format(Constants.ApiRootDomain + RawEndpoint, token) : string.Format(Constants.ApiRootDomain + RawEndpointWithNextcursor, token, Nextcursor);
            return _client.Request(url, null, HttpMethod.GET);
        }
    }
}
