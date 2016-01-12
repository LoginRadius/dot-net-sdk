using System;
using LoginRadiusSDK.Entity;
using LoginRadiusSDK.Utility.Http;

namespace LoginRadiusSDK.API
{
    /// <summary>
    /// The Photo API is used to get photo data from the user’s social account. The data will be normalized into LoginRadius' standard data format.
    /// </summary>
    public class PhotoApi : ILoginRadiusApi
    {
        public PhotoApi(string albumId)
        {
            AlbumId = albumId;
        }

        public PhotoApi()
        { }
        /// <summary>
        /// A valid albumId, it return album photos
        /// </summary>
        private string AlbumId { get; set; }

        readonly HttpClient _client = new HttpClient();

        const string EndpointWithAlbumId = "api/v2/photo?access_token={0}&albumid={1}";
        const string Endpoint = "api/v2/photo?access_token={0}";
        const string RawEndpoint = "api/v2/photo/raw?access_token={0}";
        const string RawEndpointWithAlbumId = "api/v2/photo/raw?access_token={0}&albumid={1}";
        /// <summary>
        /// The Photo API is used to get photo data from the user’s social account. The data will be normalized into LoginRadius' standard data format
        /// </summary>
        /// <param name="token">A valid session token,which is fetch from Access Token API.</param>
        /// <returns></returns>
        public string ExecuteApi(Guid token)
        {
            var url = string.IsNullOrEmpty(AlbumId) ? string.Format(Constants.ApiRootDomain + Endpoint, token) : string.Format(Constants.ApiRootDomain + EndpointWithAlbumId, token, AlbumId);
            return _client.Request(url, null, HttpMethod.GET);
        }

        /// <summary>
        /// Get user photo data as provided by the provider. The data will not be in a consistent response type and format across providers, so you will have to parse it yourself.
        /// </summary>
        /// <param name="token">A valid session token,which is fetch from Access Token API.</param>
        /// <returns></returns>
        public string ExecuteRawApi(Guid token)
        {
            var url = string.IsNullOrEmpty(AlbumId) ? string.Format(Constants.ApiRootDomain + RawEndpoint, token) : string.Format(Constants.ApiRootDomain + RawEndpointWithAlbumId, token, AlbumId);
            return _client.Request(url, null, HttpMethod.GET);
        }
    }
}
