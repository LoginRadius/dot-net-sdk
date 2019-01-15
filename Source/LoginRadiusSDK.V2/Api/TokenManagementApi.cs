using LoginRadiusSDK.V2.Entity;
using LoginRadiusSDK.V2.Models;
using LoginRadiusSDK.V2.Models.Identity;
using LoginRadiusSDK.V2.Models.UserProfile;
using LoginRadiusSDK.V2.Util;
using static LoginRadiusSDK.V2.Util.LoginRadiusArgumentValidator;

namespace LoginRadiusSDK.V2.Api
{
    public class TokenManagementApi : LoginRadiusResource
    {
        /// <summary>
        /// This API creates a LoginRadius access token using Facebook credentials.
        /// </summary>
        /// <param name="facebookToken">Facebook access token.</param>
        /// <returns>LoginRadiusAccessToken: LR access token.</returns>
        public ApiResponse<LoginRadiusAccessToken> GetFacebookAccessToken(string facebookToken)
        {
            Validate(new[] { facebookToken });
            var additionalQueryParams = new QueryParameters { ["fb_access_token"] = facebookToken };
            return ConfigureAndExecute<LoginRadiusAccessToken>(RequestType.AdvancedSocial,
                HttpMethod.GET, "access_token/facebook", additionalQueryParams);
        }

        /// <summary>
        /// This API creates a LoginRadius access token using Twitter credentials.
        /// </summary>
        /// <param name="twitterToken">Twitter access token.</param>
        /// <param name="twitterTokenSecret">Twitter secret.</param>
        /// <returns>LoginRadiusAccessToken: LR access token.</returns>
        public ApiResponse<LoginRadiusAccessToken> GetTwitterAccessToken(string twitterToken, string twitterTokenSecret)
        {
            Validate(new[] { twitterToken, twitterTokenSecret });
            var additionalQueryParams =
                new QueryParameters { ["tw_access_token"] = twitterToken, ["tw_token_secret"] = twitterTokenSecret };
            return ConfigureAndExecute<LoginRadiusAccessToken>(RequestType.AdvancedSocial,
                HttpMethod.GET, "access_token/twitter", additionalQueryParams);
        }

        /// <summary>
        /// This API creates a LoginRadius access token using Vkontakte credentials.
        /// </summary>
        /// <param name="vkontakteToken">Vkontakte access token.</param>
        /// <returns>LoginRadiusAccessToken: LR access token.</returns>
        public ApiResponse<LoginRadiusAccessToken> GetVkontakteAccessToken(string vkontakteToken)
        {
            Validate(new[] { vkontakteToken });
            var additionalQueryParams = new QueryParameters { ["vk_access_token"] = vkontakteToken };
            return ConfigureAndExecute<LoginRadiusAccessToken>(RequestType.AdvancedSocial,
                HttpMethod.GET, "access_token/vkontakte", additionalQueryParams);
        }

        /// <summary>
        /// This API creates a LoginRadius access token using Google credentials.
        /// </summary>
        /// <param name="googleToken">Google JWT token.</param>
        /// <returns>LoginRadiusAccessToken: LR access token.</returns>
        public ApiResponse<LoginRadiusAccessToken> GetGoogleAccessToken(string googleToken)
        {
            Validate(new[] { googleToken });
            var additionalQueryParams = new QueryParameters { ["id_token"] = googleToken };
            return ConfigureAndExecute<LoginRadiusAccessToken>(RequestType.AdvancedSocial,
                HttpMethod.GET, "access_token/googlejwt", additionalQueryParams);
        }

        /// <summary>
        /// Refreshes a LoginRadius user profile
        /// </summary>
        /// <param name="accessToken">Existing valid access token.</param>
        /// <returns>LoginRadiusSocialUserProfile: LR profile with social data.</returns>
        public ApiResponse<LoginRadiusSocialUserProfile> GetRefreshUserProfile(string accessToken)
        {
            Validate(new[] { accessToken });
            var additionalQueryParams = new QueryParameters { ["access_token"] = accessToken };
            return ConfigureAndExecute<LoginRadiusSocialUserProfile>(RequestType.AdvancedSocial, HttpMethod.GET,
                "userprofile/refresh", additionalQueryParams);
        }

        /// <summary>
        /// Refreshes a LoginRadius access token.
        /// </summary>
        /// <param name="accessToken">Existing valid access token.</param>
        /// <returns>LoginResponse: LR access token.</returns>
        public ApiResponse<AccessTokenResponse> GetRefreshToken(string accessToken)
        {
            Validate(new[] { accessToken });
            var additionalQueryParams = new QueryParameters { ["access_token"] = accessToken };
            return ConfigureAndExecute<AccessTokenResponse>(RequestType.AdvancedSocial, HttpMethod.GET,
                "access_token/refresh", additionalQueryParams);
        }

        /// <summary>
        /// The Shorten URL API is used to convert your URLs to the LoginRadius short URL - ish.re
        /// </summary>
        /// <param name="uri">Verification token being verified.</param>
        /// <returns>ShortUrlResponse: Object containing info on shortened url.</returns>
        public ApiResponse<ShortUrlResponse> GetShortenUri(string uri)
        {
            Validate(new[] { uri });
            var additionalQueryParams = new QueryParameters { ["url"] = uri };
            return ConfigureAndExecute<ShortUrlResponse>(RequestType.AdvancedSharing, HttpMethod.GET, null,
                additionalQueryParams);
        }
    }
}