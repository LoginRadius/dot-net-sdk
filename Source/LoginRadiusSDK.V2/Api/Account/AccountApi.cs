//-----------------------------------------------------------------------
// <copyright file="AccountApi.cs" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2019 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using LoginRadiusSDK.V2.Common;
using System.Threading.Tasks;
using LoginRadiusSDK.V2.Util;
using LoginRadiusSDK.V2.Models.ResponseModels.OtherObjects;
using LoginRadiusSDK.V2.Models.ResponseModels.UserProfile;
using LoginRadiusSDK.V2.Models.RequestModels;
using LoginRadiusSDK.V2.Models.ResponseModels;

namespace LoginRadiusSDK.V2.Api.Account
{
    public class AccountApi : LoginRadiusResource
    {
        /// <summary>
        /// This API is used to update the information of existing accounts in your Cloud Storage. See our Advanced API Usage section <a href='https://www.loginradius.com/docs/api/v2/customer-identity-api/advanced-api-usage'>Here</a> for more capabilities.
        /// </summary>
        /// <param name="accountUserProfileUpdateModel">Model Class containing Definition of payload for Account Update API</param>
        /// <param name="uid">UID, the unified identifier for each user account</param>
        /// <param name="fields">The fields parameter filters the API response so that the response only includes a specific set of fields</param>
        /// <param name="nullSupport">Boolean, pass true if you wish to update any user profile field with a NULL value, You can get the details <a href='https://www.loginradius.com/docs/api/v2/customer-identity-api/advanced-api-usage#nullsupport0'>Here</a></param>
        /// <returns>Response containing Definition for Complete profile data</returns>
        /// 18.15

        public async Task<ApiResponse<Identity>> UpdateAccountByUid(object payload, string uid,
        string fields = "", bool? nullSupport = null)
        {
            if (payload == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(payload));
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
            if (!string.IsNullOrWhiteSpace(fields))
            {
               queryParameters.Add("fields", fields);
            }
            if (nullSupport != false)
            {
               queryParameters.Add("nullSupport", nullSupport.ToString());
            }

            var resourcePath = $"identity/v2/manage/account/{uid}";
            
            return await ConfigureAndExecute<Identity>(HttpMethod.PUT, resourcePath, queryParameters, ConvertToJson(payload));
        }

        /// <summary>
        /// This API is used to retrieve all of the accepted Policies by the user, associated with their UID.
        /// </summary>
        /// <param name="uid">UID, the unified identifier for each user account</param>
        /// <returns>Complete Policy History data</returns>
        /// 15.1.1

