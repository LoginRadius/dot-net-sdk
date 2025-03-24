//-----------------------------------------------------------------------
// <copyright file="ReAuthenticationApi.cs" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2025 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using LoginRadiusSDK.V2.Common;
using System.Threading.Tasks;
using LoginRadiusSDK.V2.Util;
using LoginRadiusSDK.V2.Models.ResponseModels;
using LoginRadiusSDK.V2.Models.RequestModels;
using LoginRadiusSDK.V2.Models.ResponseModels.OtherObjects;

namespace LoginRadiusSDK.V2.Api.Advanced
{
    public class ReAuthenticationApi : LoginRadiusResource
    {
        /// <summary>
        /// This API is used to trigger the Multi-Factor Autentication workflow for the provided access token
        /// </summary>
        /// <param name="accessToken">Uniquely generated identifier key by LoginRadius that is activated after successful authentication.</param>
        /// <param name="smsTemplate2FA">SMS Template Name</param>
        /// <param name="isVoiceOtp">Boolean, pass true if you wish to trigger voice OTP</param>
        /// <returns>Response containing Definition of Complete Multi-Factor Authentication Settings data</returns>
        /// 14.3

        public async Task<ApiResponse<MultiFactorAuthenticationSettingsResponse>> MFAReAuthenticate(string accessToken, string smsTemplate2FA = null,
        bool isVoiceOtp = false)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(accessToken));
            }
            var queryParameters = new QueryParameters
            {
                { "access_token", accessToken },
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] }
            };
            if (!string.IsNullOrWhiteSpace(smsTemplate2FA))
            {
               queryParameters.Add("smsTemplate2FA", smsTemplate2FA);
            }
            if (isVoiceOtp != false)
            {
               queryParameters.Add("isVoiceOtp", isVoiceOtp.ToString());
            }

            var resourcePath = "identity/v2/auth/account/reauth/2fa";
            
            return await ConfigureAndExecute<MultiFactorAuthenticationSettingsResponse>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// This API is used to re-authenticate via Multi-factor authentication by passing the One Time Password received via SMS
        /// </summary>
        /// <param name="accessToken">Uniquely generated identifier key by LoginRadius that is activated after successful authentication.</param>
        /// <param name="reauthByOtpModel">Model Class containing Definition for MFA Reauthentication by OTP</param>
        /// <returns>Complete user Multi-Factor Authentication Token data</returns>
        /// 14.4

        public async Task<ApiResponse<EventBasedMultiFactorAuthenticationToken>> MFAReAuthenticateByOTP(string accessToken, ReauthByOtpModel reauthByOtpModel)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(accessToken));
            }
            if (reauthByOtpModel == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(reauthByOtpModel));
            }
            var queryParameters = new QueryParameters
            {
                { "access_token", accessToken },
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] }
            };

            var resourcePath = "identity/v2/auth/account/reauth/2fa/otp";
            
            return await ConfigureAndExecute<EventBasedMultiFactorAuthenticationToken>(HttpMethod.PUT, resourcePath, queryParameters, ConvertToJson(reauthByOtpModel));
        }
        /// <summary>
        /// This API is used to re-authenticate by set of backup codes via access token on the site that has Multi-factor authentication enabled in re-authentication for the user that does not have the device
        /// </summary>
        /// <param name="accessToken">Uniquely generated identifier key by LoginRadius that is activated after successful authentication.</param>
        /// <param name="reauthByBackupCodeModel">Model Class containing Definition for MFA Reauthentication by Backup code</param>
        /// <returns>Complete user Multi-Factor Authentication Token data</returns>
        /// 14.5

        public async Task<ApiResponse<EventBasedMultiFactorAuthenticationToken>> MFAReAuthenticateByBackupCode(string accessToken, ReauthByBackupCodeModel reauthByBackupCodeModel)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(accessToken));
            }
            if (reauthByBackupCodeModel == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(reauthByBackupCodeModel));
            }
            var queryParameters = new QueryParameters
            {
                { "access_token", accessToken },
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] }
            };

            var resourcePath = "identity/v2/auth/account/reauth/2fa/backupcode";
            
            return await ConfigureAndExecute<EventBasedMultiFactorAuthenticationToken>(HttpMethod.PUT, resourcePath, queryParameters, ConvertToJson(reauthByBackupCodeModel));
        }
        /// <summary>
        /// This API is used to re-authenticate via Multi-factor-authentication by passing the password
        /// </summary>
        /// <param name="accessToken">Uniquely generated identifier key by LoginRadius that is activated after successful authentication.</param>
        /// <param name="passwordEventBasedAuthModelWithLockout">Model Class containing Definition of payload for PasswordEventBasedAuthModel with Lockout API</param>
        /// <param name="smsTemplate2FA">SMS Template Name</param>
        /// <returns>Complete user Multi-Factor Authentication Token data</returns>
        /// 14.7

        public async Task<ApiResponse<EventBasedMultiFactorAuthenticationToken>> MFAReAuthenticateByPassword(string accessToken, PasswordEventBasedAuthModelWithLockout passwordEventBasedAuthModelWithLockout,
        string smsTemplate2FA = null)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(accessToken));
            }
            if (passwordEventBasedAuthModelWithLockout == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(passwordEventBasedAuthModelWithLockout));
            }
            var queryParameters = new QueryParameters
            {
                { "access_token", accessToken },
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] }
            };
            if (!string.IsNullOrWhiteSpace(smsTemplate2FA))
            {
               queryParameters.Add("smsTemplate2FA", smsTemplate2FA);
            }

            var resourcePath = "identity/v2/auth/account/reauth/password";
            
            return await ConfigureAndExecute<EventBasedMultiFactorAuthenticationToken>(HttpMethod.PUT, resourcePath, queryParameters, ConvertToJson(passwordEventBasedAuthModelWithLockout));
        }
        /// <summary>
        /// This API is used on the server-side to validate and verify the re-authentication token created by the MFA re-authentication API. This API checks re-authentications created by OTP.
        /// </summary>
        /// <param name="eventBasedMultiFactorToken">Model Class containing Definition for SecondFactorValidationToken</param>
        /// <param name="uid">UID, the unified identifier for each user account</param>
        /// <returns>Response containing Definition of Complete Validation data</returns>
        /// 18.38

        public async Task<ApiResponse<PostValidationResponse>> VerifyMultiFactorOtpReauthentication(EventBasedMultiFactorToken eventBasedMultiFactorToken, string uid)
        {
            if (eventBasedMultiFactorToken == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(eventBasedMultiFactorToken));
            }
            if (string.IsNullOrWhiteSpace(uid))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(uid));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "apiSecret", ConfigDictionary[LRConfigConstants.LoginRadiusApiSecret] }
            };

            var resourcePath = $"identity/v2/manage/account/{uid}/reauth/2fa";
            
            return await ConfigureAndExecute<PostValidationResponse>(HttpMethod.POST, resourcePath, queryParameters, ConvertToJson(eventBasedMultiFactorToken));
        }
        /// <summary>
        /// This API is used on the server-side to validate and verify the re-authentication token created by the MFA re-authentication API. This API checks re-authentications created by password.
        /// </summary>
        /// <param name="eventBasedMultiFactorToken">Model Class containing Definition for SecondFactorValidationToken</param>
        /// <param name="uid">UID, the unified identifier for each user account</param>
        /// <returns>Response containing Definition of Complete Validation data</returns>
        /// 18.39

        public async Task<ApiResponse<PostValidationResponse>> VerifyMultiFactorPasswordReauthentication(EventBasedMultiFactorToken eventBasedMultiFactorToken, string uid)
        {
            if (eventBasedMultiFactorToken == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(eventBasedMultiFactorToken));
            }
            if (string.IsNullOrWhiteSpace(uid))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(uid));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "apiSecret", ConfigDictionary[LRConfigConstants.LoginRadiusApiSecret] }
            };

            var resourcePath = $"identity/v2/manage/account/{uid}/reauth/password";
            
            return await ConfigureAndExecute<PostValidationResponse>(HttpMethod.POST, resourcePath, queryParameters, ConvertToJson(eventBasedMultiFactorToken));
        }
        /// <summary>
        /// This API is used on the server-side to validate and verify the re-authentication token created by the MFA re-authentication API. This API checks re-authentications created by PIN.
        /// </summary>
        /// <param name="eventBasedMultiFactorToken">Model Class containing Definition for SecondFactorValidationToken</param>
        /// <param name="uid">UID, the unified identifier for each user account</param>
        /// <returns>Response containing Definition of Complete Validation data</returns>
        /// 18.40

        public async Task<ApiResponse<PostValidationResponse>> VerifyMultiFactorPINReauthentication(EventBasedMultiFactorToken eventBasedMultiFactorToken, string uid)
        {
            if (eventBasedMultiFactorToken == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(eventBasedMultiFactorToken));
            }
            if (string.IsNullOrWhiteSpace(uid))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(uid));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "apiSecret", ConfigDictionary[LRConfigConstants.LoginRadiusApiSecret] }
            };

            var resourcePath = $"identity/v2/manage/account/{uid}/reauth/pin";
            
            return await ConfigureAndExecute<PostValidationResponse>(HttpMethod.POST, resourcePath, queryParameters, ConvertToJson(eventBasedMultiFactorToken));
        }
        /// <summary>
        /// This API is used to validate the triggered MFA authentication flow with a password.
        /// </summary>
        /// <param name="accessToken">Uniquely generated identifier key by LoginRadius that is activated after successful authentication.</param>
        /// <param name="pINAuthEventBasedAuthModelWithLockout">Model Class containing Definition of payload for PIN</param>
        /// <param name="smsTemplate2FA">SMS Template Name</param>
        /// <returns>Response containing Definition response of MFA reauthentication</returns>
        /// 42.13

        public async Task<ApiResponse<EventBasedMultiFactorAuthenticationToken>> VerifyPINAuthentication(string accessToken, PINAuthEventBasedAuthModelWithLockout pINAuthEventBasedAuthModelWithLockout,
        string smsTemplate2FA = null)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(accessToken));
            }
            if (pINAuthEventBasedAuthModelWithLockout == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(pINAuthEventBasedAuthModelWithLockout));
            }
            var queryParameters = new QueryParameters
            {
                { "access_token", accessToken },
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] }
            };
            if (!string.IsNullOrWhiteSpace(smsTemplate2FA))
            {
               queryParameters.Add("smsTemplate2FA", smsTemplate2FA);
            }

            var resourcePath = "identity/v2/auth/account/reauth/pin";
            
            return await ConfigureAndExecute<EventBasedMultiFactorAuthenticationToken>(HttpMethod.PUT, resourcePath, queryParameters, ConvertToJson(pINAuthEventBasedAuthModelWithLockout));
        }
        /// <summary>
        /// This API is used to validate the triggered MFA authentication flow with an Email OTP.
        /// </summary>
        /// <param name="accessToken">Uniquely generated identifier key by LoginRadius that is activated after successful authentication.</param>
        /// <param name="reauthByEmailOtpModel">payload</param>
        /// <returns>Response containing Definition response of MFA reauthentication</returns>
        /// 42.14

        public async Task<ApiResponse<EventBasedMultiFactorAuthenticationToken>> ReAuthValidateEmailOtp(string accessToken, ReauthByEmailOtpModel reauthByEmailOtpModel)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(accessToken));
            }
            if (reauthByEmailOtpModel == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(reauthByEmailOtpModel));
            }
            var queryParameters = new QueryParameters
            {
                { "access_token", accessToken },
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] }
            };

            var resourcePath = "identity/v2/auth/account/reauth/2fa/otp/email/verify";
            
            return await ConfigureAndExecute<EventBasedMultiFactorAuthenticationToken>(HttpMethod.PUT, resourcePath, queryParameters, ConvertToJson(reauthByEmailOtpModel));
        }
        /// <summary>
        /// This API is used to send the MFA Email OTP to the email for Re-authentication
        /// </summary>
        /// <param name="accessToken">Uniquely generated identifier key by LoginRadius that is activated after successful authentication.</param>
        /// <param name="emailId">EmailId</param>
        /// <param name="emailTemplate2FA">EmailTemplate2FA</param>
        /// <returns>Response containing Definition of Complete Validation data</returns>
        /// 42.15

        public async Task<ApiResponse<PostResponse>> ReAuthSendEmailOtp(string accessToken, string emailId,
        string emailTemplate2FA = null)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(accessToken));
            }
            if (string.IsNullOrWhiteSpace(emailId))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(emailId));
            }
            var queryParameters = new QueryParameters
            {
                { "access_token", accessToken },
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "emailId", emailId }
            };
            if (!string.IsNullOrWhiteSpace(emailTemplate2FA))
            {
               queryParameters.Add("emailTemplate2FA", emailTemplate2FA);
            }

            var resourcePath = "identity/v2/auth/account/reauth/2fa/otp/email";
            
            return await ConfigureAndExecute<PostResponse>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// This API is used to validate the triggered MFA re-authentication flow with security questions answers.
        /// </summary>
        /// <param name="accessToken">Uniquely generated identifier key by LoginRadius that is activated after successful authentication.</param>
        /// <param name="securityQuestionAnswerUpdateModel">payload</param>
        /// <returns>Response containing Definition response of MFA reauthentication</returns>
        /// 42.16

        public async Task<ApiResponse<EventBasedMultiFactorAuthenticationToken>> ReAuthBySecurityQuestion(string accessToken, SecurityQuestionAnswerUpdateModel securityQuestionAnswerUpdateModel)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(accessToken));
            }
            if (securityQuestionAnswerUpdateModel == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(securityQuestionAnswerUpdateModel));
            }
            var queryParameters = new QueryParameters
            {
                { "access_token", accessToken },
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] }
            };

            var resourcePath = "identity/v2/auth/account/reauth/2fa/securityquestionanswer/verify";
            
            return await ConfigureAndExecute<EventBasedMultiFactorAuthenticationToken>(HttpMethod.POST, resourcePath, queryParameters, ConvertToJson(securityQuestionAnswerUpdateModel));
        }
        /// <summary>
        /// This API is used to validate the triggered MFA authentication flow with the Authenticator Code.
        /// </summary>
        /// <param name="accessToken">Uniquely generated identifier key by LoginRadius that is activated after successful authentication.</param>
        /// <param name="multiFactorAuthModelByAuthenticatorCode">Model Class containing Definition of payload for MultiFactorAuthModel By Authenticator Code API</param>
        /// <returns>Complete user Multi-Factor Authentication Token data</returns>
        /// 44.6

        public async Task<ApiResponse<EventBasedMultiFactorAuthenticationToken>> MFAReAuthenticateByAuthenticatorCode(string accessToken, MultiFactorAuthModelByAuthenticatorCode multiFactorAuthModelByAuthenticatorCode)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(accessToken));
            }
            if (multiFactorAuthModelByAuthenticatorCode == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(multiFactorAuthModelByAuthenticatorCode));
            }
            var queryParameters = new QueryParameters
            {
                { "access_token", accessToken },
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] }
            };

            var resourcePath = "identity/v2/auth/account/reauth/2fa/authenticatorcode";
            
            return await ConfigureAndExecute<EventBasedMultiFactorAuthenticationToken>(HttpMethod.PUT, resourcePath, queryParameters, ConvertToJson(multiFactorAuthModelByAuthenticatorCode));
        }
    }
}