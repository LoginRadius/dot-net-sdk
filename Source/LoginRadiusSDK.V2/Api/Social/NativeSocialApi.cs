//-----------------------------------------------------------------------
// <copyright file="NativeSocialApi.cs" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2019 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using LoginRadiusSDK.V2.Common;
using System.Threading.Tasks;
using LoginRadiusSDK.V2.Util;
using LoginRadiusSDK.V2.Models.ResponseModels;

namespace LoginRadiusSDK.V2.Api.Social
{
    public class NativeSocialApi : LoginRadiusResource
    {
        /// <summary>
        /// The API is used to get LoginRadius access token by sending Facebook's access token. It will be valid for the specific duration of time specified in the response.
        /// </summary>
        /// <param name="fbAccessToken">Facebook Access Token</param>
        /// <param name="socialAppName">Name of Social provider APP</param>
        /// <returns>Response containing Definition of Complete Token data</returns>
        /// 20.3

        public async Task<ApiResponse<AccessToken>> GetAccessTokenByFacebookAccessToken(string fbAccessToken, string socialAppName = null)
        {
            if (string.IsNullOrWhiteSpace(fbAccessToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(fbAccessToken));
            }
            var queryParameters = new QueryParameters
            {
                { "fb_Access_Token", fbAccessToken },
                { "key", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] }
            };
            if (!string.IsNullOrWhiteSpace(socialAppName))
            {
               queryParameters.Add("socialAppName", socialAppName);
            }

            var resourcePath = "api/v2/access_token/facebook";
            
            return await ConfigureAndExecute<AccessToken>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// The API is used to get LoginRadius access token by sending Twitter's access token. It will be valid for the specific duration of time specified in the response.
        /// </summary>
        /// <param name="twAccessToken">Twitter Access Token</param>
        /// <param name="twTokenSecret">Twitter Token Secret</param>
        /// <param name="socialAppName">Name of Social provider APP</param>
        /// <returns>Response containing Definition of Complete Token data</returns>
        /// 20.4

        public async Task<ApiResponse<AccessToken>> GetAccessTokenByTwitterAccessToken(string twAccessToken, string twTokenSecret,
        string socialAppName = null)
        {
            if (string.IsNullOrWhiteSpace(twAccessToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(twAccessToken));
            }
            if (string.IsNullOrWhiteSpace(twTokenSecret))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(twTokenSecret));
            }
            var queryParameters = new QueryParameters
            {
                { "key", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "tw_Access_Token", twAccessToken },
                { "tw_Token_Secret", twTokenSecret }
            };
            if (!string.IsNullOrWhiteSpace(socialAppName))
            {
               queryParameters.Add("socialAppName", socialAppName);
            }

            var resourcePath = "api/v2/access_token/twitter";
            
            return await ConfigureAndExecute<AccessToken>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// The API is used to get LoginRadius access token by sending Google's access token. It will be valid for the specific duration of time specified in the response.
        /// </summary>
        /// <param name="googleAccessToken">Google Access Token</param>
        /// <param name="clientId">Google Client ID</param>
        /// <param name="refreshToken">LoginRadius refresh token</param>
        /// <param name="socialAppName">Name of Social provider APP</param>
        /// <returns>Response containing Definition of Complete Token data</returns>
        /// 20.5

        public async Task<ApiResponse<AccessToken>> GetAccessTokenByGoogleAccessToken(string googleAccessToken, string clientId = null,
        string refreshToken = null, string socialAppName = null)
        {
            if (string.IsNullOrWhiteSpace(googleAccessToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(googleAccessToken));
            }
            var queryParameters = new QueryParameters
            {
                { "google_Access_Token", googleAccessToken },
                { "key", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] }
            };
            if (!string.IsNullOrWhiteSpace(clientId))
            {
               queryParameters.Add("client_id", clientId);
            }
            if (!string.IsNullOrWhiteSpace(refreshToken))
            {
               queryParameters.Add("refresh_token", refreshToken);
            }
            if (!string.IsNullOrWhiteSpace(socialAppName))
            {
               queryParameters.Add("socialAppName", socialAppName);
            }

            var resourcePath = "api/v2/access_token/google";
            
            return await ConfigureAndExecute<AccessToken>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// This API is used to Get LoginRadius Access Token using google jwt id token for google native mobile login/registration.
        /// </summary>
        /// <param name="idToken">Google JWT id_token</param>
        /// <returns>Response containing Definition of Complete Token data</returns>
        /// 20.6

        public async Task<ApiResponse<AccessToken>> GetAccessTokenByGoogleJWTAccessToken(string idToken)
        {
            if (string.IsNullOrWhiteSpace(idToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(idToken));
            }
            var queryParameters = new QueryParameters
            {
                { "id_Token", idToken },
                { "key", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] }
            };

            var resourcePath = "api/v2/access_token/googlejwt";
            
