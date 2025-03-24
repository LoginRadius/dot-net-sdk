//-----------------------------------------------------------------------
// <copyright file="PasswordLessLoginApi.cs" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2025 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using LoginRadiusSDK.V2.Common;
using System.Threading.Tasks;
using LoginRadiusSDK.V2.Util;
using LoginRadiusSDK.V2.Models.ResponseModels;
using LoginRadiusSDK.V2.Models.ResponseModels.UserProfile;
using LoginRadiusSDK.V2.Models.RequestModels;
using LoginRadiusSDK.V2.Models.ResponseModels.OtherObjects;

namespace LoginRadiusSDK.V2.Api.Authentication
{
    public class PasswordLessLoginApi : LoginRadiusResource
    {
        /// <summary>
        /// This API verifies an account by OTP and allows the customer to login.
        /// </summary>
        /// <param name="passwordLessLoginOtpModel">Model Class containing Definition of payload for PasswordLessLoginOtpModel API</param>
        /// <param name="fields">The fields parameter filters the API response so that the response only includes a specific set of fields</param>
        /// <param name="smsTemplate">SMS Template name</param>
        /// <param name="isVoiceOtp">Boolean, pass true if you wish to trigger voice OTP</param>
        /// <returns>Response containing User Profile Data and access token</returns>
        /// 9.6

