//-----------------------------------------------------------------------
// <copyright file="OneTouchLoginApi.cs" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2019 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using LoginRadiusSDK.V2.Common;
using LoginRadiusSDK.V2.Util;
using LoginRadiusSDK.V2.Models.ResponseModels.OtherObjects;
using LoginRadiusSDK.V2.Models.RequestModels;
using LoginRadiusSDK.V2.Models.ResponseModels;
using LoginRadiusSDK.V2.Models.ResponseModels.UserProfile;

namespace LoginRadiusSDK.V2.Api.Authentication
{
    public class OneTouchLoginApi : LoginRadiusResource
    {
        /// <summary>
        /// This API is used to send a link to a specified email for a frictionless login/registration
        /// </summary>
        /// <param name="oneTouchLoginByEmailModel">Model Class containing Definition of payload for OneTouchLogin By EmailModel API</param>
        /// <param name="oneTouchLoginEmailTemplate">Name of the One Touch Login Email Template</param>
        /// <param name="redirecturl">Url where the user will redirect after success authentication</param>
        /// <param name="welcomeemailtemplate">Name of the welcome email template</param>
        /// <returns>Response containing Definition of Complete Validation data</returns>
        /// 1.2

        public ApiResponse<PostResponse> OneTouchLoginByEmail(OneTouchLoginByEmailModel oneTouchLoginByEmailModel, string oneTouchLoginEmailTemplate = null,
        string redirecturl = null, string welcomeemailtemplate = null)
        {
            if (oneTouchLoginByEmailModel == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(oneTouchLoginByEmailModel));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] }
            };
            if (!string.IsNullOrWhiteSpace(oneTouchLoginEmailTemplate))
            {
               queryParameters.Add("oneTouchLoginEmailTemplate", oneTouchLoginEmailTemplate);
            }
            if (!string.IsNullOrWhiteSpace(redirecturl))
            {
               queryParameters.Add("redirecturl", redirecturl);
            }
            if (!string.IsNullOrWhiteSpace(welcomeemailtemplate))
            {
               queryParameters.Add("welcomeemailtemplate", welcomeemailtemplate);
            }

            var resourcePath = "identity/v2/auth/onetouchlogin/email";
            
            return ConfigureAndExecute<PostResponse>(HttpMethod.POST, resourcePath, queryParameters, ConvertToJson(oneTouchLoginByEmailModel));
        }
        /// <summary>
        /// This API is used to send one time password to a given phone number for a frictionless login/registration.
        /// </summary>
        /// <param name="oneTouchLoginByPhoneModel">Model Class containing Definition of payload for OneTouchLogin By PhoneModel API</param>
        /// <param name="smsTemplate">SMS Template name</param>
        /// <returns>Response containing Definition of Complete Validation data</returns>
        /// 1.4

        public ApiResponse<PostResponse> OneTouchLoginByPhone(OneTouchLoginByPhoneModel oneTouchLoginByPhoneModel, string smsTemplate = null)
        {
            if (oneTouchLoginByPhoneModel == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(oneTouchLoginByPhoneModel));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] }
            };
            if (!string.IsNullOrWhiteSpace(smsTemplate))
            {
               queryParameters.Add("smsTemplate", smsTemplate);
            }

            var resourcePath = "identity/v2/auth/onetouchlogin/phone";
            
            return ConfigureAndExecute<PostResponse>(HttpMethod.POST, resourcePath, queryParameters, ConvertToJson(oneTouchLoginByPhoneModel));
        }
        /// <summary>
        /// This API is used to verify the otp for One Touch Login.
        /// </summary>
        /// <param name="otp">The Verification Code</param>
        /// <param name="phone">New Phone Number</param>
        /// <param name="fields">The fields parameter filters the API response so that the response only includes a specific set of fields</param>
        /// <param name="smsTemplate">SMS Template name</param>
        /// <returns>Response Containing Access Token and Complete Profile Data</returns>
        /// 1.5

        public ApiResponse<AccessToken<UserProfile>> OneTouchLoginOTPVerification(string otp, string phone,
        string fields = "", string smsTemplate = null)
        {
            if (string.IsNullOrWhiteSpace(otp))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(otp));
            }
            if (string.IsNullOrWhiteSpace(phone))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(phone));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "otp", otp }
            };
            if (!string.IsNullOrWhiteSpace(fields))
            {
               queryParameters.Add("fields", fields);
            }
            if (!string.IsNullOrWhiteSpace(smsTemplate))
            {
               queryParameters.Add("smsTemplate", smsTemplate);
            }

            var bodyParameters = new BodyParameters
            {
                { "phone", phone }
            };

            var resourcePath = "identity/v2/auth/onetouchlogin/phone/verify";
            
            return ConfigureAndExecute<AccessToken<UserProfile>>(HttpMethod.PUT, resourcePath, queryParameters, ConvertToJson(bodyParameters));
        }
        /// <summary>
        /// This API verifies the provided token for One Touch Login
        /// </summary>
        /// <param name="verificationToken">Verification token received in the email</param>
        /// <param name="welcomeEmailTemplate">Name of the welcome email template</param>
        /// <returns>Complete verified response data</returns>
        /// 8.4.2

        public ApiResponse<VerifiedResponse> OneTouchEmailVerification(string verificationToken, string welcomeEmailTemplate = null)
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

            var resourcePath = "identity/v2/auth/email/onetouchlogin";
            
            return ConfigureAndExecute<VerifiedResponse>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// This API is used to check if the One Touch Login link has been clicked or not.
        /// </summary>
        /// <param name="clientGuid">Unique string used in the Smart Login request</param>
        /// <param name="fields">The fields parameter filters the API response so that the response only includes a specific set of fields</param>
        /// <returns>Response containing User Profile Data and access token</returns>
        /// 9.21.2

        public ApiResponse<AccessToken<Identity>> OneTouchLoginPing(string clientGuid, string fields = "")
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