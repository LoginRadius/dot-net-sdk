//-----------------------------------------------------------------------
// <copyright file="PINAuthenticationApi.cs" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2019 LoginRadius Inc. All rights reserved.
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
    public class PINAuthenticationApi : LoginRadiusResource
    {
        /// <summary>
        /// This API is used to login a user by pin and session token.
        /// </summary>
        /// <param name="loginByPINModel">Model Class containing Definition of payload for LoginByPin API</param>
        /// <param name="sessionToken">Session Token of user</param>
        /// <returns>Response containing User Profile Data and access token</returns>
        /// 9.22

        public async Task<ApiResponse<AccessToken<Identity>>> PINLogin(LoginByPINModel loginByPINModel, string sessionToken)
        {
            if (loginByPINModel == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(loginByPINModel));
            }
            if (string.IsNullOrWhiteSpace(sessionToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(sessionToken));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "session_token", sessionToken }
            };

            var resourcePath = "identity/v2/auth/login/pin";
            
            return await ConfigureAndExecute<AccessToken<Identity>>(HttpMethod.POST, resourcePath, queryParameters, ConvertToJson(loginByPINModel));
        }
        /// <summary>
        /// This API sends the reset pin email to specified email address.
        /// </summary>
        /// <param name="forgotPINLinkByEmailModel">Model Class containing Definition for Forgot Pin Link By Email API</param>
        /// <param name="emailTemplate">Email template name</param>
        /// <param name="resetPINUrl">Reset PIN Url</param>
        /// <returns>Response containing Definition of Complete Validation data</returns>
        /// 42.1

        public async Task<ApiResponse<PostResponse>> SendForgotPINEmailByEmail(ForgotPINLinkByEmailModel forgotPINLinkByEmailModel, string emailTemplate = null,
        string resetPINUrl = null)
        {
            if (forgotPINLinkByEmailModel == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(forgotPINLinkByEmailModel));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] }
            };
            if (!string.IsNullOrWhiteSpace(emailTemplate))
            {
               queryParameters.Add("emailTemplate", emailTemplate);
            }
            if (!string.IsNullOrWhiteSpace(resetPINUrl))
            {
               queryParameters.Add("resetPINUrl", resetPINUrl);
            }

            var resourcePath = "identity/v2/auth/pin/forgot/email";
            
            return await ConfigureAndExecute<PostResponse>(HttpMethod.POST, resourcePath, queryParameters, ConvertToJson(forgotPINLinkByEmailModel));
        }
        /// <summary>
        /// This API sends the reset pin email using username.
        /// </summary>
        /// <param name="forgotPINLinkByUserNameModel">Model Class containing Definition for Forgot Pin Link By UserName API</param>
        /// <param name="emailTemplate">Email template name</param>
        /// <param name="resetPINUrl">Reset PIN Url</param>
        /// <returns>Response containing Definition of Complete Validation data</returns>
        /// 42.2

        public async Task<ApiResponse<PostResponse>> SendForgotPINEmailByUsername(ForgotPINLinkByUserNameModel forgotPINLinkByUserNameModel, string emailTemplate = null,
        string resetPINUrl = null)
        {
            if (forgotPINLinkByUserNameModel == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(forgotPINLinkByUserNameModel));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] }
            };
            if (!string.IsNullOrWhiteSpace(emailTemplate))
            {
               queryParameters.Add("emailTemplate", emailTemplate);
            }
            if (!string.IsNullOrWhiteSpace(resetPINUrl))
            {
               queryParameters.Add("resetPINUrl", resetPINUrl);
            }

            var resourcePath = "identity/v2/auth/pin/forgot/username";
            
            return await ConfigureAndExecute<PostResponse>(HttpMethod.POST, resourcePath, queryParameters, ConvertToJson(forgotPINLinkByUserNameModel));
        }
        /// <summary>
        /// This API is used to reset pin using reset token.
        /// </summary>
        /// <param name="resetPINByResetToken">Model Class containing Definition of payload for Reset Pin By Reset Token API</param>
        /// <returns>Response containing Definition of Complete Validation data</returns>
        /// 42.3

        public async Task<ApiResponse<PostResponse>> ResetPINByResetToken(ResetPINByResetToken resetPINByResetToken)
        {
            if (resetPINByResetToken == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(resetPINByResetToken));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] }
            };

            var resourcePath = "identity/v2/auth/pin/reset/token";
            
            return await ConfigureAndExecute<PostResponse>(HttpMethod.PUT, resourcePath, queryParameters, ConvertToJson(resetPINByResetToken));
        }
        /// <summary>
        /// This API is used to reset pin using security question answer and email.
        /// </summary>
        /// <param name="resetPINBySecurityQuestionAnswerAndEmailModel">Model Class containing Definition of payload for Reset Pin By Security Question and Email API</param>
        /// <returns>Response containing Definition of Complete Validation data</returns>
        /// 42.4

        public async Task<ApiResponse<PostResponse>> ResetPINByEmailAndSecurityAnswer(ResetPINBySecurityQuestionAnswerAndEmailModel resetPINBySecurityQuestionAnswerAndEmailModel)
        {
            if (resetPINBySecurityQuestionAnswerAndEmailModel == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(resetPINBySecurityQuestionAnswerAndEmailModel));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] }
            };

            var resourcePath = "identity/v2/auth/pin/reset/securityanswer/email";
            
            return await ConfigureAndExecute<PostResponse>(HttpMethod.PUT, resourcePath, queryParameters, ConvertToJson(resetPINBySecurityQuestionAnswerAndEmailModel));
        }
        /// <summary>
        /// This API is used to reset pin using security question answer and username.
        /// </summary>
        /// <param name="resetPINBySecurityQuestionAnswerAndUsernameModel">Model Class containing Definition of payload for Reset Pin By Security Question and UserName API</param>
        /// <returns>Response containing Definition of Complete Validation data</returns>
        /// 42.5

        public async Task<ApiResponse<PostResponse>> ResetPINByUsernameAndSecurityAnswer(ResetPINBySecurityQuestionAnswerAndUsernameModel resetPINBySecurityQuestionAnswerAndUsernameModel)
        {
            if (resetPINBySecurityQuestionAnswerAndUsernameModel == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(resetPINBySecurityQuestionAnswerAndUsernameModel));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] }
            };

            var resourcePath = "identity/v2/auth/pin/reset/securityanswer/username";
            
            return await ConfigureAndExecute<PostResponse>(HttpMethod.PUT, resourcePath, queryParameters, ConvertToJson(resetPINBySecurityQuestionAnswerAndUsernameModel));
        }
        /// <summary>
        /// This API is used to reset pin using security question answer and phone.
        /// </summary>
        /// <param name="resetPINBySecurityQuestionAnswerAndPhoneModel">Model Class containing Definition of payload for Reset Pin By Security Question and Phone API</param>
        /// <returns>Response containing Definition of Complete Validation data</returns>
        /// 42.6

        public async Task<ApiResponse<PostResponse>> ResetPINByPhoneAndSecurityAnswer(ResetPINBySecurityQuestionAnswerAndPhoneModel resetPINBySecurityQuestionAnswerAndPhoneModel)
        {
            if (resetPINBySecurityQuestionAnswerAndPhoneModel == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(resetPINBySecurityQuestionAnswerAndPhoneModel));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] }
            };

            var resourcePath = "identity/v2/auth/pin/reset/securityanswer/phone";
            
            return await ConfigureAndExecute<PostResponse>(HttpMethod.PUT, resourcePath, queryParameters, ConvertToJson(resetPINBySecurityQuestionAnswerAndPhoneModel));
        }
        /// <summary>
        /// This API sends the OTP to specified phone number
        /// </summary>
        /// <param name="forgotPINOtpByPhoneModel">Model Class containing Definition for Forgot Pin Otp By Phone API</param>
        /// <param name="smsTemplate"></param>
        /// <returns>Response Containing Validation Data and SMS Data</returns>
        /// 42.7

        public async Task<ApiResponse<UserProfilePostResponse<SMSResponseData>>> SendForgotPINSMSByPhone(ForgotPINOtpByPhoneModel forgotPINOtpByPhoneModel, string smsTemplate = null)
        {
            if (forgotPINOtpByPhoneModel == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(forgotPINOtpByPhoneModel));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] }
            };
            if (!string.IsNullOrWhiteSpace(smsTemplate))
            {
               queryParameters.Add("smsTemplate", smsTemplate);
            }

            var resourcePath = "identity/v2/auth/pin/forgot/otp";
            
            return await ConfigureAndExecute<UserProfilePostResponse<SMSResponseData>>(HttpMethod.POST, resourcePath, queryParameters, ConvertToJson(forgotPINOtpByPhoneModel));
        }
        /// <summary>
        /// This API is used to change a user's PIN using access token.
        /// </summary>
        /// <param name="accessToken">Uniquely generated identifier key by LoginRadius that is activated after successful authentication.</param>
        /// <param name="changePINModel">Model Class containing Definition for change PIN Property</param>
        /// <returns>Response containing Definition of Complete Validation data</returns>
        /// 42.8

        public async Task<ApiResponse<PostResponse>> ChangePINByAccessToken(string accessToken, ChangePINModel changePINModel)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(accessToken));
            }
            if (changePINModel == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(changePINModel));
            }
            var queryParameters = new QueryParameters
            {
                { "access_token", accessToken },
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] }
            };

            var resourcePath = "identity/v2/auth/pin/change";
            
            return await ConfigureAndExecute<PostResponse>(HttpMethod.PUT, resourcePath, queryParameters, ConvertToJson(changePINModel));
        }
        /// <summary>
        /// This API is used to reset pin using phoneId and OTP.
        /// </summary>
        /// <param name="resetPINByPhoneAndOTPModel">Model Class containing Definition of payload for Reset Pin By Phone and Otp API</param>
        /// <returns>Response containing Definition of Complete Validation data</returns>
        /// 42.9

        public async Task<ApiResponse<PostResponse>> ResetPINByPhoneAndOtp(ResetPINByPhoneAndOTPModel resetPINByPhoneAndOTPModel)
        {
            if (resetPINByPhoneAndOTPModel == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(resetPINByPhoneAndOTPModel));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] }
            };

            var resourcePath = "identity/v2/auth/pin/reset/otp/phone";
            
            return await ConfigureAndExecute<PostResponse>(HttpMethod.PUT, resourcePath, queryParameters, ConvertToJson(resetPINByPhoneAndOTPModel));
        }
        /// <summary>
        /// This API is used to reset pin using email and OTP.
        /// </summary>
        /// <param name="resetPINByEmailAndOtpModel">Model Class containing Definition of payload for Reset Pin By Email and Otp API</param>
        /// <returns>Response containing Definition of Complete Validation data</returns>
        /// 42.10

        public async Task<ApiResponse<PostResponse>> ResetPINByEmailAndOtp(ResetPINByEmailAndOtpModel resetPINByEmailAndOtpModel)
        {
            if (resetPINByEmailAndOtpModel == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(resetPINByEmailAndOtpModel));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] }
            };

            var resourcePath = "identity/v2/auth/pin/reset/otp/email";
            
            return await ConfigureAndExecute<PostResponse>(HttpMethod.PUT, resourcePath, queryParameters, ConvertToJson(resetPINByEmailAndOtpModel));
        }
        /// <summary>
        /// This API is used to reset pin using username and OTP.
        /// </summary>
        /// <param name="resetPINByUsernameAndOtpModel">Model Class containing Definition of payload for Reset Pin By Username and Otp API</param>
        /// <returns>Response containing Definition of Complete Validation data</returns>
        /// 42.11

        public async Task<ApiResponse<PostResponse>> ResetPINByUsernameAndOtp(ResetPINByUsernameAndOtpModel resetPINByUsernameAndOtpModel)
        {
            if (resetPINByUsernameAndOtpModel == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(resetPINByUsernameAndOtpModel));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] }
            };

            var resourcePath = "identity/v2/auth/pin/reset/otp/username";
            
            return await ConfigureAndExecute<PostResponse>(HttpMethod.PUT, resourcePath, queryParameters, ConvertToJson(resetPINByUsernameAndOtpModel));
        }
        /// <summary>
        /// This API is used to change a user's PIN using Pin Auth token.
        /// </summary>
        /// <param name="pINRequiredModel">Model Class containing Definition for PIN</param>
        /// <param name="pinAuthToken">Pin Auth Token</param>
        /// <returns>Response containing User Profile Data and access token</returns>
        /// 42.12

        public async Task<ApiResponse<AccessToken<Identity>>> SetPINByPinAuthToken(PINRequiredModel pINRequiredModel, string pinAuthToken)
        {
            if (pINRequiredModel == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(pINRequiredModel));
            }
            if (string.IsNullOrWhiteSpace(pinAuthToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(pinAuthToken));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "pinAuthToken", pinAuthToken }
            };

            var resourcePath = "identity/v2/auth/pin/set/pinauthtoken";
            
            return await ConfigureAndExecute<AccessToken<Identity>>(HttpMethod.POST, resourcePath, queryParameters, ConvertToJson(pINRequiredModel));
        }
        /// <summary>
        /// This API is used to invalidate pin session token.
        /// </summary>
        /// <param name="sessionToken">Session Token of user</param>
        /// <returns>Response containing Definition of Complete Validation data</returns>
        /// 44.1

        public async Task<ApiResponse<PostResponse>> InValidatePinSessionToken(string sessionToken)
        {
            if (string.IsNullOrWhiteSpace(sessionToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(sessionToken));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "session_token", sessionToken }
            };

            var resourcePath = "identity/v2/auth/session_token/invalidate";
            
            return await ConfigureAndExecute<PostResponse>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
    }
}