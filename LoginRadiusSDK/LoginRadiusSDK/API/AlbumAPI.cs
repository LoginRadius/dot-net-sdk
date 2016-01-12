using System;
using LoginRadiusSDK.Entity;
using LoginRadiusSDK.Utility.Http;

namespace LoginRadiusSDK.API
{
    /// <summary>
    ///     The Album API is used to get the Album data from the user’s social account. The data will be normalized into
    ///     LoginRadius standard data format.
    /// </summary>
    public class AlbumApi : ILoginRadiusApi
    {
        private string Nextcursor { get; set; }
        public AlbumApi(string nextcursor)
        {
            Nextcursor = nextcursor;
        }
        public AlbumApi() { }
        private const string Endpoint = "api/v2/album?access_token={0}";
        private const string EndpointWithNextcursor = "api/v2/album?access_token={0}&nextcursor={1}";
        private const string RawEndpoint = "api/v2/album/raw?access_token={0}";
        private const string RawEndpointWithNextcursor = "api/v2/album/raw?access_token={0}&nextcursor={1}";
        private readonly HttpClient _client = new HttpClient();

        /// <summary>
        ///     The Album API is used to get the album data from the user’s social account. The data will be normalized into
        ///     LoginRadius' standard data format.
        /// </summary>
        /// <param name="token">A valid session token,which is fetch from Access Token API.</param>
        /// <returns></returns>
        public string ExecuteApi(Guid token)
        {
            var url = string.IsNullOrEmpty(Nextcursor) ? string.Format(Constants.ApiRootDomain + Endpoint, token) : string.Format(Constants.ApiRootDomain + EndpointWithNextcursor, token, Nextcursor);
            return _client.Request(url, null, HttpMethod.GET);
        }

        /// <summary>
        ///     Get album data from the user’s social account.The data will not be in a consistent response type and format across
        ///     providers, so you will have to parse it yourself.
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