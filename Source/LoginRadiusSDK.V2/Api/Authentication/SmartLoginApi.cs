//-----------------------------------------------------------------------
// <copyright file="SmartLoginApi.cs" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2019 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using LoginRadiusSDK.V2.Common;
using LoginRadiusSDK.V2.Util;
using LoginRadiusSDK.V2.Models.ResponseModels.OtherObjects;
using LoginRadiusSDK.V2.Models.ResponseModels;
using LoginRadiusSDK.V2.Models.ResponseModels.UserProfile;

namespace LoginRadiusSDK.V2.Api.Authentication
{
    public class SmartLoginApi : LoginRadiusResource
    {
        /// <summary>
        /// This API verifies the provided token for Smart Login
        /// </summary>
        /// <param name="verificationToken">Verification token received in the email</param>
        /// <param name="welcomeEmailTemplate">Name of the welcome email template</param>
        /// <returns>Complete verified response data</returns>
        /// 8.4.1

        public ApiResponse<VerifiedResponse> SmartLoginTokenVerification(string verificationToken, string welcomeEmailTemplate = null)
        {
            if (string.IsNullOrWhiteSpace(verificationToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(verificationToken));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "verificationToken", verificationToken }
            };
            if (!string.IsNullOrWhiteSpace(welcomeEmailTemplate))
            {
               queryParameters.Add("welcomeEmailTemplate", welcomeEmailTemplate);
            }

            var resourcePath = "identity/v2/auth/email/smartlogin";
            
            return ConfigureAndExecute<VerifiedResponse>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// This API sends a Smart Login link to the user's Email Id.
        /// </summary>
        /// <param name="clientGuid">Unique string used in the Smart Login request</param>
        /// <param name="email">Email of the user</param>
        /// <param name="redirectUrl">Url where the user will redirect after success authentication</param>
        /// <param name="smartLoginEmailTemplate">Email template for Smart Login link</param>
        /// <param name="welcomeEmailTemplate">Name of the welcome email template</param>
        /// <returns>Response containing Definition of Complete Validation data</returns>
        /// 9.17.1

        public ApiResponse<PostResponse> SmartLoginByEmail(string clientGuid, string email,
        string redirectUrl = null, string smartLoginEmailTemplate = null, string welcomeEmailTemplate = null)
        {
            if (string.IsNullOrWhiteSpace(clientGuid))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(clientGuid));
            }
            if (string.IsNullOrWhiteSpace(email))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(email));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "clientGuid", clientGuid },
                { "email", email }
            };
            if (!string.IsNullOrWhiteSpace(redirectUrl))
            {
               queryParameters.Add("redirectUrl", redirectUrl);
            }
            if (!string.IsNullOrWhiteSpace(smartLoginEmailTemplate))
            {
               queryParameters.Add("smartLoginEmailTemplate", smartLoginEmailTemplate);
            }
            if (!string.IsNullOrWhiteSpace(welcomeEmailTemplate))
            {
               queryParameters.Add("welcomeEmailTemplate", welcomeEmailTemplate);
            }

            var resourcePath = "identity/v2/auth/login/smartlogin";
            
            return ConfigureAndExecute<PostResponse>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// This API sends a Smart Login link to the user's Email Id.
        /// </summary>
        /// <param name="clientGuid">Unique string used in the Smart Login request</param>
        /// <param name="username">UserName of the user</param>
        /// <param name="redirectUrl">Url where the user will redirect after success authentication</param>
        /// <param name="smartLoginEmailTemplate">Email template for Smart Login link</param>
        /// <param name="welcomeEmailTemplate">Name of the welcome email template</param>
        /// <returns>Response containing Definition of Complete Validation data</returns>
        /// 9.17.2

        public ApiResponse<PostResponse> SmartLoginByUserName(string clientGuid, string username,
        string redirectUrl = null, string smartLoginEmailTemplate = null, string welcomeEmailTemplate = null)
        {
            if (string.IsNullOrWhiteSpace(clientGuid))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(clientGuid));
            }
            if (string.IsNullOrWhiteSpace(username))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(username));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "clientGuid", clientGuid },
                { "username", username }
            };
            if (!string.IsNullOrWhiteSpace(redirectUrl))
            {
               queryParameters.Add("redirectUrl", redirectUrl);
            }
            if (!string.IsNullOrWhiteSpace(smartLoginEmailTemplate))
            {
               queryParameters.Add("smartLoginEmailTemplate", smartLoginEmailTemplate);
            }
            if (!string.IsNullOrWhiteSpace(welcomeEmailTemplate))
            {
               queryParameters.Add("welcomeEmailTemplate", welcomeEmailTemplate);
            }

            var resourcePath = "identity/v2/auth/login/smartlogin";
            
            return ConfigureAndExecute<PostResponse>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// This API is used to check if the Smart Login link has been clicked or not
        /// </summary>
        /// <param name="clientGuid">Unique string used in the Smart Login request</param>
        /// <param name="fields">The fields parameter filters the API response so that the response only includes a specific set of fields</param>
        /// <returns>Response containing User Profile Data and access token</returns>
        /// 9.21.1

        public ApiResponse<AccessToken<Identity>> SmartLoginPing(string clientGuid, string fields = "")
        {
            if (string.IsNullOrWhiteSpace(clientGuid))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(clientGuid));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "clientGuid", clientGuid }
            };
            if (!string.IsNullOrWhiteSpace(fields))
            {
               queryParameters.Add("fields", fields);
            }

            var resourcePath = "identity/v2/auth/login/smartlogin/ping";
            
            return ConfigureAndExecute<AccessToken<Identity>>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
    }
}