//-----------------------------------------------------------------------
// <copyright file="MultiFactorAuthenticationApi.cs" company="LoginRadius">
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

namespace LoginRadiusSDK.V2.Api.Advanced
{
    public class MultiFactorAuthenticationApi : LoginRadiusResource
    {
        /// <summary>
        /// This API is used to configure the Multi-factor authentication after login by using the access token when MFA is set as optional on the LoginRadius site.
        /// </summary>
        /// <param name="accessToken">Uniquely generated identifier key by LoginRadius that is activated after successful authentication.</param>
        /// <param name="smsTemplate2FA">SMS Template Name</param>
        /// <returns>Response containing Definition of Complete Multi-Factor Authentication Settings data</returns>
        /// 5.7

        public async Task<ApiResponse<MultiFactorAuthenticationSettingsResponse>> MFAConfigureByAccessToken(string accessToken, string smsTemplate2FA = null)
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

            var resourcePath = "identity/v2/auth/account/2fa";
            
            return await ConfigureAndExecute<MultiFactorAuthenticationSettingsResponse>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// This API is used to trigger the Multi-factor authentication settings after login for secure actions
        /// </summary>
        /// <param name="accessToken">Uniquely generated identifier key by LoginRadius that is activated after successful authentication.</param>
        /// <param name="multiFactorAuthModelWithLockout">Model Class containing Definition of payload for MultiFactorAuthModel With Lockout API</param>
        /// <param name="fields">The fields parameter filters the API response so that the response only includes a specific set of fields</param>
        /// <returns>Response containing Definition for Complete profile data</returns>
        /// 5.9