        public async Task<ApiResponse<AccessToken<Identity>>> PasswordlessLoginPhoneVerification(PasswordLessLoginOtpModel passwordLessLoginOtpModel, string fields = "",
        string smsTemplate = null, bool isVoiceOtp = false)
        {
            if (passwordLessLoginOtpModel == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(passwordLessLoginOtpModel));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] }
            };
            if (!string.IsNullOrWhiteSpace(fields))
            {
               queryParameters.Add("fields", fields);
            }
            if (!string.IsNullOrWhiteSpace(smsTemplate))
            {
               queryParameters.Add("smsTemplate", smsTemplate);
            }
            if (isVoiceOtp != false)
            {
               queryParameters.Add("isVoiceOtp", isVoiceOtp.ToString());
            }

            var resourcePath = "identity/v2/auth/login/passwordlesslogin/otp/verify";
            
            return await ConfigureAndExecute<AccessToken<Identity>>(HttpMethod.PUT, resourcePath, queryParameters, ConvertToJson(passwordLessLoginOtpModel));
        }
        /// <summary>
        /// API can be used to send a One-time Passcode (OTP) provided that the account has a verified PhoneID
        /// </summary>
        /// <param name="phone">The Registered Phone Number</param>
        /// <param name="smsTemplate">SMS Template name</param>
        /// <param name="isVoiceOtp">Boolean, pass true if you wish to trigger voice OTP</param>
        /// <returns>Response Containing Definition of SMS Data</returns>
        /// 9.15

        public async Task<ApiResponse<GetResponse<SmsResponseData>>> PasswordlessLoginByPhone(string phone, string smsTemplate = null,
        bool isVoiceOtp = false)
        {
            if (string.IsNullOrWhiteSpace(phone))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(phone));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "phone", phone }
            };
            if (!string.IsNullOrWhiteSpace(smsTemplate))
            {
               queryParameters.Add("smsTemplate", smsTemplate);
            }
            if (isVoiceOtp != false)
            {
               queryParameters.Add("isVoiceOtp", isVoiceOtp.ToString());
            }

            var resourcePath = "identity/v2/auth/login/passwordlesslogin/otp";
            
            return await ConfigureAndExecute<GetResponse<SmsResponseData>>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// This API is used to send a Passwordless Login verification link to the provided Email ID
        /// </summary>
        /// <param name="email">Email of the user</param>
        /// <param name="passwordLessLoginTemplate">Passwordless Login Template Name</param>
        /// <param name="verificationUrl">Email verification url</param>
        /// <returns>Response containing Definition of Complete Validation data</returns>
        /// 9.18.1

        public async Task<ApiResponse<PostResponse>> PasswordlessLoginByEmail(string email, string passwordLessLoginTemplate = null,
        string verificationUrl = null)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(email));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "email", email }
            };
            if (!string.IsNullOrWhiteSpace(passwordLessLoginTemplate))
            {
               queryParameters.Add("passwordLessLoginTemplate", passwordLessLoginTemplate);
            }
            if (!string.IsNullOrWhiteSpace(verificationUrl))
            {
               queryParameters.Add("verificationUrl", verificationUrl);
            }

            var resourcePath = "identity/v2/auth/login/passwordlesslogin/email";
            
            return await ConfigureAndExecute<PostResponse>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// This API is used to send a Passwordless Login Verification Link to a customer by providing their UserName
        /// </summary>
        /// <param name="username">UserName of the user</param>
        /// <param name="passwordLessLoginTemplate">Passwordless Login Template Name</param>
        /// <param name="verificationUrl">Email verification url</param>
        /// <returns>Response containing Definition of Complete Validation data</returns>
        /// 9.18.2

        public async Task<ApiResponse<PostResponse>> PasswordlessLoginByUserName(string username, string passwordLessLoginTemplate = null,
        string verificationUrl = null)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(username));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "username", username }
            };
            if (!string.IsNullOrWhiteSpace(passwordLessLoginTemplate))
            {
               queryParameters.Add("passwordLessLoginTemplate", passwordLessLoginTemplate);
            }
            if (!string.IsNullOrWhiteSpace(verificationUrl))
            {
               queryParameters.Add("verificationUrl", verificationUrl);
            }

            var resourcePath = "identity/v2/auth/login/passwordlesslogin/email";
            
            return await ConfigureAndExecute<PostResponse>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// This API is used to verify the Passwordless Login verification link. Note: If you are using Passwordless Login by Phone you will need to use the Passwordless Login Phone Verification API
        /// </summary>
        /// <param name="verificationToken">Verification token received in the email</param>
        /// <param name="fields">The fields parameter filters the API response so that the response only includes a specific set of fields</param>
        /// <param name="welcomeEmailTemplate">Name of the welcome email template</param>
        /// <returns>Response containing User Profile Data and access token</returns>
        /// 9.19

        public async Task<ApiResponse<AccessToken<Identity>>> PasswordlessLoginVerification(string verificationToken, string fields = "",
        string welcomeEmailTemplate = null)
        {
            if (string.IsNullOrWhiteSpace(verificationToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(verificationToken));
            }
            var queryParameters = new QueryParameters
            {
                { "apikey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "verificationToken", verificationToken }
            };
            if (!string.IsNullOrWhiteSpace(fields))
            {
               queryParameters.Add("fields", fields);
            }
            if (!string.IsNullOrWhiteSpace(welcomeEmailTemplate))
            {
               queryParameters.Add("welcomeEmailTemplate", welcomeEmailTemplate);
            }

            var resourcePath = "identity/v2/auth/login/passwordlesslogin/email/verify";
            
            return await ConfigureAndExecute<AccessToken<Identity>>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// This API is used to verify the otp sent to the email when doing a passwordless login. 
        /// </summary>
        /// <param name="passwordLessLoginByEmailAndOtpModel">payload</param>
        /// <param name="fields">Fields</param>
        /// <returns>Response containing User Profile Data and access token</returns>
        /// 9.23

        public async Task<ApiResponse<AccessToken<Identity>>> PasswordlessLoginVerificationByEmailAndOTP(PasswordLessLoginByEmailAndOtpModel passwordLessLoginByEmailAndOtpModel, string fields = "")
        {
            if (passwordLessLoginByEmailAndOtpModel == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(passwordLessLoginByEmailAndOtpModel));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] }
            };
            if (!string.IsNullOrWhiteSpace(fields))
            {
               queryParameters.Add("fields", fields);
            }

            var resourcePath = "identity/v2/auth/login/passwordlesslogin/email/verifyotp";
            
            return await ConfigureAndExecute<AccessToken<Identity>>(HttpMethod.POST, resourcePath, queryParameters, ConvertToJson(passwordLessLoginByEmailAndOtpModel));
        }
        /// <summary>
        /// This API is used to verify the otp sent to the email when doing a passwordless login.
        /// </summary>
        /// <param name="passwordLessLoginByUserNameAndOtpModel">payload</param>
        /// <param name="fields">Fields</param>
        /// <returns>Response containing User Profile Data and access token</returns>
        /// 9.24

        public async Task<ApiResponse<AccessToken<Identity>>> PasswordlessLoginVerificationByUserNameAndOTP(PasswordLessLoginByUserNameAndOtpModel passwordLessLoginByUserNameAndOtpModel, string fields = "")
        {
            if (passwordLessLoginByUserNameAndOtpModel == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(passwordLessLoginByUserNameAndOtpModel));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] }
            };
            if (!string.IsNullOrWhiteSpace(fields))
            {
               queryParameters.Add("fields", fields);
            }

            var resourcePath = "identity/v2/auth/login/passwordlesslogin/username/verifyotp";
            
            return await ConfigureAndExecute<AccessToken<Identity>>(HttpMethod.POST, resourcePath, queryParameters, ConvertToJson(passwordLessLoginByUserNameAndOtpModel));
        }
    }
}