            return await ConfigureAndExecute<AccessToken>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// The API is used to get LoginRadius access token by sending Linkedin's access token. It will be valid for the specific duration of time specified in the response.
        /// </summary>
        /// <param name="lnAccessToken">Linkedin Access Token</param>
        /// <param name="socialAppName">Name of Social provider APP</param>
        /// <returns>Response containing Definition of Complete Token data</returns>
        /// 20.7

        public async Task<ApiResponse<AccessToken>> GetAccessTokenByLinkedinAccessToken(string lnAccessToken, string socialAppName = null)
        {
            if (string.IsNullOrWhiteSpace(lnAccessToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(lnAccessToken));
            }
            var queryParameters = new QueryParameters
            {
                { "key", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "ln_Access_Token", lnAccessToken }
            };
            if (!string.IsNullOrWhiteSpace(socialAppName))
            {
               queryParameters.Add("socialAppName", socialAppName);
            }

            var resourcePath = "api/v2/access_token/linkedin";
            
            return await ConfigureAndExecute<AccessToken>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// The API is used to get LoginRadius access token by sending Foursquare's access token. It will be valid for the specific duration of time specified in the response.
        /// </summary>
        /// <param name="fsAccessToken">Foursquare Access Token</param>
        /// <returns>Response containing Definition of Complete Token data</returns>
        /// 20.8

        public async Task<ApiResponse<AccessToken>> GetAccessTokenByFoursquareAccessToken(string fsAccessToken)
        {
            if (string.IsNullOrWhiteSpace(fsAccessToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(fsAccessToken));
            }
            var queryParameters = new QueryParameters
            {
                { "fs_Access_Token", fsAccessToken },
                { "key", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] }
            };

            var resourcePath = "api/v2/access_token/foursquare";
            
            return await ConfigureAndExecute<AccessToken>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// The API is used to get LoginRadius access token by sending a valid Apple ID OAuth Code. It will be valid for the specific duration of time specified in the response.
        /// </summary>
        /// <param name="code">Apple Code</param>
        /// <param name="socialAppName">Name of Social provider APP</param>
        /// <returns>Response containing Definition of Complete Token data</returns>
        /// 20.12

        public async Task<ApiResponse<AccessToken>> GetAccessTokenByAppleIdCode(string code, string socialAppName = null)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(code));
            }
            var queryParameters = new QueryParameters
            {
                { "code", code },
                { "key", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] }
            };
            if (!string.IsNullOrWhiteSpace(socialAppName))
            {
               queryParameters.Add("socialAppName", socialAppName);
            }

            var resourcePath = "api/v2/access_token/apple";
            
            return await ConfigureAndExecute<AccessToken>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// This API is used to retrieve a LoginRadius access token by passing in a valid WeChat OAuth Code.
        /// </summary>
        /// <param name="code">WeChat Code</param>
        /// <returns>Response containing Definition of Complete Token data</returns>
        /// 20.13

        public async Task<ApiResponse<AccessToken>> GetAccessTokenByWeChatCode(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(code));
            }
            var queryParameters = new QueryParameters
            {
                { "code", code },
                { "key", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] }
            };

            var resourcePath = "api/v2/access_token/wechat";
            
            return await ConfigureAndExecute<AccessToken>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// The API is used to get LoginRadius access token by sending Vkontakte's access token. It will be valid for the specific duration of time specified in the response.
        /// </summary>
        /// <param name="vkAccessToken">Vkontakte Access Token</param>
        /// <returns>Response containing Definition of Complete Token data</returns>
        /// 20.15

        public async Task<ApiResponse<AccessToken>> GetAccessTokenByVkontakteAccessToken(string vkAccessToken)
        {
            if (string.IsNullOrWhiteSpace(vkAccessToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(vkAccessToken));
            }
            var queryParameters = new QueryParameters
            {
                { "key", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "vk_access_token", vkAccessToken }
            };

            var resourcePath = "api/v2/access_token/vkontakte";
            
            return await ConfigureAndExecute<AccessToken>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// The API is used to get LoginRadius access token by sending Google's AuthCode. It will be valid for the specific duration of time specified in the response.
        /// </summary>
        /// <param name="googleAuthcode">Google AuthCode</param>
        /// <param name="socialAppName">Name of Social provider APP</param>
        /// <returns>Response containing Definition of Complete Token data</returns>
        /// 20.16

        public async Task<ApiResponse<AccessToken>> GetAccessTokenByGoogleAuthCode(string googleAuthcode, string socialAppName = null)
        {
            if (string.IsNullOrWhiteSpace(googleAuthcode))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(googleAuthcode));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "google_authcode", googleAuthcode }
            };
            if (!string.IsNullOrWhiteSpace(socialAppName))
            {
               queryParameters.Add("socialAppName", socialAppName);
            }

            var resourcePath = "api/v2/access_token/google";
            
            return await ConfigureAndExecute<AccessToken>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
    }
}