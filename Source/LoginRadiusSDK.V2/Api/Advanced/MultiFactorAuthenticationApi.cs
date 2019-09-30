//-----------------------------------------------------------------------
// <copyright file="MultiFactorAuthenticationApi.cs" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2019 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using LoginRadiusSDK.V2.Common;
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
        /// This API is used to configure the Multi-factor authentication after login by using the access_token when MFA is set as optional on the LoginRadius site.
        /// </summary>
        /// <param name="accessToken">Uniquely generated identifier key by LoginRadius that is activated after successful authentication.</param>
        /// <param name="smsTemplate2FA">SMS Template Name</param>
        /// <returns>Response containing Definition of Complete Multi-Factor Authentication Settings data</returns>
        /// 5.7

        public ApiResponse<MultiFactorAuthenticationSettingsResponse> MFAConfigureByAccessToken(string accessToken, string smsTemplate2FA = null)
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
            
            return ConfigureAndExecute<MultiFactorAuthenticationSettingsResponse>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// This API is used to trigger the Multi-factor authentication settings after login for secure actions
        /// </summary>
        /// <param name="accessToken">Uniquely generated identifier key by LoginRadius that is activated after successful authentication.</param>
        /// <param name="multiFactorAuthModelWithLockout">Model Class containing Definition of payload for MultiFactorAuthModel With Lockout API</param>
        /// <param name="fields">The fields parameter filters the API response so that the response only includes a specific set of fields</param>
        /// <returns>Response containing Definition for Complete profile data</returns>
        /// 5.9

        public ApiResponse<Identity> MFAUpdateSetting(string accessToken, MultiFactorAuthModelWithLockout multiFactorAuthModelWithLockout,
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
            
            return ConfigureAndExecute<Identity>(HttpMethod.PUT, resourcePath, queryParameters, ConvertToJson(multiFactorAuthModelWithLockout));
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

        public ApiResponse<Identity> MFAUpdateByAccessToken(string accessToken, MultiFactorAuthModelByGoogleAuthenticatorCode multiFactorAuthModelByGoogleAuthenticatorCode,
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
            
            return ConfigureAndExecute<Identity>(HttpMethod.PUT, resourcePath, queryParameters, ConvertToJson(multiFactorAuthModelByGoogleAuthenticatorCode));
        }
        /// <summary>
        /// This API is used to update the Multi-factor authentication phone number by sending the verification OTP to the provided phone number
        /// </summary>
        /// <param name="accessToken">Uniquely generated identifier key by LoginRadius that is activated after successful authentication.</param>
        /// <param name="phoneNo2FA">Phone Number For 2FA</param>
        /// <param name="smsTemplate2FA">SMS Template Name</param>
        /// <returns>Response containing Definition for Complete SMS data</returns>
        /// 5.11

        public ApiResponse<SMSResponseData> MFAUpdatePhoneNumberByToken(string accessToken, string phoneNo2FA,
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
            
            return ConfigureAndExecute<SMSResponseData>(HttpMethod.PUT, resourcePath, queryParameters, ConvertToJson(bodyParameters));
        }
        /// <summary>
        /// This API Resets the Google Authenticator configurations on a given account via the access_token
        /// </summary>
        /// <param name="accessToken">Uniquely generated identifier key by LoginRadius that is activated after successful authentication.</param>
        /// <param name="googleAuthenticator">boolean type value,Enable google Authenticator Code.</param>
        /// <returns>Response containing Definition of Delete Request</returns>
        /// 5.12.1

        public ApiResponse<DeleteResponse> MFAResetGoogleAuthByToken(string accessToken, bool googleAuthenticator)
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
            
            return ConfigureAndExecute<DeleteResponse>(HttpMethod.DELETE, resourcePath, queryParameters, ConvertToJson(bodyParameters));
        }
        /// <summary>
        /// This API resets the SMS Authenticator configurations on a given account via the access_token.
        /// </summary>
        /// <param name="accessToken">Uniquely generated identifier key by LoginRadius that is activated after successful authentication.</param>
        /// <param name="otpAuthenticator">Pass 'otpauthenticator' to remove SMS Authenticator</param>
        /// <returns>Response containing Definition of Delete Request</returns>
        /// 5.12.2

        public ApiResponse<DeleteResponse> MFAResetSMSAuthByToken(string accessToken, bool otpAuthenticator)
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
            
            return ConfigureAndExecute<DeleteResponse>(HttpMethod.DELETE, resourcePath, queryParameters, ConvertToJson(bodyParameters));
        }
        /// <summary>
        /// This API is used to get a set of backup codes via access_token to allow the user login on a site that has Multi-factor Authentication enabled in the event that the user does not have a secondary factor available. We generate 10 codes, each code can only be consumed once. If any user attempts to go over the number of invalid login attempts configured in the Dashboard then the account gets blocked automatically
        /// </summary>
        /// <param name="accessToken">Uniquely generated identifier key by LoginRadius that is activated after successful authentication.</param>
        /// <returns>Response containing Definition of Complete Backup Code data</returns>
        /// 5.13

        public ApiResponse<BackupCodeResponse> MFABackupCodeByAccessToken(string accessToken)
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
            
            return ConfigureAndExecute<BackupCodeResponse>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// API is used to reset the backup codes on a given account via the access_token. This API call will generate 10 new codes, each code can only be consumed once
        /// </summary>
        /// <param name="accessToken">Uniquely generated identifier key by LoginRadius that is activated after successful authentication.</param>
        /// <returns>Response containing Definition of Complete Backup Code data</returns>
        /// 5.14

        public ApiResponse<BackupCodeResponse> MFAResetBackupCodeByAccessToken(string accessToken)
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
            
            return ConfigureAndExecute<BackupCodeResponse>(HttpMethod.GET, resourcePath, queryParameters, null);
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
        /// <returns>Complete user UserProfile data</returns>
        /// 9.8.1

        public ApiResponse<MultiFactorAuthenticationResponse<Identity>> MFALoginByEmail(string email, string password,
        string emailTemplate = null, string fields = "", string loginUrl = null, string smsTemplate = null, string smsTemplate2FA = null,
        string verificationUrl = null)
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

            var bodyParameters = new BodyParameters
            {
                { "email", email },
                { "password", password }
            };

            var resourcePath = "identity/v2/auth/login/2fa";
            
            return ConfigureAndExecute<MultiFactorAuthenticationResponse<Identity>>(HttpMethod.POST, resourcePath, queryParameters, ConvertToJson(bodyParameters));
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
        /// <returns>Complete user UserProfile data</returns>
        /// 9.8.2

        public ApiResponse<MultiFactorAuthenticationResponse<Identity>> MFALoginByUserName(string password, string username,
        string emailTemplate = null, string fields = "", string loginUrl = null, string smsTemplate = null, string smsTemplate2FA = null,
        string verificationUrl = null)
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

            var bodyParameters = new BodyParameters
            {
                { "password", password },
                { "username", username }
            };

            var resourcePath = "identity/v2/auth/login/2fa";
            
            return ConfigureAndExecute<MultiFactorAuthenticationResponse<Identity>>(HttpMethod.POST, resourcePath, queryParameters, ConvertToJson(bodyParameters));
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
        /// <returns>Complete user UserProfile data</returns>
        /// 9.8.3

        public ApiResponse<MultiFactorAuthenticationResponse<Identity>> MFALoginByPhone(string password, string phone,
        string emailTemplate = null, string fields = "", string loginUrl = null, string smsTemplate = null, string smsTemplate2FA = null,
        string verificationUrl = null)
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

            var bodyParameters = new BodyParameters
            {
                { "password", password },
                { "phone", phone }
            };

            var resourcePath = "identity/v2/auth/login/2fa";
            
            return ConfigureAndExecute<MultiFactorAuthenticationResponse<Identity>>(HttpMethod.POST, resourcePath, queryParameters, ConvertToJson(bodyParameters));
        }
        /// <summary>
        /// This API is used to login via Multi-factor authentication by passing the One Time Password received via SMS
        /// </summary>
        /// <param name="multiFactorAuthModelWithLockout">Model Class containing Definition of payload for MultiFactorAuthModel With Lockout API</param>
        /// <param name="secondFactorAuthenticationToken">A Uniquely generated MFA identifier token after successful authentication</param>
        /// <param name="fields">The fields parameter filters the API response so that the response only includes a specific set of fields</param>
        /// <param name="smsTemplate2FA">SMS Template Name</param>
        /// <returns>Complete user UserProfile data</returns>
        /// 9.12

        public ApiResponse<AccessToken<Identity>> MFAValidateOTPByPhone(MultiFactorAuthModelWithLockout multiFactorAuthModelWithLockout, string secondFactorAuthenticationToken,
        string fields = "", string smsTemplate2FA = null)
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

            var resourcePath = "identity/v2/auth/login/2fa/verification/otp";
            
            return ConfigureAndExecute<AccessToken<Identity>>(HttpMethod.PUT, resourcePath, queryParameters, ConvertToJson(multiFactorAuthModelWithLockout));
        }
        /// <summary>
        /// This API is used to login via Multi-factor-authentication by passing the google authenticator code.
        /// </summary>
        /// <param name="googleAuthenticatorCode">The code generated by google authenticator app after scanning QR code</param>
        /// <param name="secondFactorAuthenticationToken">A Uniquely generated MFA identifier token after successful authentication</param>
        /// <param name="fields">The fields parameter filters the API response so that the response only includes a specific set of fields</param>
        /// <param name="smsTemplate2FA">SMS Template Name</param>
        /// <returns>Complete user UserProfile data</returns>
        /// 9.13

        public ApiResponse<AccessToken<Identity>> MFAValidateGoogleAuthCode(string googleAuthenticatorCode, string secondFactorAuthenticationToken,
        string fields = "", string smsTemplate2FA = null)
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
            if (!string.IsNullOrWhiteSpace(smsTemplate2FA))
            {
               queryParameters.Add("smsTemplate2FA", smsTemplate2FA);
            }

            var bodyParameters = new BodyParameters
            {
                { "googleAuthenticatorCode", googleAuthenticatorCode }
            };

            var resourcePath = "identity/v2/auth/login/2fa/verification/googleauthenticatorcode";
            
            return ConfigureAndExecute<AccessToken<Identity>>(HttpMethod.PUT, resourcePath, queryParameters, ConvertToJson(bodyParameters));
        }
        /// <summary>
        /// This API is used to validate the backup code provided by the user and if valid, we return an access_token allowing the user to login incases where Multi-factor authentication (MFA) is enabled and the secondary factor is unavailable. When a user initially downloads the Backup codes, We generate 10 codes, each code can only be consumed once. if any user attempts to go over the number of invalid login attempts configured in the Dashboard then the account gets blocked automatically
        /// </summary>
        /// <param name="multiFactorAuthModelByBackupCode">Model Class containing Definition of payload for MultiFactorAuth By BackupCode API</param>
        /// <param name="secondFactorAuthenticationToken">A Uniquely generated MFA identifier token after successful authentication</param>
        /// <param name="fields">The fields parameter filters the API response so that the response only includes a specific set of fields</param>
        /// <returns>Complete user UserProfile data</returns>
        /// 9.14

        public ApiResponse<AccessToken<Identity>> MFAValidateBackupCode(MultiFactorAuthModelByBackupCode multiFactorAuthModelByBackupCode, string secondFactorAuthenticationToken,
        string fields = "")
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

            var resourcePath = "identity/v2/auth/login/2fa/verification/backupcode";
            
            return ConfigureAndExecute<AccessToken<Identity>>(HttpMethod.PUT, resourcePath, queryParameters, ConvertToJson(multiFactorAuthModelByBackupCode));
        }
        /// <summary>
        /// This API is used to update (if configured) the phone number used for Multi-factor authentication by sending the verification OTP to the provided phone number
        /// </summary>
        /// <param name="phoneNo2FA">Phone Number For 2FA</param>
        /// <param name="secondFactorAuthenticationToken">A Uniquely generated MFA identifier token after successful authentication</param>
        /// <param name="smsTemplate2FA">SMS Template Name</param>
        /// <returns>Response containing Definition for Complete SMS data</returns>
        /// 9.16

        public ApiResponse<SMSResponseData> MFAUpdatePhoneNumber(string phoneNo2FA, string secondFactorAuthenticationToken,
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
            
            return ConfigureAndExecute<SMSResponseData>(HttpMethod.PUT, resourcePath, queryParameters, ConvertToJson(bodyParameters));
        }
        /// <summary>
        /// This API is used to resending the verification OTP to the provided phone number
        /// </summary>
        /// <param name="secondFactorAuthenticationToken">A Uniquely generated MFA identifier token after successful authentication</param>
        /// <param name="smsTemplate2FA">SMS Template Name</param>
        /// <returns>Response containing Definition for Complete SMS data</returns>
        /// 9.17

        public ApiResponse<SMSResponseData> MFAResendOTP(string secondFactorAuthenticationToken, string smsTemplate2FA = null)
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
            
            return ConfigureAndExecute<SMSResponseData>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// This API resets the SMS Authenticator configurations on a given account via the UID.
        /// </summary>
        /// <param name="otpAuthenticator">Pass 'otpauthenticator' to remove SMS Authenticator</param>
        /// <param name="uid">UID, the unified identifier for each user account</param>
        /// <returns>Response containing Definition of Delete Request</returns>
        /// 18.21.1

        public ApiResponse<DeleteResponse> MFAResetSMSAuthenticatorByUid(bool otpAuthenticator, string uid)
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
            
            return ConfigureAndExecute<DeleteResponse>(HttpMethod.DELETE, resourcePath, queryParameters, ConvertToJson(bodyParameters));
        }
        /// <summary>
        /// This API resets the Google Authenticator configurations on a given account via the UID.
        /// </summary>
        /// <param name="googleAuthenticator">boolean type value,Enable google Authenticator Code.</param>
        /// <param name="uid">UID, the unified identifier for each user account</param>
        /// <returns>Response containing Definition of Delete Request</returns>
        /// 18.21.2

        public ApiResponse<DeleteResponse> MFAResetGoogleAuthenticatorByUid(bool googleAuthenticator, string uid)
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
            
            return ConfigureAndExecute<DeleteResponse>(HttpMethod.DELETE, resourcePath, queryParameters, ConvertToJson(bodyParameters));
        }
        /// <summary>
        /// This API is used to reset the backup codes on a given account via the UID. This API call will generate 10 new codes, each code can only be consumed once.
        /// </summary>
        /// <param name="uid">UID, the unified identifier for each user account</param>
        /// <returns>Response containing Definition of Complete Backup Code data</returns>
        /// 18.25

        public ApiResponse<BackupCodeResponse> MFABackupCodeByUid(string uid)
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
            
            return ConfigureAndExecute<BackupCodeResponse>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// This API is used to reset the backup codes on a given account via the UID. This API call will generate 10 new codes, each code can only be consumed once.
        /// </summary>
        /// <param name="uid">UID, the unified identifier for each user account</param>
        /// <returns>Response containing Definition of Complete Backup Code data</returns>
        /// 18.26

        public ApiResponse<BackupCodeResponse> MFAResetBackupCodeByUid(string uid)
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
            
            return ConfigureAndExecute<BackupCodeResponse>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
    }
}