        public async Task<ApiResponse<PrivacyPolicyHistoryResponse>> GetPrivacyPolicyHistoryByUid(string uid)
        {
            if (string.IsNullOrWhiteSpace(uid))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(uid));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "apiSecret", ConfigDictionary[LRConfigConstants.LoginRadiusApiSecret] }
            };

            var resourcePath = $"identity/v2/manage/account/{uid}/privacypolicy/history";
            
            return await ConfigureAndExecute<PrivacyPolicyHistoryResponse>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// This API is used to create an account in Cloud Storage. This API bypass the normal email verification process and manually creates the user. <br><br>In order to use this API, you need to format a JSON request body with all of the mandatory fields
        /// </summary>
        /// <param name="accountCreateModel">Model Class containing Definition of payload for Account Create API</param>
        /// <param name="fields">The fields parameter filters the API response so that the response only includes a specific set of fields</param>
        /// <returns>Response containing Definition for Complete profile data</returns>
        /// 18.1

        public async Task<ApiResponse<Identity>> CreateAccount(AccountCreateModel accountCreateModel, string fields = "")
        {
            if (accountCreateModel == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(accountCreateModel));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "apiSecret", ConfigDictionary[LRConfigConstants.LoginRadiusApiSecret] }
            };
            if (!string.IsNullOrWhiteSpace(fields))
            {
               queryParameters.Add("fields", fields);
            }

            var resourcePath = "identity/v2/manage/account";
            
            return await ConfigureAndExecute<Identity>(HttpMethod.POST, resourcePath, queryParameters, ConvertToJson(accountCreateModel));
        }
        /// <summary>
        /// This API is used to retrieve all of the profile data, associated with the specified account by email in Cloud Storage.
        /// </summary>
        /// <param name="email">Email of the user</param>
        /// <param name="fields">The fields parameter filters the API response so that the response only includes a specific set of fields</param>
        /// <returns>Response containing Definition for Complete profile data</returns>
        /// 18.2

        public async Task<ApiResponse<Identity>> GetAccountProfileByEmail(string email, string fields = "")
        {
            if (string.IsNullOrWhiteSpace(email))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(email));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "apiSecret", ConfigDictionary[LRConfigConstants.LoginRadiusApiSecret] },
                { "email", email }
            };
            if (!string.IsNullOrWhiteSpace(fields))
            {
               queryParameters.Add("fields", fields);
            }

            var resourcePath = "identity/v2/manage/account";
            
            return await ConfigureAndExecute<Identity>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// This API is used to retrieve all of the profile data associated with the specified account by user name in Cloud Storage.
        /// </summary>
        /// <param name="userName">UserName of the user</param>
        /// <param name="fields">The fields parameter filters the API response so that the response only includes a specific set of fields</param>
        /// <returns>Response containing Definition for Complete profile data</returns>
        /// 18.3

        public async Task<ApiResponse<Identity>> GetAccountProfileByUserName(string userName, string fields = "")
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(userName));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "apiSecret", ConfigDictionary[LRConfigConstants.LoginRadiusApiSecret] },
                { "userName", userName }
            };
            if (!string.IsNullOrWhiteSpace(fields))
            {
               queryParameters.Add("fields", fields);
            }

            var resourcePath = "identity/v2/manage/account";
            
            return await ConfigureAndExecute<Identity>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// This API is used to retrieve all of the profile data, associated with the account by phone number in Cloud Storage.
        /// </summary>
        /// <param name="phone">The Registered Phone Number</param>
        /// <param name="fields">The fields parameter filters the API response so that the response only includes a specific set of fields</param>
        /// <returns>Response containing Definition for Complete profile data</returns>
        /// 18.4

        public async Task<ApiResponse<Identity>> GetAccountProfileByPhone(string phone, string fields = "")
        {
            if (string.IsNullOrWhiteSpace(phone))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(phone));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "apiSecret", ConfigDictionary[LRConfigConstants.LoginRadiusApiSecret] },
                { "phone", phone }
            };
            if (!string.IsNullOrWhiteSpace(fields))
            {
               queryParameters.Add("fields", fields);
            }

            var resourcePath = "identity/v2/manage/account";
            
            return await ConfigureAndExecute<Identity>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// This API is used to retrieve all of the profile data, associated with the account by uid in Cloud Storage.
        /// </summary>
        /// <param name="uid">UID, the unified identifier for each user account</param>
        /// <param name="fields">The fields parameter filters the API response so that the response only includes a specific set of fields</param>
        /// <returns>Response containing Definition for Complete profile data</returns>
        /// 18.5

        public async Task<ApiResponse<Identity>> GetAccountProfileByUid(string uid, string fields = "")
        {
            if (string.IsNullOrWhiteSpace(uid))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(uid));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "apiSecret", ConfigDictionary[LRConfigConstants.LoginRadiusApiSecret] }
            };
            if (!string.IsNullOrWhiteSpace(fields))
            {
               queryParameters.Add("fields", fields);
            }

            var resourcePath = $"identity/v2/manage/account/{uid}";
            
            return await ConfigureAndExecute<Identity>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// This API is used to update the information of existing accounts in your Cloud Storage. See our Advanced API Usage section <a href='https://www.loginradius.com/docs/api/v2/customer-identity-api/advanced-api-usage/'>Here</a> for more capabilities.
        /// </summary>
        /// <param name="accountUserProfileUpdateModel">Model Class containing Definition of payload for Account Update API</param>
        /// <param name="uid">UID, the unified identifier for each user account</param>
        /// <param name="fields">The fields parameter filters the API response so that the response only includes a specific set of fields</param>
        /// <returns>Response containing Definition for Complete profile data</returns>
        /// 18.15

        public async Task<ApiResponse<Identity>> UpdateAccountByUid(AccountUserProfileUpdateModel accountUserProfileUpdateModel, string uid,
        string fields = "")
        {
            if (accountUserProfileUpdateModel == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(accountUserProfileUpdateModel));
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
            if (!string.IsNullOrWhiteSpace(fields))
            {
               queryParameters.Add("fields", fields);
            }

            var resourcePath = $"identity/v2/manage/account/{uid}";
            
            return await ConfigureAndExecute<Identity>(HttpMethod.PUT, resourcePath, queryParameters, ConvertToJson(accountUserProfileUpdateModel));
        }
        /// <summary>
        /// This API is used to update the PhoneId by using the Uid's. Admin can update the PhoneId's for both the verified and unverified profiles. It will directly replace the PhoneId and bypass the OTP verification process.
        /// </summary>
        /// <param name="phone">Phone number</param>
        /// <param name="uid">UID, the unified identifier for each user account</param>
        /// <param name="fields">The fields parameter filters the API response so that the response only includes a specific set of fields</param>
        /// <returns>Response containing Definition for Complete profile data</returns>
        /// 18.16

        public async Task<ApiResponse<Identity>> UpdatePhoneIDByUid(string phone, string uid,
        string fields = "")
        {
            if (string.IsNullOrWhiteSpace(phone))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(phone));
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
            if (!string.IsNullOrWhiteSpace(fields))
            {
               queryParameters.Add("fields", fields);
            }

            var bodyParameters = new BodyParameters
            {
                { "phone", phone }
            };

            var resourcePath = $"identity/v2/manage/account/{uid}/phoneid";
            
            return await ConfigureAndExecute<Identity>(HttpMethod.PUT, resourcePath, queryParameters, ConvertToJson(bodyParameters));
        }
        /// <summary>
        /// This API use to retrive the hashed password of a specified account in Cloud Storage.
        /// </summary>
        /// <param name="uid">UID, the unified identifier for each user account</param>
        /// <returns>Response containing Definition for Complete PasswordHash data</returns>
        /// 18.17

        public async Task<ApiResponse<UserPasswordHash>> GetAccountPasswordHashByUid(string uid)
        {
            if (string.IsNullOrWhiteSpace(uid))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(uid));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "apiSecret", ConfigDictionary[LRConfigConstants.LoginRadiusApiSecret] }
            };

            var resourcePath = $"identity/v2/manage/account/{uid}/password";
            
            return await ConfigureAndExecute<UserPasswordHash>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// This API is used to set the password of an account in Cloud Storage.
        /// </summary>
        /// <param name="password">New password</param>
        /// <param name="uid">UID, the unified identifier for each user account</param>
        /// <returns>Response containing Definition for Complete PasswordHash data</returns>
        /// 18.18

        public async Task<ApiResponse<UserPasswordHash>> SetAccountPasswordByUid(string password, string uid)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(password));
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

            var bodyParameters = new BodyParameters
            {
                { "password", password }
            };

            var resourcePath = $"identity/v2/manage/account/{uid}/password";
            
            return await ConfigureAndExecute<UserPasswordHash>(HttpMethod.PUT, resourcePath, queryParameters, ConvertToJson(bodyParameters));
        }
        /// <summary>
        /// This API deletes the Users account and allows them to re-register for a new account.
        /// </summary>
        /// <param name="uid">UID, the unified identifier for each user account</param>
        /// <returns>Response containing Definition of Delete Request</returns>
        /// 18.19

        public async Task<ApiResponse<DeleteResponse>> DeleteAccountByUid(string uid)
        {
            if (string.IsNullOrWhiteSpace(uid))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(uid));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "apiSecret", ConfigDictionary[LRConfigConstants.LoginRadiusApiSecret] }
            };

            var resourcePath = $"identity/v2/manage/account/{uid}";
            
            return await ConfigureAndExecute<DeleteResponse>(HttpMethod.DELETE, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// This API is used to invalidate the Email Verification status on an account.
        /// </summary>
        /// <param name="uid">UID, the unified identifier for each user account</param>
        /// <param name="emailTemplate">Email template name</param>
        /// <param name="verificationUrl">Email verification url</param>
        /// <returns>Response containing Definition of Complete Validation data</returns>
        /// 18.20

        public async Task<ApiResponse<PostResponse>> InvalidateAccountEmailVerification(string uid, string emailTemplate = "",
        string verificationUrl = "")
        {
            if (string.IsNullOrWhiteSpace(uid))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(uid));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "apiSecret", ConfigDictionary[LRConfigConstants.LoginRadiusApiSecret] }
            };
            if (!string.IsNullOrWhiteSpace(emailTemplate))
            {
               queryParameters.Add("emailTemplate", emailTemplate);
            }
            if (!string.IsNullOrWhiteSpace(verificationUrl))
            {
               queryParameters.Add("verificationUrl", verificationUrl);
            }

            var resourcePath = $"identity/v2/manage/account/{uid}/invalidateemail";
            
            return await ConfigureAndExecute<PostResponse>(HttpMethod.PUT, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// This API Returns a Forgot Password Token it can also be used to send a Forgot Password email to the customer. Note: If you have the UserName workflow enabled, you may replace the 'email' parameter with 'username' in the body.
        /// </summary>
        /// <param name="email">user's email</param>
        /// <param name="emailTemplate">Email template name</param>
        /// <param name="resetPasswordUrl">Url to which user should get re-directed to for resetting the password</param>
        /// <param name="sendEmail">If set to true, the API will also send a Forgot Password email to the customer, bypassing any Bot Protection challenges that they are faced with.</param>
        /// <returns>Response containing Definition of Complete Forgot Password data</returns>
        /// 18.22

        public async Task<ApiResponse<ForgotPasswordResponse>> GetForgotPasswordToken(string email, string emailTemplate = null,
        string resetPasswordUrl = null, bool? sendEmail = null)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(email));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "apiSecret", ConfigDictionary[LRConfigConstants.LoginRadiusApiSecret] }
            };
            if (!string.IsNullOrWhiteSpace(emailTemplate))
            {
               queryParameters.Add("emailTemplate", emailTemplate);
            }
            if (!string.IsNullOrWhiteSpace(resetPasswordUrl))
            {
               queryParameters.Add("resetPasswordUrl", resetPasswordUrl);
            }
            if (sendEmail != false)
            {
               queryParameters.Add("sendEmail", sendEmail.ToString());
            }

            var bodyParameters = new BodyParameters
            {
                { "email", email }
            };

            var resourcePath = "identity/v2/manage/account/forgot/token";
            
            return await ConfigureAndExecute<ForgotPasswordResponse>(HttpMethod.POST, resourcePath, queryParameters, ConvertToJson(bodyParameters));
        }
        /// <summary>
        /// This API Returns an Email Verification token.
        /// </summary>
        /// <param name="email">user's email</param>
        /// <returns>Response containing Definition of Complete Verification data</returns>
        /// 18.23

        public async Task<ApiResponse<EmailVerificationTokenResponse>> GetEmailVerificationToken(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(email));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "apiSecret", ConfigDictionary[LRConfigConstants.LoginRadiusApiSecret] }
            };

            var bodyParameters = new BodyParameters
            {
                { "email", email }
            };

            var resourcePath = "identity/v2/manage/account/verify/token";
            
            return await ConfigureAndExecute<EmailVerificationTokenResponse>(HttpMethod.POST, resourcePath, queryParameters, ConvertToJson(bodyParameters));
        }
        /// <summary>
        /// The API is used to get LoginRadius access token based on UID.
        /// </summary>
        /// <param name="uid">UID, the unified identifier for each user account</param>
        /// <returns>Response containing Definition of Complete Token data</returns>
        /// 18.24

        public async Task<ApiResponse<AccessToken>> GetAccessTokenByUid(string uid)
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

            var resourcePath = "identity/v2/manage/account/access_token";
            
            return await ConfigureAndExecute<AccessToken>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// This API Allows you to reset the phone no verification of an end user’s account.
        /// </summary>
        /// <param name="uid">UID, the unified identifier for each user account</param>
        /// <param name="smsTemplate">SMS Template name</param>
        /// <returns>Response containing Definition of Complete Validation data</returns>
        /// 18.27

        public async Task<ApiResponse<PostResponse>> ResetPhoneIDVerificationByUid(string uid, string smsTemplate = "")
        {
            if (string.IsNullOrWhiteSpace(uid))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(uid));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "apiSecret", ConfigDictionary[LRConfigConstants.LoginRadiusApiSecret] }
            };
            if (!string.IsNullOrWhiteSpace(smsTemplate))
            {
               queryParameters.Add("smsTemplate", smsTemplate);
            }

            var resourcePath = $"identity/v2/manage/account/{uid}/invalidatephone";
            
            return await ConfigureAndExecute<PostResponse>(HttpMethod.PUT, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// This API is used to add/upsert another emails in account profile by different-different email types. If the email type is same then it will simply update the existing email, otherwise it will add a new email in Email array.
        /// </summary>
        /// <param name="upsertEmailModel">Model Class containing Definition of payload for UpsertEmail Property</param>
        /// <param name="uid">UID, the unified identifier for each user account</param>
        /// <param name="fields">The fields parameter filters the API response so that the response only includes a specific set of fields</param>
        /// <returns>Response containing Definition for Complete profile data</returns>
        /// 18.29

        public async Task<ApiResponse<Identity>> UpsertEmail(UpsertEmailModel upsertEmailModel, string uid,
        string fields = "")
        {
            if (upsertEmailModel == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(upsertEmailModel));
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
            if (!string.IsNullOrWhiteSpace(fields))
            {
               queryParameters.Add("fields", fields);
            }

            var resourcePath = $"identity/v2/manage/account/{uid}/email";
            
            return await ConfigureAndExecute<Identity>(HttpMethod.PUT, resourcePath, queryParameters, ConvertToJson(upsertEmailModel));
        }
        /// <summary>
        /// Use this API to Remove emails from a user Account
        /// </summary>
        /// <param name="email">user's email</param>
        /// <param name="uid">UID, the unified identifier for each user account</param>
        /// <param name="fields">The fields parameter filters the API response so that the response only includes a specific set of fields</param>
        /// <returns>Response containing Definition for Complete profile data</returns>
        /// 18.30

        public async Task<ApiResponse<Identity>> RemoveEmail(string email, string uid,
        string fields = "")
        {
            if (string.IsNullOrWhiteSpace(email))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(email));
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
            if (!string.IsNullOrWhiteSpace(fields))
            {
               queryParameters.Add("fields", fields);
            }

            var bodyParameters = new BodyParameters
            {
                { "email", email }
            };

            var resourcePath = $"identity/v2/manage/account/{uid}/email";
            
            return await ConfigureAndExecute<Identity>(HttpMethod.DELETE, resourcePath, queryParameters, ConvertToJson(bodyParameters));
        }
        /// <summary>
        /// This API is used to refresh an access token via it's associated refresh token.
        /// </summary>
        /// <param name="refreshToken">LoginRadius refresh token</param>
        /// <returns>Response containing Definition of Complete Token data</returns>
        /// 18.31

        public async Task<ApiResponse<AccessToken>> RefreshAccessTokenByRefreshToken(string refreshToken)
        {
            if (string.IsNullOrWhiteSpace(refreshToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(refreshToken));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "apiSecret", ConfigDictionary[LRConfigConstants.LoginRadiusApiSecret] },
                { "refresh_Token", refreshToken }
            };

            var resourcePath = "identity/v2/manage/account/access_token/refresh";
            
            return await ConfigureAndExecute<AccessToken>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// The Revoke Refresh Access Token API is used to revoke a refresh token or the Provider Access Token, revoking an existing refresh token will invalidate the refresh token but the associated access token will work until the expiry.
        /// </summary>
        /// <param name="refreshToken">LoginRadius refresh token</param>
        /// <returns>Response containing Definition of Delete Request</returns>
        /// 18.32

        public async Task<ApiResponse<DeleteResponse>> RevokeRefreshToken(string refreshToken)
        {
            if (string.IsNullOrWhiteSpace(refreshToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(refreshToken));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "apiSecret", ConfigDictionary[LRConfigConstants.LoginRadiusApiSecret] },
                { "refresh_Token", refreshToken }
            };

            var resourcePath = "identity/v2/manage/account/access_token/refresh/revoke";
            
            return await ConfigureAndExecute<DeleteResponse>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// Note: This is intended for specific workflows where an email may be associated to multiple UIDs. This API is used to retrieve all of the identities (UID and Profiles), associated with a specified email in Cloud Storage.
        /// </summary>
        /// <param name="email">Email of the user</param>
        /// <param name="fields">The fields parameter filters the API response so that the response only includes a specific set of fields</param>
        /// <returns>Complete user Identity data</returns>
        /// 18.35

        public async Task<ApiResponse<ListReturn<Identity>>> GetAccountIdentitiesByEmail(string email, string fields = "")
        {
            if (string.IsNullOrWhiteSpace(email))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(email));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "apiSecret", ConfigDictionary[LRConfigConstants.LoginRadiusApiSecret] },
                { "email", email }
            };
            if (!string.IsNullOrWhiteSpace(fields))
            {
               queryParameters.Add("fields", fields);
            }

            var resourcePath = "identity/v2/manage/account/identities";
            
            return await ConfigureAndExecute<ListReturn<Identity>>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// This API is used to delete all user profiles associated with an Email.
        /// </summary>
        /// <param name="email">Email of the user</param>
        /// <returns>Response containing Definition of Delete Request</returns>
        /// 18.36

        public async Task<ApiResponse<DeleteResponse>> AccountDeleteByEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(email));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "apiSecret", ConfigDictionary[LRConfigConstants.LoginRadiusApiSecret] },
                { "email", email }
            };

            var resourcePath = "identity/v2/manage/account";
            
            return await ConfigureAndExecute<DeleteResponse>(HttpMethod.DELETE, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// This API is used to update a user's Uid. It will update all profiles, custom objects and consent management logs associated with the Uid.
        /// </summary>
        /// <param name="updateUidModel">Payload containing Update UID</param>
        /// <param name="uid">UID, the unified identifier for each user account</param>
        /// <returns>Response containing Definition of Complete Validation data</returns>
        /// 18.41

        public async Task<ApiResponse<PostResponse>> AccountUpdateUid(UpdateUidModel updateUidModel, string uid)
        {
            if (updateUidModel == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(updateUidModel));
            }
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

            var resourcePath = "identity/v2/manage/account/uid";
            
            return await ConfigureAndExecute<PostResponse>(HttpMethod.PUT, resourcePath, queryParameters, ConvertToJson(updateUidModel));
        }
    }
}