        public async Task<ApiResponse<Identity>> MFAUpdateSetting(string accessToken, MultiFactorAuthModelWithLockout multiFactorAuthModelWithLockout,
        string fields = "")
        {
            if (string.IsNullOrWhiteSpace(accessToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(accessToken));
            }
            if (multiFactorAuthModelWithLockout == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(multiFactorAuthModelWithLockout));
            }
            var queryParameters = new QueryParameters
            {
                { "access_token", accessToken },
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] }
            };
            if (!string.IsNullOrWhiteSpace(fields))
            {
               queryParameters.Add("fields", fields);
            }

            var resourcePath = "identity/v2/auth/account/2fa/verification/otp";
            
            return await ConfigureAndExecute<Identity>(HttpMethod.PUT, resourcePath, queryParameters, ConvertToJson(multiFactorAuthModelWithLockout));
        }
        /// <summary>
        /// This API is used to Enable Multi-factor authentication by access token on user login
        /// </summary>
        /// <param name="accessToken">Uniquely generated identifier key by LoginRadius that is activated after successful authentication.</param>
        /// <param name="multiFactorAuthModelByGoogleAuthenticatorCode">Model Class containing Definition of payload for MultiFactorAuthModel By GoogleAuthenticator Code API</param>
        /// <param name="fields">The fields parameter filters the API response so that the response only includes a specific set of fields</param>
        /// <param name="smsTemplate">SMS Template name</param>
        /// <returns>Response containing Definition for Complete profile data</returns>
        /// 5.10

        public async Task<ApiResponse<Identity>> MFAUpdateByAccessToken(string accessToken, MultiFactorAuthModelByGoogleAuthenticatorCode multiFactorAuthModelByGoogleAuthenticatorCode,
        string fields = "", string smsTemplate = null)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(accessToken));
            }
            if (multiFactorAuthModelByGoogleAuthenticatorCode == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(multiFactorAuthModelByGoogleAuthenticatorCode));
            }
            var queryParameters = new QueryParameters
            {
                { "access_token", accessToken },
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

            var resourcePath = "identity/v2/auth/account/2fa/verification/googleauthenticatorcode";
            
            return await ConfigureAndExecute<Identity>(HttpMethod.PUT, resourcePath, queryParameters, ConvertToJson(multiFactorAuthModelByGoogleAuthenticatorCode));
        }
        /// <summary>
        /// This API is used to update the Multi-factor authentication phone number by sending the verification OTP to the provided phone number
        /// </summary>
        /// <param name="accessToken">Uniquely generated identifier key by LoginRadius that is activated after successful authentication.</param>
        /// <param name="phoneNo2FA">Phone Number For 2FA</param>
        /// <param name="smsTemplate2FA">SMS Template Name</param>
        /// <returns>Response containing Definition for Complete SMS data</returns>
        /// 5.11

        public async Task<ApiResponse<SMSResponseData>> MFAUpdatePhoneNumberByToken(string accessToken, string phoneNo2FA,
        string smsTemplate2FA = null)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(accessToken));
            }
            if (string.IsNullOrWhiteSpace(phoneNo2FA))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(phoneNo2FA));
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

            var bodyParameters = new BodyParameters
            {
                { "phoneNo2FA", phoneNo2FA }
            };

            var resourcePath = "identity/v2/auth/account/2fa";
            
            return await ConfigureAndExecute<SMSResponseData>(HttpMethod.PUT, resourcePath, queryParameters, ConvertToJson(bodyParameters));
        }
        /// <summary>
        /// This API Resets the Google Authenticator configurations on a given account via the access token
        /// </summary>
        /// <param name="accessToken">Uniquely generated identifier key by LoginRadius that is activated after successful authentication.</param>
        /// <param name="googleAuthenticator">boolean type value,Enable google Authenticator Code.</param>
        /// <returns>Response containing Definition of Delete Request</returns>
        /// 5.12.1

        public async Task<ApiResponse<DeleteResponse>> MFAResetGoogleAuthByToken(string accessToken, bool googleAuthenticator)
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

            var bodyParameters = new BodyParameters
            {
                { "googleauthenticator", googleAuthenticator }
            };

            var resourcePath = "identity/v2/auth/account/2fa/authenticator";
            
            return await ConfigureAndExecute<DeleteResponse>(HttpMethod.DELETE, resourcePath, queryParameters, ConvertToJson(bodyParameters));
        }
        /// <summary>
        /// This API resets the SMS Authenticator configurations on a given account via the access token.
        /// </summary>
        /// <param name="accessToken">Uniquely generated identifier key by LoginRadius that is activated after successful authentication.</param>
        /// <param name="otpAuthenticator">Pass 'otpauthenticator' to remove SMS Authenticator</param>
        /// <returns>Response containing Definition of Delete Request</returns>
        /// 5.12.2

        public async Task<ApiResponse<DeleteResponse>> MFAResetSMSAuthByToken(string accessToken, bool otpAuthenticator)
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

            var bodyParameters = new BodyParameters
            {
                { "otpauthenticator", otpAuthenticator }
            };

            var resourcePath = "identity/v2/auth/account/2fa/authenticator";
            
            return await ConfigureAndExecute<DeleteResponse>(HttpMethod.DELETE, resourcePath, queryParameters, ConvertToJson(bodyParameters));
        }
        /// <summary>
        /// This API is used to get a set of backup codes via access token to allow the user login on a site that has Multi-factor Authentication enabled in the event that the user does not have a secondary factor available. We generate 10 codes, each code can only be consumed once. If any user attempts to go over the number of invalid login attempts configured in the Dashboard then the account gets blocked automatically
        /// </summary>
        /// <param name="accessToken">Uniquely generated identifier key by LoginRadius that is activated after successful authentication.</param>
        /// <returns>Response containing Definition of Complete Backup Code data</returns>
        /// 5.13

        public async Task<ApiResponse<BackupCodeResponse>> MFABackupCodeByAccessToken(string accessToken)
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

            var resourcePath = "identity/v2/auth/account/2fa/backupcode";
            
            return await ConfigureAndExecute<BackupCodeResponse>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// API is used to reset the backup codes on a given account via the access token. This API call will generate 10 new codes, each code can only be consumed once
        /// </summary>
        /// <param name="accessToken">Uniquely generated identifier key by LoginRadius that is activated after successful authentication.</param>
        /// <returns>Response containing Definition of Complete Backup Code data</returns>
        /// 5.14

        public async Task<ApiResponse<BackupCodeResponse>> MFAResetBackupCodeByAccessToken(string accessToken)
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

            var resourcePath = "identity/v2/auth/account/2fa/backupcode/reset";
            
            return await ConfigureAndExecute<BackupCodeResponse>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// This API is created to send the OTP to the email if email OTP authenticator is enabled in app's MFA configuration.
        /// </summary>
        /// <param name="accessToken">access_token</param>
        /// <param name="emailId">EmailId</param>
        /// <param name="emailTemplate2FA">EmailTemplate2FA</param>
        /// <returns>Response containing Definition of Complete Validation data</returns>
        /// 5.17

        public async Task<ApiResponse<PostResponse>> MFAEmailOtpByAccessToken(string accessToken, string emailId,
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

            var resourcePath = "identity/v2/auth/account/2fa/otp/email";
            
            return await ConfigureAndExecute<PostResponse>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// This API is used to set up MFA Email OTP authenticator on profile after login.
        /// </summary>
        /// <param name="accessToken">access_token</param>
        /// <param name="multiFactorAuthModelByEmailOtpWithLockout">payload</param>
        /// <returns>Response containing Definition for Complete profile data</returns>
        /// 5.18

        public async Task<ApiResponse<Identity>> MFAValidateEmailOtpByAccessToken(string accessToken, MultiFactorAuthModelByEmailOtpWithLockout multiFactorAuthModelByEmailOtpWithLockout)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(accessToken));
            }
            if (multiFactorAuthModelByEmailOtpWithLockout == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(multiFactorAuthModelByEmailOtpWithLockout));
            }
            var queryParameters = new QueryParameters
            {
                { "access_token", accessToken },
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] }
            };

            var resourcePath = "identity/v2/auth/account/2fa/verification/otp/email";
            
            return await ConfigureAndExecute<Identity>(HttpMethod.PUT, resourcePath, queryParameters, ConvertToJson(multiFactorAuthModelByEmailOtpWithLockout));
        }
        /// <summary>
        /// This API is used to reset the Email OTP Authenticator settings for an MFA-enabled user
        /// </summary>
        /// <param name="accessToken">access_token</param>
        /// <returns>Response containing Definition of Delete Request</returns>
        /// 5.19

        public async Task<ApiResponse<DeleteResponse>> MFAResetEmailOtpAuthenticatorByAccessToken(string accessToken)
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

            var resourcePath = "identity/v2/auth/account/2fa/authenticator/otp/email";
            
            return await ConfigureAndExecute<DeleteResponse>(HttpMethod.DELETE, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// This API is used to set up MFA Security Question authenticator on profile after login.
        /// </summary>
        /// <param name="accessToken">access_token</param>
        /// <param name="securityQuestionAnswerModelByAccessToken">payload</param>
        /// <returns>Response containing Definition of Complete Validation data</returns>
        /// 5.20

        public async Task<ApiResponse<PostResponse>> MFASecurityQuestionAnswerByAccessToken(string accessToken, SecurityQuestionAnswerModelByAccessToken securityQuestionAnswerModelByAccessToken)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(accessToken));
            }
            if (securityQuestionAnswerModelByAccessToken == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(securityQuestionAnswerModelByAccessToken));
            }
            var queryParameters = new QueryParameters
            {
                { "access_token", accessToken },
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] }
            };

            var resourcePath = "identity/v2/auth/account/2fa/securityquestionanswer";
            
            return await ConfigureAndExecute<PostResponse>(HttpMethod.PUT, resourcePath, queryParameters, ConvertToJson(securityQuestionAnswerModelByAccessToken));
        }
        /// <summary>
        /// This API is used to Reset MFA Security Question Authenticator By Access Token
        /// </summary>
        /// <param name="accessToken">access_token</param>
        /// <returns>Response containing Definition of Delete Request</returns>
        /// 5.21

        public async Task<ApiResponse<DeleteResponse>> MFAResetSecurityQuestionAuthenticatorByAccessToken(string accessToken)
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

            var resourcePath = "identity/v2/auth/account/2fa/authenticator/securityquestionanswer";
            
            return await ConfigureAndExecute<DeleteResponse>(HttpMethod.DELETE, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// This API can be used to login by emailid on a Multi-factor authentication enabled LoginRadius site.
        /// </summary>
        /// <param name="email">user's email</param>
        /// <param name="password">Password for the email</param>
        /// <param name="emailTemplate">Email template name</param>
        /// <param name="fields">The fields parameter filters the API response so that the response only includes a specific set of fields</param>
        /// <param name="loginUrl">Url where the user is logging from</param>
        /// <param name="smsTemplate">SMS Template name</param>
        /// <param name="smsTemplate2FA">SMS Template Name</param>
        /// <param name="verificationUrl">Email verification url</param>
        /// <param name="emailTemplate2FA">2FA Email Template name</param>
        /// <returns>Complete user UserProfile data</returns>
        /// 9.8.1

        public async Task<ApiResponse<MultiFactorAuthenticationResponse<Identity>>> MFALoginByEmail(string email, string password,
        string emailTemplate = null, string fields = "", string loginUrl = null, string smsTemplate = null,
        string smsTemplate2FA = null, string verificationUrl = null, string emailTemplate2FA = null)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(email));
            }
            if (string.IsNullOrWhiteSpace(password))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(password));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] }
            };
            if (!string.IsNullOrWhiteSpace(emailTemplate))
            {
               queryParameters.Add("emailTemplate", emailTemplate);
            }
            if (!string.IsNullOrWhiteSpace(fields))
            {
               queryParameters.Add("fields", fields);
            }
            if (!string.IsNullOrWhiteSpace(loginUrl))
            {
               queryParameters.Add("loginUrl", loginUrl);
            }
            if (!string.IsNullOrWhiteSpace(smsTemplate))
            {
               queryParameters.Add("smsTemplate", smsTemplate);
            }
            if (!string.IsNullOrWhiteSpace(smsTemplate2FA))
            {
               queryParameters.Add("smsTemplate2FA", smsTemplate2FA);
            }
            if (!string.IsNullOrWhiteSpace(verificationUrl))
            {
               queryParameters.Add("verificationUrl", verificationUrl);
            }
            if (!string.IsNullOrWhiteSpace(emailTemplate2FA))
            {
               queryParameters.Add("emailTemplate2FA", emailTemplate2FA);
            }

            var bodyParameters = new BodyParameters
            {
                { "email", email },
                { "password", password }
            };

            var resourcePath = "identity/v2/auth/login/2fa";
            
            return await ConfigureAndExecute<MultiFactorAuthenticationResponse<Identity>>(HttpMethod.POST, resourcePath, queryParameters, ConvertToJson(bodyParameters));
        }
        /// <summary>
        /// This API can be used to login by username on a Multi-factor authentication enabled LoginRadius site.
        /// </summary>
        /// <param name="password">Password for the email</param>
        /// <param name="username">Username of the user</param>
        /// <param name="emailTemplate">Email template name</param>
        /// <param name="fields">The fields parameter filters the API response so that the response only includes a specific set of fields</param>
        /// <param name="loginUrl">Url where the user is logging from</param>
        /// <param name="smsTemplate">SMS Template name</param>
        /// <param name="smsTemplate2FA">SMS Template Name</param>
        /// <param name="verificationUrl">Email verification url</param>
        /// <param name="emailTemplate2FA">2FA Email Template name</param>
        /// <returns>Complete user UserProfile data</returns>
        /// 9.8.2

        public async Task<ApiResponse<MultiFactorAuthenticationResponse<Identity>>> MFALoginByUserName(string password, string username,
        string emailTemplate = null, string fields = "", string loginUrl = null, string smsTemplate = null,
        string smsTemplate2FA = null, string verificationUrl = null, string emailTemplate2FA = null)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(password));
            }
            if (string.IsNullOrWhiteSpace(username))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(username));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] }
            };
            if (!string.IsNullOrWhiteSpace(emailTemplate))
            {
               queryParameters.Add("emailTemplate", emailTemplate);
            }
            if (!string.IsNullOrWhiteSpace(fields))
            {
               queryParameters.Add("fields", fields);
            }
            if (!string.IsNullOrWhiteSpace(loginUrl))
            {
               queryParameters.Add("loginUrl", loginUrl);
            }
            if (!string.IsNullOrWhiteSpace(smsTemplate))
            {
               queryParameters.Add("smsTemplate", smsTemplate);
            }
            if (!string.IsNullOrWhiteSpace(smsTemplate2FA))
            {
               queryParameters.Add("smsTemplate2FA", smsTemplate2FA);
            }
            if (!string.IsNullOrWhiteSpace(verificationUrl))
            {
               queryParameters.Add("verificationUrl", verificationUrl);
            }
            if (!string.IsNullOrWhiteSpace(emailTemplate2FA))
            {
               queryParameters.Add("emailTemplate2FA", emailTemplate2FA);
            }

            var bodyParameters = new BodyParameters
            {
                { "password", password },
                { "username", username }
            };

            var resourcePath = "identity/v2/auth/login/2fa";
            
            return await ConfigureAndExecute<MultiFactorAuthenticationResponse<Identity>>(HttpMethod.POST, resourcePath, queryParameters, ConvertToJson(bodyParameters));
        }
        /// <summary>
        /// This API can be used to login by Phone on a Multi-factor authentication enabled LoginRadius site.
        /// </summary>
        /// <param name="password">Password for the email</param>
        /// <param name="phone">New Phone Number</param>
        /// <param name="emailTemplate">Email template name</param>
        /// <param name="fields">The fields parameter filters the API response so that the response only includes a specific set of fields</param>
        /// <param name="loginUrl">Url where the user is logging from</param>
        /// <param name="smsTemplate">SMS Template name</param>
        /// <param name="smsTemplate2FA">SMS Template Name</param>
        /// <param name="verificationUrl">Email verification url</param>
        /// <param name="emailTemplate2FA">2FA Email Template name</param>
        /// <returns>Complete user UserProfile data</returns>
        /// 9.8.3

        public async Task<ApiResponse<MultiFactorAuthenticationResponse<Identity>>> MFALoginByPhone(string password, string phone,
        string emailTemplate = null, string fields = "", string loginUrl = null, string smsTemplate = null,
        string smsTemplate2FA = null, string verificationUrl = null, string emailTemplate2FA = null)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(password));
            }
            if (string.IsNullOrWhiteSpace(phone))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(phone));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] }
            };
            if (!string.IsNullOrWhiteSpace(emailTemplate))
            {
               queryParameters.Add("emailTemplate", emailTemplate);
            }
            if (!string.IsNullOrWhiteSpace(fields))
            {
               queryParameters.Add("fields", fields);
            }
            if (!string.IsNullOrWhiteSpace(loginUrl))
            {
               queryParameters.Add("loginUrl", loginUrl);
            }
            if (!string.IsNullOrWhiteSpace(smsTemplate))
            {
               queryParameters.Add("smsTemplate", smsTemplate);
            }
            if (!string.IsNullOrWhiteSpace(smsTemplate2FA))
            {
               queryParameters.Add("smsTemplate2FA", smsTemplate2FA);
            }
            if (!string.IsNullOrWhiteSpace(verificationUrl))
            {
               queryParameters.Add("verificationUrl", verificationUrl);
            }
            if (!string.IsNullOrWhiteSpace(emailTemplate2FA))
            {
               queryParameters.Add("emailTemplate2FA", emailTemplate2FA);
            }

            var bodyParameters = new BodyParameters
            {
                { "password", password },
                { "phone", phone }
            };

            var resourcePath = "identity/v2/auth/login/2fa";
            
            return await ConfigureAndExecute<MultiFactorAuthenticationResponse<Identity>>(HttpMethod.POST, resourcePath, queryParameters, ConvertToJson(bodyParameters));
        }
        /// <summary>
        /// This API is used to login via Multi-factor authentication by passing the One Time Password received via SMS
        /// </summary>
        /// <param name="multiFactorAuthModelWithLockout">Model Class containing Definition of payload for MultiFactorAuthModel With Lockout API</param>
        /// <param name="secondFactorAuthenticationToken">A Uniquely generated MFA identifier token after successful authentication</param>
        /// <param name="fields">The fields parameter filters the API response so that the response only includes a specific set of fields</param>
        /// <param name="smsTemplate2FA">SMS Template Name</param>
        /// <param name="rbaBrowserEmailTemplate"></param>
        /// <param name="rbaCityEmailTemplate"></param>
        /// <param name="rbaCountryEmailTemplate"></param>
        /// <param name="rbaIpEmailTemplate"></param>
        /// <returns>Complete user UserProfile data</returns>
        /// 9.12

        public async Task<ApiResponse<AccessToken<Identity>>> MFAValidateOTPByPhone(MultiFactorAuthModelWithLockout multiFactorAuthModelWithLockout, string secondFactorAuthenticationToken,
        string fields = "",string smsTemplate2FA = null, string rbaBrowserEmailTemplate = null, string rbaCityEmailTemplate = null, string rbaCountryEmailTemplate = null, string rbaIpEmailTemplate = null)
        {
            if (multiFactorAuthModelWithLockout == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(multiFactorAuthModelWithLockout));
            }
            if (string.IsNullOrWhiteSpace(secondFactorAuthenticationToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(secondFactorAuthenticationToken));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "secondFactorAuthenticationToken", secondFactorAuthenticationToken }
            };
            if (!string.IsNullOrWhiteSpace(fields))
            {
               queryParameters.Add("fields", fields);
            }
            if (!string.IsNullOrWhiteSpace(smsTemplate2FA))
            {
               queryParameters.Add("smsTemplate2FA", smsTemplate2FA);
            }
            if (!string.IsNullOrWhiteSpace(rbaBrowserEmailTemplate))
            {
               queryParameters.Add("rbaBrowserEmailTemplate", rbaBrowserEmailTemplate);
            }
            if (!string.IsNullOrWhiteSpace(rbaCityEmailTemplate))
            {
               queryParameters.Add("rbaCityEmailTemplate", rbaCityEmailTemplate);
            }
            if (!string.IsNullOrWhiteSpace(rbaCountryEmailTemplate))
            {
               queryParameters.Add("rbaCountryEmailTemplate", rbaCountryEmailTemplate);
            }
            if (!string.IsNullOrWhiteSpace(rbaIpEmailTemplate))
            {
               queryParameters.Add("rbaIpEmailTemplate", rbaIpEmailTemplate);
            }

            var resourcePath = "identity/v2/auth/login/2fa/verification/otp";
            
            return await ConfigureAndExecute<AccessToken<Identity>>(HttpMethod.PUT, resourcePath, queryParameters, ConvertToJson(multiFactorAuthModelWithLockout));
        }
        /// <summary>
        /// This API is used to login via Multi-factor-authentication by passing the google authenticator code.
        /// </summary>
        /// <param name="googleAuthenticatorCode">The code generated by google authenticator app after scanning QR code</param>
        /// <param name="secondFactorAuthenticationToken">SecondFactorAuthenticationToken</param>
        /// <param name="fields">The fields parameter filters the API response so that the response only includes a specific set of fields</param>
        /// <param name="rbaBrowserEmailTemplate">RbaBrowserEmailTemplate</param>
        /// <param name="rbaCityEmailTemplate">RbaCityEmailTemplate</param>
        /// <param name="rbaCountryEmailTemplate">RbaCountryEmailTemplate</param>
        /// <param name="rbaIpEmailTemplate">RbaIpEmailTemplate</param>
        /// <returns>Complete user UserProfile data</returns>
        /// 9.13

        public async Task<ApiResponse<AccessToken<Identity>>> MFAValidateGoogleAuthCode(string googleAuthenticatorCode, string secondFactorAuthenticationToken,
        string fields = "", string rbaBrowserEmailTemplate = null, string rbaCityEmailTemplate = null, string rbaCountryEmailTemplate = null, string rbaIpEmailTemplate = null)
        {
            if (string.IsNullOrWhiteSpace(googleAuthenticatorCode))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(googleAuthenticatorCode));
            }
            if (string.IsNullOrWhiteSpace(secondFactorAuthenticationToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(secondFactorAuthenticationToken));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "secondFactorAuthenticationToken", secondFactorAuthenticationToken }
            };
            if (!string.IsNullOrWhiteSpace(fields))
            {
               queryParameters.Add("fields", fields);
            }
            if (!string.IsNullOrWhiteSpace(rbaBrowserEmailTemplate))
            {
               queryParameters.Add("rbaBrowserEmailTemplate", rbaBrowserEmailTemplate);
            }
            if (!string.IsNullOrWhiteSpace(rbaCityEmailTemplate))
            {
               queryParameters.Add("rbaCityEmailTemplate", rbaCityEmailTemplate);
            }
            if (!string.IsNullOrWhiteSpace(rbaCountryEmailTemplate))
            {
               queryParameters.Add("rbaCountryEmailTemplate", rbaCountryEmailTemplate);
            }
            if (!string.IsNullOrWhiteSpace(rbaIpEmailTemplate))
            {
               queryParameters.Add("rbaIpEmailTemplate", rbaIpEmailTemplate);
            }

            var bodyParameters = new BodyParameters
            {
                { "googleAuthenticatorCode", googleAuthenticatorCode }
            };

            var resourcePath = "identity/v2/auth/login/2fa/verification/googleauthenticatorcode";
            
            return await ConfigureAndExecute<AccessToken<Identity>>(HttpMethod.PUT, resourcePath, queryParameters, ConvertToJson(bodyParameters));
        }
        /// <summary>
        /// This API is used to validate the backup code provided by the user and if valid, we return an access token allowing the user to login incases where Multi-factor authentication (MFA) is enabled and the secondary factor is unavailable. When a user initially downloads the Backup codes, We generate 10 codes, each code can only be consumed once. if any user attempts to go over the number of invalid login attempts configured in the Dashboard then the account gets blocked automatically
        /// </summary>
        /// <param name="multiFactorAuthModelByBackupCode">Model Class containing Definition of payload for MultiFactorAuth By BackupCode API</param>
        /// <param name="secondFactorAuthenticationToken">A Uniquely generated MFA identifier token after successful authentication</param>
        /// <param name="fields">The fields parameter filters the API response so that the response only includes a specific set of fields</param>
        /// <param name="rbaBrowserEmailTemplate"></param>
        /// <param name="rbaCityEmailTemplate"></param>
        /// <param name="rbaCountryEmailTemplate"></param>
        /// <param name="rbaIpEmailTemplate"></param>
        /// <returns>Complete user UserProfile data</returns>
        /// 9.14

        public async Task<ApiResponse<AccessToken<Identity>>> MFAValidateBackupCode(MultiFactorAuthModelByBackupCode multiFactorAuthModelByBackupCode, string secondFactorAuthenticationToken,
        string fields = "", string rbaBrowserEmailTemplate = null, string rbaCityEmailTemplate = null, string rbaCountryEmailTemplate = null, string rbaIpEmailTemplate = null)
        {
            if (multiFactorAuthModelByBackupCode == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(multiFactorAuthModelByBackupCode));
            }
            if (string.IsNullOrWhiteSpace(secondFactorAuthenticationToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(secondFactorAuthenticationToken));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "secondFactorAuthenticationToken", secondFactorAuthenticationToken }
            };
            if (!string.IsNullOrWhiteSpace(fields))
            {
               queryParameters.Add("fields", fields);
            }
            if (!string.IsNullOrWhiteSpace(rbaBrowserEmailTemplate))
            {
               queryParameters.Add("rbaBrowserEmailTemplate", rbaBrowserEmailTemplate);
            }
            if (!string.IsNullOrWhiteSpace(rbaCityEmailTemplate))
            {
               queryParameters.Add("rbaCityEmailTemplate", rbaCityEmailTemplate);
            }
            if (!string.IsNullOrWhiteSpace(rbaCountryEmailTemplate))
            {
               queryParameters.Add("rbaCountryEmailTemplate", rbaCountryEmailTemplate);
            }
            if (!string.IsNullOrWhiteSpace(rbaIpEmailTemplate))
            {
               queryParameters.Add("rbaIpEmailTemplate", rbaIpEmailTemplate);
            }

            var resourcePath = "identity/v2/auth/login/2fa/verification/backupcode";
            
            return await ConfigureAndExecute<AccessToken<Identity>>(HttpMethod.PUT, resourcePath, queryParameters, ConvertToJson(multiFactorAuthModelByBackupCode));
        }
        /// <summary>
        /// This API is used to update (if configured) the phone number used for Multi-factor authentication by sending the verification OTP to the provided phone number
        /// </summary>
        /// <param name="phoneNo2FA">Phone Number For 2FA</param>
        /// <param name="secondFactorAuthenticationToken">A Uniquely generated MFA identifier token after successful authentication</param>
        /// <param name="smsTemplate2FA">SMS Template Name</param>
        /// <returns>Response containing Definition for Complete SMS data</returns>
        /// 9.16

        public async Task<ApiResponse<SMSResponseData>> MFAUpdatePhoneNumber(string phoneNo2FA, string secondFactorAuthenticationToken,
        string smsTemplate2FA = null)
        {
            if (string.IsNullOrWhiteSpace(phoneNo2FA))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(phoneNo2FA));
            }
            if (string.IsNullOrWhiteSpace(secondFactorAuthenticationToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(secondFactorAuthenticationToken));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "secondFactorAuthenticationToken", secondFactorAuthenticationToken }
            };
            if (!string.IsNullOrWhiteSpace(smsTemplate2FA))
            {
               queryParameters.Add("smsTemplate2FA", smsTemplate2FA);
            }

            var bodyParameters = new BodyParameters
            {
                { "phoneNo2FA", phoneNo2FA }
            };

            var resourcePath = "identity/v2/auth/login/2fa";
            
            return await ConfigureAndExecute<SMSResponseData>(HttpMethod.PUT, resourcePath, queryParameters, ConvertToJson(bodyParameters));
        }
        /// <summary>
        /// This API is used to resending the verification OTP to the provided phone number
        /// </summary>
        /// <param name="secondFactorAuthenticationToken">A Uniquely generated MFA identifier token after successful authentication</param>
        /// <param name="smsTemplate2FA">SMS Template Name</param>
        /// <returns>Response containing Definition for Complete SMS data</returns>
        /// 9.17

        public async Task<ApiResponse<SMSResponseData>> MFAResendOTP(string secondFactorAuthenticationToken, string smsTemplate2FA = null)
        {
            if (string.IsNullOrWhiteSpace(secondFactorAuthenticationToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(secondFactorAuthenticationToken));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "secondFactorAuthenticationToken", secondFactorAuthenticationToken }
            };
            if (!string.IsNullOrWhiteSpace(smsTemplate2FA))
            {
               queryParameters.Add("smsTemplate2FA", smsTemplate2FA);
            }

            var resourcePath = "identity/v2/auth/login/2fa/resend";
            
            return await ConfigureAndExecute<SMSResponseData>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// An API designed to send the MFA Email OTP to the email.
        /// </summary>
        /// <param name="emailIdModel">payload</param>
        /// <param name="secondFactorAuthenticationToken">SecondFactorAuthenticationToken</param>
        /// <param name="emailTemplate2FA">EmailTemplate2FA</param>
        /// <returns>Response containing Definition of Complete Validation data</returns>
        /// 9.18

        public async Task<ApiResponse<PostResponse>> MFAEmailOTP(EmailIdModel emailIdModel, string secondFactorAuthenticationToken,
        string emailTemplate2FA = null)
        {
            if (emailIdModel == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(emailIdModel));
            }
            if (string.IsNullOrWhiteSpace(secondFactorAuthenticationToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(secondFactorAuthenticationToken));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "secondFactorAuthenticationToken", secondFactorAuthenticationToken }
            };
            if (!string.IsNullOrWhiteSpace(emailTemplate2FA))
            {
               queryParameters.Add("emailTemplate2FA", emailTemplate2FA);
            }

            var resourcePath = "identity/v2/auth/login/2fa/otp/email";
            
            return await ConfigureAndExecute<PostResponse>(HttpMethod.POST, resourcePath, queryParameters, ConvertToJson(emailIdModel));
        }
        /// <summary>
        /// This API is used to Verify MFA Email OTP by MFA Token
        /// </summary>
        /// <param name="multiFactorAuthModelByEmailOtp">payload</param>
        /// <param name="secondFactorAuthenticationToken">SecondFactorAuthenticationToken</param>
        /// <param name="rbaBrowserEmailTemplate">RbaBrowserEmailTemplate</param>
        /// <param name="rbaCityEmailTemplate">RbaCityEmailTemplate</param>
        /// <param name="rbaCountryEmailTemplate">RbaCountryEmailTemplate</param>
        /// <param name="rbaIpEmailTemplate">RbaIpEmailTemplate</param>
        /// <returns>Response Containing Access Token and Complete Profile Data</returns>
        /// 9.25

        public async Task<ApiResponse<AccessToken<UserProfile>>> MFAValidateEmailOtp(MultiFactorAuthModelByEmailOtp multiFactorAuthModelByEmailOtp, string secondFactorAuthenticationToken,
        string rbaBrowserEmailTemplate = null, string rbaCityEmailTemplate = null, string rbaCountryEmailTemplate = null, string rbaIpEmailTemplate = null)
        {
            if (multiFactorAuthModelByEmailOtp == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(multiFactorAuthModelByEmailOtp));
            }
            if (string.IsNullOrWhiteSpace(secondFactorAuthenticationToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(secondFactorAuthenticationToken));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "secondFactorAuthenticationToken", secondFactorAuthenticationToken }
            };
            if (!string.IsNullOrWhiteSpace(rbaBrowserEmailTemplate))
            {
               queryParameters.Add("rbaBrowserEmailTemplate", rbaBrowserEmailTemplate);
            }
            if (!string.IsNullOrWhiteSpace(rbaCityEmailTemplate))
            {
               queryParameters.Add("rbaCityEmailTemplate", rbaCityEmailTemplate);
            }
            if (!string.IsNullOrWhiteSpace(rbaCountryEmailTemplate))
            {
               queryParameters.Add("rbaCountryEmailTemplate", rbaCountryEmailTemplate);
            }
            if (!string.IsNullOrWhiteSpace(rbaIpEmailTemplate))
            {
               queryParameters.Add("rbaIpEmailTemplate", rbaIpEmailTemplate);
            }

            var resourcePath = "identity/v2/auth/login/2fa/verification/otp/email";
            
            return await ConfigureAndExecute<AccessToken<UserProfile>>(HttpMethod.PUT, resourcePath, queryParameters, ConvertToJson(multiFactorAuthModelByEmailOtp));
        }
        /// <summary>
        /// This API is used to set the security questions on the profile with the MFA token when MFA flow is required.
        /// </summary>
        /// <param name="securityQuestionAnswerUpdateModel">payload</param>
        /// <param name="secondFactorAuthenticationToken">SecondFactorAuthenticationToken</param>
        /// <returns>Response Containing Access Token and Complete Profile Data</returns>
        /// 9.26

        public async Task<ApiResponse<AccessToken<UserProfile>>> MFASecurityQuestionAnswer(SecurityQuestionAnswerUpdateModel securityQuestionAnswerUpdateModel, string secondFactorAuthenticationToken)
        {
            if (securityQuestionAnswerUpdateModel == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(securityQuestionAnswerUpdateModel));
            }
            if (string.IsNullOrWhiteSpace(secondFactorAuthenticationToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(secondFactorAuthenticationToken));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "secondFactorAuthenticationToken", secondFactorAuthenticationToken }
            };

            var resourcePath = "identity/v2/auth/login/2fa/securityquestionanswer";
            
            return await ConfigureAndExecute<AccessToken<UserProfile>>(HttpMethod.PUT, resourcePath, queryParameters, ConvertToJson(securityQuestionAnswerUpdateModel));
        }
        /// <summary>
        /// This API is used to resending the verification OTP to the provided phone number
        /// </summary>
        /// <param name="securityQuestionAnswerUpdateModel">payload</param>
        /// <param name="secondFactorAuthenticationToken">SecondFactorAuthenticationToken</param>
        /// <param name="rbaBrowserEmailTemplate">RbaBrowserEmailTemplate</param>
        /// <param name="rbaCityEmailTemplate">RbaCityEmailTemplate</param>
        /// <param name="rbaCountryEmailTemplate">RbaCountryEmailTemplate</param>
        /// <param name="rbaIpEmailTemplate">RbaIpEmailTemplate</param>
        /// <returns>Response Containing Access Token and Complete Profile Data</returns>
        /// 9.27

        public async Task<ApiResponse<AccessToken<UserProfile>>> MFASecurityQuestionAnswerVerification(SecurityQuestionAnswerUpdateModel securityQuestionAnswerUpdateModel, string secondFactorAuthenticationToken,
        string rbaBrowserEmailTemplate = null, string rbaCityEmailTemplate = null, string rbaCountryEmailTemplate = null, string rbaIpEmailTemplate = null)
        {
            if (securityQuestionAnswerUpdateModel == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(securityQuestionAnswerUpdateModel));
            }
            if (string.IsNullOrWhiteSpace(secondFactorAuthenticationToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(secondFactorAuthenticationToken));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "secondFactorAuthenticationToken", secondFactorAuthenticationToken }
            };
            if (!string.IsNullOrWhiteSpace(rbaBrowserEmailTemplate))
            {
               queryParameters.Add("rbaBrowserEmailTemplate", rbaBrowserEmailTemplate);
            }
            if (!string.IsNullOrWhiteSpace(rbaCityEmailTemplate))
            {
               queryParameters.Add("rbaCityEmailTemplate", rbaCityEmailTemplate);
            }
            if (!string.IsNullOrWhiteSpace(rbaCountryEmailTemplate))
            {
               queryParameters.Add("rbaCountryEmailTemplate", rbaCountryEmailTemplate);
            }
            if (!string.IsNullOrWhiteSpace(rbaIpEmailTemplate))
            {
               queryParameters.Add("rbaIpEmailTemplate", rbaIpEmailTemplate);
            }

            var resourcePath = "identity/v2/auth/login/2fa/verification/securityquestionanswer";
            
            return await ConfigureAndExecute<AccessToken<UserProfile>>(HttpMethod.POST, resourcePath, queryParameters, ConvertToJson(securityQuestionAnswerUpdateModel));
        }
        /// <summary>
        /// This API resets the SMS Authenticator configurations on a given account via the UID.
        /// </summary>
        /// <param name="otpAuthenticator">Pass 'otpauthenticator' to remove SMS Authenticator</param>
        /// <param name="uid">UID, the unified identifier for each user account</param>
        /// <returns>Response containing Definition of Delete Request</returns>
        /// 18.21.1

        public async Task<ApiResponse<DeleteResponse>> MFAResetSMSAuthenticatorByUid(bool otpAuthenticator, string uid)
        {
            if (string.IsNullOrWhiteSpace(uid))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(uid));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "apiSecret", ConfigDictionary[LRConfigConstants.LoginRadiusApiSecret] },
                { "uid", uid }
            };

            var bodyParameters = new BodyParameters
            {
                { "otpauthenticator", otpAuthenticator }
            };

            var resourcePath = "identity/v2/manage/account/2fa/authenticator";
            
            return await ConfigureAndExecute<DeleteResponse>(HttpMethod.DELETE, resourcePath, queryParameters, ConvertToJson(bodyParameters));
        }
        /// <summary>
        /// This API resets the Google Authenticator configurations on a given account via the UID.
        /// </summary>
        /// <param name="googleAuthenticator">boolean type value,Enable google Authenticator Code.</param>
        /// <param name="uid">UID, the unified identifier for each user account</param>
        /// <returns>Response containing Definition of Delete Request</returns>
        /// 18.21.2

        public async Task<ApiResponse<DeleteResponse>> MFAResetGoogleAuthenticatorByUid(bool googleAuthenticator, string uid)
        {
            if (string.IsNullOrWhiteSpace(uid))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(uid));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "apiSecret", ConfigDictionary[LRConfigConstants.LoginRadiusApiSecret] },
                { "uid", uid }
            };

            var bodyParameters = new BodyParameters
            {
                { "googleauthenticator", googleAuthenticator }
            };

            var resourcePath = "identity/v2/manage/account/2fa/authenticator";
            
            return await ConfigureAndExecute<DeleteResponse>(HttpMethod.DELETE, resourcePath, queryParameters, ConvertToJson(bodyParameters));
        }
        /// <summary>
        /// This API is used to reset the backup codes on a given account via the UID. This API call will generate 10 new codes, each code can only be consumed once.
        /// </summary>
        /// <param name="uid">UID, the unified identifier for each user account</param>
        /// <returns>Response containing Definition of Complete Backup Code data</returns>
        /// 18.25

        public async Task<ApiResponse<BackupCodeResponse>> MFABackupCodeByUid(string uid)
        {
            if (string.IsNullOrWhiteSpace(uid))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(uid));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "apiSecret", ConfigDictionary[LRConfigConstants.LoginRadiusApiSecret] },
                { "uid", uid }
            };

            var resourcePath = "identity/v2/manage/account/2fa/backupcode";
            
            return await ConfigureAndExecute<BackupCodeResponse>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// This API is used to reset the backup codes on a given account via the UID. This API call will generate 10 new codes, each code can only be consumed once.
        /// </summary>
        /// <param name="uid">UID, the unified identifier for each user account</param>
        /// <returns>Response containing Definition of Complete Backup Code data</returns>
        /// 18.26

        public async Task<ApiResponse<BackupCodeResponse>> MFAResetBackupCodeByUid(string uid)
        {
            if (string.IsNullOrWhiteSpace(uid))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(uid));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "apiSecret", ConfigDictionary[LRConfigConstants.LoginRadiusApiSecret] },
                { "uid", uid }
            };

            var resourcePath = "identity/v2/manage/account/2fa/backupcode/reset";
            
            return await ConfigureAndExecute<BackupCodeResponse>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// This API is used to reset the Email OTP Authenticator settings for an MFA-enabled user.
        /// </summary>
        /// <param name="uid">UID, the unified identifier for each user account</param>
        /// <returns>Response containing Definition of Delete Request</returns>
        /// 18.42

        public async Task<ApiResponse<DeleteResponse>> MFAResetEmailOtpAuthenticatorByUid(string uid)
        {
            if (string.IsNullOrWhiteSpace(uid))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(uid));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "apiSecret", ConfigDictionary[LRConfigConstants.LoginRadiusApiSecret] },
                { "uid", uid }
            };

            var resourcePath = "identity/v2/manage/account/2fa/authenticator/otp/email";
            
            return await ConfigureAndExecute<DeleteResponse>(HttpMethod.DELETE, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// This API is used to reset the Security Question Authenticator settings for an MFA-enabled user.
        /// </summary>
        /// <param name="uid">UID, the unified identifier for each user account</param>
        /// <returns>Response containing Definition of Delete Request</returns>
        /// 18.43

        public async Task<ApiResponse<DeleteResponse>> MFAResetSecurityQuestionAuthenticatorByUid(string uid)
        {
            if (string.IsNullOrWhiteSpace(uid))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(uid));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "apiSecret", ConfigDictionary[LRConfigConstants.LoginRadiusApiSecret] },
                { "uid", uid }
            };

            var resourcePath = "identity/v2/manage/account/2fa/authenticator/securityquestionanswer";
            
            return await ConfigureAndExecute<DeleteResponse>(HttpMethod.DELETE, resourcePath, queryParameters, null);
        }
    }
}