//-----------------------------------------------------------------------
// <copyright file="SocialApi.cs" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2025 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using LoginRadiusSDK.V2.Common;
using System.Threading.Tasks;
using LoginRadiusSDK.V2.Util;
using LoginRadiusSDK.V2.Models.ResponseModels;

namespace LoginRadiusSDK.V2.Api.Social
{
    public class SocialApi : LoginRadiusResource
    {
        /// <summary>
        /// This API Is used to translate the Request Token returned during authentication into an Access Token that can be used with other API calls.
        /// </summary>
        /// <param name="token">Token generated from a successful oauth from social platform</param>
        /// <returns>Response containing Definition of Complete Token data</returns>
        /// 20.1

        public async Task<ApiResponse<AccessToken>> ExchangeAccessToken(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(token));
            }
            var queryParameters = new QueryParameters
            {
                { "secret", ConfigDictionary[LRConfigConstants.LoginRadiusApiSecret] },
                { "token", token }
            };

            var resourcePath = "api/v2/access_token";
            
            return await ConfigureAndExecute<AccessToken>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// The Refresh Access Token API is used to refresh the provider access token after authentication. It will be valid for up to 60 days on LoginRadius depending on the provider. In order to use the access token in other APIs, always refresh the token using this API.<br><br><b>Supported Providers :</b> Facebook,Yahoo,Google,Twitter, Linkedin.<br><br> Contact LoginRadius support team to enable this API.
        /// </summary>
        /// <param name="accessToken">Uniquely generated identifier key by LoginRadius that is activated after successful authentication.</param>
        /// <param name="expiresIn">Allows you to specify a desired expiration time in minutes for the newly issued access token.</param>
        /// <param name="isWeb">Is web or not.</param>
        /// <returns>Response containing Definition of Complete Token data</returns>
        /// 20.2

        public async Task<ApiResponse<AccessToken>> RefreshAccessToken(string accessToken, int? expiresIn = 0,
        bool isWeb = false)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(accessToken));
            }
            var queryParameters = new QueryParameters
            {
                { "access_token", accessToken },
                { "secret", ConfigDictionary[LRConfigConstants.LoginRadiusApiSecret] }
            };
            if (expiresIn != null)
            {
               queryParameters.Add("expiresIn", expiresIn.ToString());
            }
            if (isWeb != false)
            {
               queryParameters.Add("isWeb", isWeb.ToString());
            }

            var resourcePath = "api/v2/access_token/refresh";
            
            return await ConfigureAndExecute<AccessToken>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// This API validates access token, if valid then returns a response with its expiry otherwise error.
        /// </summary>
        /// <param name="accessToken">Uniquely generated identifier key by LoginRadius that is activated after successful authentication.</param>
        /// <returns>Response containing Definition of Complete Token data</returns>
        /// 20.9

        public async Task<ApiResponse<AccessToken>> ValidateAccessToken(string accessToken)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(accessToken));
            }
            var queryParameters = new QueryParameters
            {
                { "access_token", accessToken },
                { "key", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "secret", ConfigDictionary[LRConfigConstants.LoginRadiusApiSecret] }
            };

            var resourcePath = "api/v2/access_token/validate";
            
            return await ConfigureAndExecute<AccessToken>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// This api invalidates the active access token or expires an access token validity.
        /// </summary>
        /// <param name="accessToken">Uniquely generated identifier key by LoginRadius that is activated after successful authentication.</param>
        /// <returns>Response containing Definition for Complete Validation data</returns>
        /// 20.10

        public async Task<ApiResponse<PostMethodResponse>> InValidateAccessToken(string accessToken)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(accessToken));
            }
            var queryParameters = new QueryParameters
            {
                { "access_token", accessToken },
                { "key", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "secret", ConfigDictionary[LRConfigConstants.LoginRadiusApiSecret] }
            };

            var resourcePath = "api/v2/access_token/invalidate";
            
            return await ConfigureAndExecute<PostMethodResponse>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// This api is use to get all active session by Access Token.
        /// </summary>
        /// <param name="token">Token generated from a successful oauth from social platform</param>
        /// <returns>Response containing Definition for Complete active sessions</returns>
        /// 20.11.1

        public async Task<ApiResponse<UserActiveSession>> GetActiveSession(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(token));
            }
            var queryParameters = new QueryParameters
            {
                { "key", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "secret", ConfigDictionary[LRConfigConstants.LoginRadiusApiSecret] },
                { "token", token }
            };

            var resourcePath = "api/v2/access_token/activesession";
            
            return await ConfigureAndExecute<UserActiveSession>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// This api is used to get all active sessions by AccountID(UID).
        /// </summary>
        /// <param name="accountId">UID, the unified identifier for each user account</param>
        /// <returns>Response containing Definition for Complete active sessions</returns>
        /// 20.11.2

        public async Task<ApiResponse<UserActiveSession>> GetActiveSessionByAccountID(string accountId)
        {
            if (string.IsNullOrWhiteSpace(accountId))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(accountId));
            }
            var queryParameters = new QueryParameters
            {
                { "accountId", accountId },
                { "key", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "secret", ConfigDictionary[LRConfigConstants.LoginRadiusApiSecret] }
            };

            var resourcePath = "api/v2/access_token/activesession";
            
            return await ConfigureAndExecute<UserActiveSession>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// This api is used to get all active sessions by ProfileId.
        /// </summary>
        /// <param name="profileId">Social Provider Id</param>
        /// <returns>Response containing Definition for Complete active sessions</returns>
        /// 20.11.3

        public async Task<ApiResponse<UserActiveSession>> GetActiveSessionByProfileID(string profileId)
        {
            if (string.IsNullOrWhiteSpace(profileId))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(profileId));
            }
            var queryParameters = new QueryParameters
            {
                { "key", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "profileId", profileId },
                { "secret", ConfigDictionary[LRConfigConstants.LoginRadiusApiSecret] }
            };

            var resourcePath = "api/v2/access_token/activesession";
            
            return await ConfigureAndExecute<UserActiveSession>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
    }
}