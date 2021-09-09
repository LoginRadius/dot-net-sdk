//-----------------------------------------------------------------------
// <copyright file="AuthenticationApi.cs" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2019 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using LoginRadiusSDK.V2.Common;
using System.Threading.Tasks;
using LoginRadiusSDK.V2.Util;
using LoginRadiusSDK.V2.Models.ResponseModels;
using LoginRadiusSDK.V2.Models.ResponseModels.OtherObjects;
using LoginRadiusSDK.V2.Models.ResponseModels.UserProfile;
using LoginRadiusSDK.V2.Models.RequestModels;

namespace LoginRadiusSDK.V2.Api.Authentication
{
    public class AuthenticationApi : LoginRadiusResource
    {
        /// <summary>
        /// This API is used to update the user's profile by passing the access_token.
        /// </summary>
        /// <param name="accessToken">Uniquely generated identifier key by LoginRadius that is activated after successful authentication.</param>
        /// <param name="userProfileUpdateModel">Model Class containing Definition of payload for User Profile update API</param>
        /// <param name="emailTemplate">Email template name</param>
        /// <param name="fields">The fields parameter filters the API response so that the response only includes a specific set of fields</param>
        /// <param name="nullSupport">>Boolean, pass true if you wish to update any user profile field with a NULL value, You can get the details <a href='https://www.loginradius.com/docs/api/v2/customer-identity-api/advanced-api-usage#nullsupport0'>Here</a></param>
        /// <param name="smsTemplate">SMS Template name</param>
        /// <param name="verificationUrl">Email verification url</param>
        /// <returns>Response containing Definition of Complete Validation and UserProfile data</returns>
        /// 5.4

        public async Task<ApiResponse<UserProfilePostResponse<Identity>>> UpdateProfileByAccessToken(string accessToken, object payload,
        string emailTemplate = null, string fields = "", bool? nullSupport = null, string smsTemplate = null, string verificationUrl = null)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
            {
                throw new ArgumentException(BaseConstants.ValidationMessage, nameof(accessToken));
            }
            if (payload == null)
            {
                throw new ArgumentException(BaseConstants.ValidationMessage, nameof(payload));
            }
            var queryParameters = new QueryParameters
            {
                { "access_token", accessToken },
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
            if (nullSupport != false)
            {
                queryParameters.Add("nullSupport", nullSupport.ToString());
            }
            if (!string.IsNullOrWhiteSpace(smsTemplate))
            {
                queryParameters.Add("smsTemplate", smsTemplate);
            }
            if (!string.IsNullOrWhiteSpace(verificationUrl))
            {
                queryParameters.Add("verificationUrl", verificationUrl);
            }

            var resourcePath = "identity/v2/auth/account";

            return await ConfigureAndExecute<UserProfilePostResponse<Identity>>(HttpMethod.PUT, resourcePath, queryParameters, ConvertToJson(payload));
        }

        /// <summary>
        /// This API is used to retrieve the list of questions that are configured on the respective LoginRadius site.
        /// </summary>
        /// <param name="email">Email of the user</param>
        /// <returns>Response containing Definition for Complete SecurityQuestions data</returns>
        /// 2.1

        public async Task<ApiResponse<List<SecurityQuestions>>> GetSecurityQuestionsByEmail(string email)
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

            var resourcePath = "identity/v2/auth/securityquestion/email";
            
            return await ConfigureAndExecute<List<SecurityQuestions>>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// This API is used to retrieve the list of questions that are configured on the respective LoginRadius site.
        /// </summary>
        /// <param name="userName">UserName of the user</param>
        /// <returns>Response containing Definition for Complete SecurityQuestions data</returns>
        /// 2.2

        public async Task<ApiResponse<List<SecurityQuestions>>> GetSecurityQuestionsByUserName(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(userName));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "userName", userName }
            };

            var resourcePath = "identity/v2/auth/securityquestion/username";
            
            return await ConfigureAndExecute<List<SecurityQuestions>>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// This API is used to retrieve the list of questions that are configured on the respective LoginRadius site.
        /// </summary>
        /// <param name="phone">The Registered Phone Number</param>
        /// <returns>Response containing Definition for Complete SecurityQuestions data</returns>
        /// 2.3

        public async Task<ApiResponse<List<SecurityQuestions>>> GetSecurityQuestionsByPhone(string phone)
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

            var resourcePath = "identity/v2/auth/securityquestion/phone";
            
            return await ConfigureAndExecute<List<SecurityQuestions>>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// This API is used to retrieve the list of questions that are configured on the respective LoginRadius site.
        /// </summary>
        /// <param name="accessToken">Uniquely generated identifier key by LoginRadius that is activated after successful authentication.</param>
        /// <returns>Response containing Definition for Complete SecurityQuestions data</returns>
        /// 2.4

        public async Task<ApiResponse<List<SecurityQuestions>>> GetSecurityQuestionsByAccessToken(string accessToken)
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

            var resourcePath = "identity/v2/auth/securityquestion/accesstoken";
            
            return await ConfigureAndExecute<List<SecurityQuestions>>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// This api validates access token, if valid then returns a response with its expiry otherwise error.
        /// </summary>
        /// <param name="accessToken">Uniquely generated identifier key by LoginRadius that is activated after successful authentication.</param>
        /// <returns>Response containing Definition of Complete Token data</returns>
        /// 4.1

        public async Task<ApiResponse<AccessToken>> AuthValidateAccessToken(string accessToken)
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

            var resourcePath = "identity/v2/auth/access_token/validate";
            
            return await ConfigureAndExecute<AccessToken>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// This api call invalidates the active access token or expires an access token's validity.
        /// </summary>
        /// <param name="accessToken">Uniquely generated identifier key by LoginRadius that is activated after successful authentication.</param>
        /// <param name="preventRefresh">Boolean value that when set as true, in addition of the access token being invalidated, it will no longer have the capability of being refreshed.</param>
        /// <returns>Response containing Definition of Complete Validation data</returns>
        /// 4.2

        public async Task<ApiResponse<PostResponse>> AuthInValidateAccessToken(string accessToken, bool preventRefresh = false)
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
            if (preventRefresh != false)
            {
               queryParameters.Add("preventRefresh", preventRefresh.ToString());
            }

            var resourcePath = "identity/v2/auth/access_token/invalidate";
            
            return await ConfigureAndExecute<PostResponse>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// This api call provide the active access token Information
        /// </summary>
        /// <param name="accessToken">Uniquely generated identifier key by LoginRadius that is activated after successful authentication.</param>
        /// <returns>Response containing Definition of Token Information</returns>
        /// 4.3

        public async Task<ApiResponse<TokenInfoResponseModel>> GetAccessTokenInfo(string accessToken)
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

            var resourcePath = "identity/v2/auth/access_token";
            
            return await ConfigureAndExecute<TokenInfoResponseModel>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// This API retrieves a copy of the user data based on the access token.
        /// </summary>
        /// <param name="accessToken">Uniquely generated identifier key by LoginRadius that is activated after successful authentication.</param>
        /// <param name="fields">The fields parameter filters the API response so that the response only includes a specific set of fields</param>
        /// <param name="emailTemplate"></param>
        /// <param name="verificationUrl"></param>
        /// <param name="welcomeEmailTemplate"></param>
        /// <returns>Response containing Definition for Complete profile data</returns>
        /// 5.2

        public async Task<ApiResponse<Identity>> GetProfileByAccessToken(string accessToken,string fields = "",
        string emailTemplate = null, string verificationUrl = null, string welcomeEmailTemplate = null)
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
            if (!string.IsNullOrWhiteSpace(fields))
            {
               queryParameters.Add("fields", fields);
            }
            if (!string.IsNullOrWhiteSpace(emailTemplate))
            {
               queryParameters.Add("emailTemplate", emailTemplate);
            }
            if (!string.IsNullOrWhiteSpace(verificationUrl))
            {
               queryParameters.Add("verificationUrl", verificationUrl);
            }
            if (!string.IsNullOrWhiteSpace(welcomeEmailTemplate))
            {
               queryParameters.Add("welcomeEmailTemplate", welcomeEmailTemplate);
            }

            var resourcePath = "identity/v2/auth/account";
            
            return await ConfigureAndExecute<Identity>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// This API sends a welcome email
        /// </summary>
        /// <param name="accessToken">Uniquely generated identifier key by LoginRadius that is activated after successful authentication.</param>
        /// <param name="welcomeEmailTemplate">Name of the welcome email template</param>
        /// <returns>Response containing Definition of Complete Validation data</returns>
        /// 5.3

        public async Task<ApiResponse<PostResponse>> SendWelcomeEmail(string accessToken, string welcomeEmailTemplate = null)
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
            if (!string.IsNullOrWhiteSpace(welcomeEmailTemplate))
            {
               queryParameters.Add("welcomeEmailTemplate", welcomeEmailTemplate);
            }

            var resourcePath = "identity/v2/auth/account/sendwelcomeemail";
            
            return await ConfigureAndExecute<PostResponse>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// This API is used to update the user's profile by passing the access token.
        /// </summary>
        /// <param name="accessToken">Uniquely generated identifier key by LoginRadius that is activated after successful authentication.</param>
        /// <param name="userProfileUpdateModel">Model Class containing Definition of payload for User Profile update API</param>
        /// <param name="emailTemplate">Email template name</param>
        /// <param name="fields">The fields parameter filters the API response so that the response only includes a specific set of fields</param>
        /// <param name="smsTemplate">SMS Template name</param>
        /// <param name="verificationUrl">Email verification url</param>
        /// <returns>Response containing Definition of Complete Validation and UserProfile data</returns>
        /// 5.4

        public async Task<ApiResponse<UserProfilePostResponse<Identity>>> UpdateProfileByAccessToken(string accessToken, UserProfileUpdateModel userProfileUpdateModel,
        string emailTemplate = null, string fields = "", string smsTemplate = null, string verificationUrl = null)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(accessToken));
            }
            if (userProfileUpdateModel == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(userProfileUpdateModel));
            }
            var queryParameters = new QueryParameters
            {
                { "access_token", accessToken },
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
            if (!string.IsNullOrWhiteSpace(smsTemplate))
            {
               queryParameters.Add("smsTemplate", smsTemplate);
            }
            if (!string.IsNullOrWhiteSpace(verificationUrl))
            {
               queryParameters.Add("verificationUrl", verificationUrl);
            }

            var resourcePath = "identity/v2/auth/account";
            
            return await ConfigureAndExecute<UserProfilePostResponse<Identity>>(HttpMethod.PUT, resourcePath, queryParameters, ConvertToJson(userProfileUpdateModel));
        }
        /// <summary>
        /// This API will send a confirmation email for account deletion to the customer's email when passed the customer's access token
        /// </summary>
        /// <param name="accessToken">Uniquely generated identifier key by LoginRadius that is activated after successful authentication.</param>
        /// <param name="deleteUrl">Url of the site</param>
        /// <param name="emailTemplate">Email template name</param>
        /// <returns>Response containing Definition of Delete Request</returns>
        /// 5.5

        public async Task<ApiResponse<DeleteRequestAcceptResponse>> DeleteAccountWithEmailConfirmation(string accessToken, string deleteUrl = null,
        string emailTemplate = null)
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
            if (!string.IsNullOrWhiteSpace(deleteUrl))
            {
               queryParameters.Add("deleteUrl", deleteUrl);
            }
            if (!string.IsNullOrWhiteSpace(emailTemplate))
            {
               queryParameters.Add("emailTemplate", emailTemplate);
            }

            var resourcePath = "identity/v2/auth/account";
            
            return await ConfigureAndExecute<DeleteRequestAcceptResponse>(HttpMethod.DELETE, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// This API is used to delete an account by passing it a delete token.
        /// </summary>
        /// <param name="deleteToken">Delete token received in the email</param>
        /// <returns>Response containing Definition of Complete Validation data</returns>
        /// 5.6

        public async Task<ApiResponse<PostResponse>> DeleteAccountByDeleteToken(string deleteToken)
        {
            if (string.IsNullOrWhiteSpace(deleteToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(deleteToken));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "deletetoken", deleteToken }
            };

            var resourcePath = "identity/v2/auth/account/delete";
            
            return await ConfigureAndExecute<PostResponse>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// This API is used to allow a customer with a valid access token to unlock their account provided that they successfully pass the prompted Bot Protection challenges. The Block or Suspend block types are not applicable for this API. For additional details see our Auth Security Configuration documentation.You are only required to pass the Post Parameters that correspond to the prompted challenges.
        /// </summary>
        /// <param name="accessToken">Uniquely generated identifier key by LoginRadius that is activated after successful authentication.</param>
        /// <param name="unlockProfileModel">Payload containing Unlock Profile API</param>
        /// <returns>Response containing Definition of Complete Validation data</returns>
        /// 5.15

        public async Task<ApiResponse<PostResponse>> UnlockAccountByToken(string accessToken, UnlockProfileModel unlockProfileModel)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(accessToken));
            }
            if (unlockProfileModel == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(unlockProfileModel));
            }
            var queryParameters = new QueryParameters
            {
                { "access_token", accessToken },
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] }
            };

            var resourcePath = "identity/v2/auth/account/unlock";
            
            return await ConfigureAndExecute<PostResponse>(HttpMethod.PUT, resourcePath, queryParameters, ConvertToJson(unlockProfileModel));
        }
        /// <summary>
        /// This API is used to get a user's profile using the clientGuid parameter if no callback feature enabled
        /// </summary>
        /// <param name="clientGuid">ClientGuid</param>
        /// <param name="emailTemplate">EmailTemplate</param>
        /// <param name="fields">Fields</param>
        /// <param name="verificationUrl">VerificationUrl</param>
        /// <param name="welcomeEmailTemplate">WelcomeEmailTemplate</param>
        /// <returns>Response containing User Profile Data and access token</returns>
        /// 5.16

        public async Task<ApiResponse<AccessToken<Identity>>> GetProfileByPing(string clientGuid, string emailTemplate = null,
        string fields = "", string verificationUrl = null, string welcomeEmailTemplate = null)
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
            if (!string.IsNullOrWhiteSpace(emailTemplate))
            {
               queryParameters.Add("emailTemplate", emailTemplate);
            }
            if (!string.IsNullOrWhiteSpace(fields))
            {
               queryParameters.Add("fields", fields);
            }
            if (!string.IsNullOrWhiteSpace(verificationUrl))
            {
               queryParameters.Add("verificationUrl", verificationUrl);
            }
            if (!string.IsNullOrWhiteSpace(welcomeEmailTemplate))
            {
               queryParameters.Add("welcomeEmailTemplate", welcomeEmailTemplate);
            }

            var resourcePath = "identity/v2/auth/account/ping";
            
            return await ConfigureAndExecute<AccessToken<Identity>>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// This API is used to check the email exists or not on your site.
        /// </summary>
        /// <param name="email">Email of the user</param>
        /// <returns>Response containing Definition Complete ExistResponse data</returns>
        /// 8.1

        public async Task<ApiResponse<ExistResponse>> CheckEmailAvailability(string email)
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

            var resourcePath = "identity/v2/auth/email";
            
            return await ConfigureAndExecute<ExistResponse>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// This API is used to verify the email of user. Note: This API will only return the full profile if you have 'Enable auto login after email verification' set in your LoginRadius Admin Console's Email Workflow settings under 'Verification Email'.
        /// </summary>
        /// <param name="verificationToken">Verification token received in the email</param>
        /// <param name="fields">The fields parameter filters the API response so that the response only includes a specific set of fields</param>
        /// <param name="url">Mention URL to log the main URL(Domain name) in Database.</param>
        /// <param name="welcomeEmailTemplate">Name of the welcome email template</param>
        /// <returns>Response containing Definition of Complete Validation, UserProfile data and Access Token</returns>
        /// 8.2

        public async Task<ApiResponse<UserProfilePostResponse<AccessToken<Identity>>>> VerifyEmail(string verificationToken, string fields = "",
        string url = null, string welcomeEmailTemplate = null)
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
            if (!string.IsNullOrWhiteSpace(fields))
            {
               queryParameters.Add("fields", fields);
            }
            if (!string.IsNullOrWhiteSpace(url))
            {
               queryParameters.Add("url", url);
            }
            if (!string.IsNullOrWhiteSpace(welcomeEmailTemplate))
            {
               queryParameters.Add("welcomeEmailTemplate", welcomeEmailTemplate);
            }

            var resourcePath = "identity/v2/auth/email";
            
            return await ConfigureAndExecute<UserProfilePostResponse<AccessToken<Identity>>>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// This API is used to verify the email of user when the OTP Email verification flow is enabled, please note that you must contact LoginRadius to have this feature enabled.
        /// </summary>
        /// <param name="emailVerificationByOtpModel">Model Class containing Definition for EmailVerificationByOtpModel API</param>
        /// <param name="fields">The fields parameter filters the API response so that the response only includes a specific set of fields</param>
        /// <param name="url">Mention URL to log the main URL(Domain name) in Database.</param>
        /// <param name="welcomeEmailTemplate">Name of the welcome email template</param>
        /// <returns>Response containing Definition of Complete Validation, UserProfile data and Access Token</returns>
        /// 8.3

        public async Task<ApiResponse<UserProfilePostResponse<AccessToken<Identity>>>> VerifyEmailByOTP(EmailVerificationByOtpModel emailVerificationByOtpModel, string fields = "",
        string url = null, string welcomeEmailTemplate = null)
        {
            if (emailVerificationByOtpModel == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(emailVerificationByOtpModel));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] }
            };
            if (!string.IsNullOrWhiteSpace(fields))
            {
               queryParameters.Add("fields", fields);
            }
            if (!string.IsNullOrWhiteSpace(url))
            {
               queryParameters.Add("url", url);
            }
            if (!string.IsNullOrWhiteSpace(welcomeEmailTemplate))
            {
               queryParameters.Add("welcomeEmailTemplate", welcomeEmailTemplate);
            }

            var resourcePath = "identity/v2/auth/email";
            
            return await ConfigureAndExecute<UserProfilePostResponse<AccessToken<Identity>>>(HttpMethod.PUT, resourcePath, queryParameters, ConvertToJson(emailVerificationByOtpModel));
        }
        /// <summary>
        /// This API is used to add additional emails to a user's account.
        /// </summary>
        /// <param name="accessToken">Uniquely generated identifier key by LoginRadius that is activated after successful authentication.</param>
        /// <param name="email">user's email</param>
        /// <param name="type">String to identify the type of parameter</param>
        /// <param name="emailTemplate">Email template name</param>
        /// <param name="verificationUrl">Email verification url</param>
        /// <returns>Response containing Definition of Complete Validation data</returns>
        /// 8.5

        public async Task<ApiResponse<PostResponse>> AddEmail(string accessToken, string email,
        string type, string emailTemplate = null, string verificationUrl = null)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(accessToken));
            }
            if (string.IsNullOrWhiteSpace(email))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(email));
            }
            if (string.IsNullOrWhiteSpace(type))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(type));
            }
            var queryParameters = new QueryParameters
            {
                { "access_token", accessToken },
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] }
            };
            if (!string.IsNullOrWhiteSpace(emailTemplate))
            {
               queryParameters.Add("emailTemplate", emailTemplate);
            }
            if (!string.IsNullOrWhiteSpace(verificationUrl))
            {
               queryParameters.Add("verificationUrl", verificationUrl);
            }

            var bodyParameters = new BodyParameters
            {
                { "email", email },
                { "type", type }
            };

            var resourcePath = "identity/v2/auth/email";
            
            return await ConfigureAndExecute<PostResponse>(HttpMethod.POST, resourcePath, queryParameters, ConvertToJson(bodyParameters));
        }
        /// <summary>
        /// This API is used to remove additional emails from a user's account.
        /// </summary>
        /// <param name="accessToken">Uniquely generated identifier key by LoginRadius that is activated after successful authentication.</param>
        /// <param name="email">user's email</param>
        /// <returns>Response containing Definition of Delete Request</returns>
        /// 8.6

        public async Task<ApiResponse<DeleteResponse>> RemoveEmail(string accessToken, string email)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(accessToken));
            }
            if (string.IsNullOrWhiteSpace(email))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(email));
            }
            var queryParameters = new QueryParameters
            {
                { "access_token", accessToken },
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] }
            };

            var bodyParameters = new BodyParameters
            {
                { "email", email }
            };

            var resourcePath = "identity/v2/auth/email";
            
            return await ConfigureAndExecute<DeleteResponse>(HttpMethod.DELETE, resourcePath, queryParameters, ConvertToJson(bodyParameters));
        }
        /// <summary>
        /// This API retrieves a copy of the user data based on the Email
        /// </summary>
        /// <param name="emailAuthenticationModel">Model Class containing Definition of payload for Email Authentication API</param>
        /// <param name="emailTemplate">Email template name</param>
        /// <param name="fields">The fields parameter filters the API response so that the response only includes a specific set of fields</param>
        /// <param name="loginUrl">Url where the user is logging from</param>
        /// <param name="verificationUrl">Email verification url</param>
        /// <returns>Response containing User Profile Data and access token</returns>
        /// 9.2.1

        public async Task<ApiResponse<AccessToken<Identity>>> LoginByEmail(EmailAuthenticationModel emailAuthenticationModel, string emailTemplate = null,
        string fields = "", string loginUrl = null, string verificationUrl = null)
        {
            if (emailAuthenticationModel == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(emailAuthenticationModel));
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
            if (!string.IsNullOrWhiteSpace(verificationUrl))
            {
               queryParameters.Add("verificationUrl", verificationUrl);
            }

            var resourcePath = "identity/v2/auth/login";
            
            return await ConfigureAndExecute<AccessToken<Identity>>(HttpMethod.POST, resourcePath, queryParameters, ConvertToJson(emailAuthenticationModel));
        }
        /// <summary>
        /// This API retrieves a copy of the user data based on the Username
        /// </summary>
        /// <param name="userNameAuthenticationModel">Model Class containing Definition of payload for Username Authentication API</param>
        /// <param name="emailTemplate">Email template name</param>
        /// <param name="fields">The fields parameter filters the API response so that the response only includes a specific set of fields</param>
        /// <param name="loginUrl">Url where the user is logging from</param>
        /// <param name="verificationUrl">Email verification url</param>
        /// <returns>Response containing User Profile Data and access token</returns>
        /// 9.2.2

        public async Task<ApiResponse<AccessToken<Identity>>> LoginByUserName(UserNameAuthenticationModel userNameAuthenticationModel, string emailTemplate = null,
        string fields = "", string loginUrl = null, string verificationUrl = null)
        {
            if (userNameAuthenticationModel == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(userNameAuthenticationModel));
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
            if (!string.IsNullOrWhiteSpace(verificationUrl))
            {
               queryParameters.Add("verificationUrl", verificationUrl);
            }

            var resourcePath = "identity/v2/auth/login";
            
            return await ConfigureAndExecute<AccessToken<Identity>>(HttpMethod.POST, resourcePath, queryParameters, ConvertToJson(userNameAuthenticationModel));
        }
        /// <summary>
        /// This API is used to send the reset password url to a specified account. Note: If you have the UserName workflow enabled, you may replace the 'email' parameter with 'username'
        /// </summary>
        /// <param name="email">user's email</param>
        /// <param name="resetPasswordUrl">Url to which user should get re-directed to for resetting the password</param>
        /// <param name="emailTemplate">Email template name</param>
        /// <returns>Response containing Definition of Complete Validation data</returns>
        /// 10.1

        public async Task<ApiResponse<PostResponse>> ForgotPassword(string email, string resetPasswordUrl,
        string emailTemplate = null)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(email));
            }
            if (string.IsNullOrWhiteSpace(resetPasswordUrl))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(resetPasswordUrl));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "resetPasswordUrl", resetPasswordUrl }
            };
            if (!string.IsNullOrWhiteSpace(emailTemplate))
            {
               queryParameters.Add("emailTemplate", emailTemplate);
            }

            var bodyParameters = new BodyParameters
            {
                { "email", email }
            };

            var resourcePath = "identity/v2/auth/password";
            
            return await ConfigureAndExecute<PostResponse>(HttpMethod.POST, resourcePath, queryParameters, ConvertToJson(bodyParameters));
        }
        /// <summary>
        /// This API is used to reset password for the specified account by security question
        /// </summary>
        /// <param name="resetPasswordBySecurityAnswerAndEmailModel">Model Class containing Definition of payload for ResetPasswordBySecurityAnswerAndEmail API</param>
        /// <returns>Response containing Definition of Validation data and access token</returns>
        /// 10.3.1

        public async Task<ApiResponse<UserProfilePostResponse<AccessToken>>> ResetPasswordBySecurityAnswerAndEmail(ResetPasswordBySecurityAnswerAndEmailModel resetPasswordBySecurityAnswerAndEmailModel)
        {
            if (resetPasswordBySecurityAnswerAndEmailModel == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(resetPasswordBySecurityAnswerAndEmailModel));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] }
            };

            var resourcePath = "identity/v2/auth/password/securityanswer";
            
            return await ConfigureAndExecute<UserProfilePostResponse<AccessToken>>(HttpMethod.PUT, resourcePath, queryParameters, ConvertToJson(resetPasswordBySecurityAnswerAndEmailModel));
        }
        /// <summary>
        /// This API is used to reset password for the specified account by security question
        /// </summary>
        /// <param name="resetPasswordBySecurityAnswerAndPhoneModel">Model Class containing Definition of payload for ResetPasswordBySecurityAnswerAndPhone API</param>
        /// <returns>Response containing Definition of Validation data and access token</returns>
        /// 10.3.2

        public async Task<ApiResponse<UserProfilePostResponse<AccessToken>>> ResetPasswordBySecurityAnswerAndPhone(ResetPasswordBySecurityAnswerAndPhoneModel resetPasswordBySecurityAnswerAndPhoneModel)
        {
            if (resetPasswordBySecurityAnswerAndPhoneModel == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(resetPasswordBySecurityAnswerAndPhoneModel));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] }
            };

            var resourcePath = "identity/v2/auth/password/securityanswer";
            
            return await ConfigureAndExecute<UserProfilePostResponse<AccessToken>>(HttpMethod.PUT, resourcePath, queryParameters, ConvertToJson(resetPasswordBySecurityAnswerAndPhoneModel));
        }
        /// <summary>
        /// This API is used to reset password for the specified account by security question
        /// </summary>
        /// <param name="resetPasswordBySecurityAnswerAndUserNameModel">Model Class containing Definition of payload for ResetPasswordBySecurityAnswerAndUserName API</param>
        /// <returns>Response containing Definition of Validation data and access token</returns>
        /// 10.3.3

        public async Task<ApiResponse<UserProfilePostResponse<AccessToken>>> ResetPasswordBySecurityAnswerAndUserName(ResetPasswordBySecurityAnswerAndUserNameModel resetPasswordBySecurityAnswerAndUserNameModel)
        {
            if (resetPasswordBySecurityAnswerAndUserNameModel == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(resetPasswordBySecurityAnswerAndUserNameModel));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] }
            };

            var resourcePath = "identity/v2/auth/password/securityanswer";
            
            return await ConfigureAndExecute<UserProfilePostResponse<AccessToken>>(HttpMethod.PUT, resourcePath, queryParameters, ConvertToJson(resetPasswordBySecurityAnswerAndUserNameModel));
        }
        /// <summary>
        /// This API is used to set a new password for the specified account.
        /// </summary>
        /// <param name="resetPasswordByResetTokenModel">Model Class containing Definition of payload for ResetToken API</param>
        /// <returns>Response containing Definition of Validation data and access token</returns>
        /// 10.7.1

        public async Task<ApiResponse<UserProfilePostResponse<AccessToken>>> ResetPasswordByResetToken(ResetPasswordByResetTokenModel resetPasswordByResetTokenModel)
        {
            if (resetPasswordByResetTokenModel == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(resetPasswordByResetTokenModel));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] }
            };

            var resourcePath = "identity/v2/auth/password/reset";
            
            return await ConfigureAndExecute<UserProfilePostResponse<AccessToken>>(HttpMethod.PUT, resourcePath, queryParameters, ConvertToJson(resetPasswordByResetTokenModel));
        }
        /// <summary>
        /// This API is used to set a new password for the specified account.
        /// </summary>
        /// <param name="resetPasswordByEmailAndOtpModel">Model Class containing Definition of payload for ResetPasswordByEmailAndOtp API</param>
        /// <returns>Response containing Definition of Validation data and access token</returns>
        /// 10.7.2

        public async Task<ApiResponse<UserProfilePostResponse<AccessToken>>> ResetPasswordByEmailOTP(ResetPasswordByEmailAndOtpModel resetPasswordByEmailAndOtpModel)
        {
            if (resetPasswordByEmailAndOtpModel == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(resetPasswordByEmailAndOtpModel));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] }
            };

            var resourcePath = "identity/v2/auth/password/reset";
            
            return await ConfigureAndExecute<UserProfilePostResponse<AccessToken>>(HttpMethod.PUT, resourcePath, queryParameters, ConvertToJson(resetPasswordByEmailAndOtpModel));
        }
        /// <summary>
        /// This API is used to set a new password for the specified account if you are using the username as the unique identifier in your workflow
        /// </summary>
        /// <param name="resetPasswordByUserNameModel">Model Class containing Definition of payload for ResetPasswordByUserName API</param>
        /// <returns>Response containing Definition of Validation data and access token</returns>
        /// 10.7.3

        public async Task<ApiResponse<UserProfilePostResponse<AccessToken>>> ResetPasswordByOTPAndUserName(ResetPasswordByUserNameModel resetPasswordByUserNameModel)
        {
            if (resetPasswordByUserNameModel == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(resetPasswordByUserNameModel));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] }
            };

            var resourcePath = "identity/v2/auth/password/reset";
            
            return await ConfigureAndExecute<UserProfilePostResponse<AccessToken>>(HttpMethod.PUT, resourcePath, queryParameters, ConvertToJson(resetPasswordByUserNameModel));
        }
        /// <summary>
        /// This API is used to change the accounts password based on the previous password
        /// </summary>
        /// <param name="accessToken">Uniquely generated identifier key by LoginRadius that is activated after successful authentication.</param>
        /// <param name="newPassword">New password</param>
        /// <param name="oldPassword">User's current password</param>
        /// <returns>Response containing Definition of Complete Validation data</returns>
        /// 10.8

        public async Task<ApiResponse<PostResponse>> ChangePassword(string accessToken, string newPassword,
        string oldPassword)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(accessToken));
            }
            if (string.IsNullOrWhiteSpace(newPassword))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(newPassword));
            }
            if (string.IsNullOrWhiteSpace(oldPassword))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(oldPassword));
            }
            var queryParameters = new QueryParameters
            {
                { "access_token", accessToken },
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] }
            };

            var bodyParameters = new BodyParameters
            {
                { "newPassword", newPassword },
                { "oldPassword", oldPassword }
            };

            var resourcePath = "identity/v2/auth/password/change";
            
            return await ConfigureAndExecute<PostResponse>(HttpMethod.PUT, resourcePath, queryParameters, ConvertToJson(bodyParameters));
        }
        /// <summary>
        /// This API is used to unlink up a social provider account with the specified account based on the access token and the social providers user access token. The unlinked account will automatically get removed from your database.
        /// </summary>
        /// <param name="accessToken">Access_Token</param>
        /// <param name="provider">Name of the provider</param>
        /// <param name="providerId">Unique ID of the linked account</param>
        /// <returns>Response containing Definition of Delete Request</returns>
        /// 12.2

        public async Task<ApiResponse<DeleteResponse>> UnlinkSocialIdentities(string accessToken, string provider,
        string providerId)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(accessToken));
            }
            if (string.IsNullOrWhiteSpace(provider))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(provider));
            }
            if (string.IsNullOrWhiteSpace(providerId))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(providerId));
            }
            var queryParameters = new QueryParameters
            {
                { "access_token", accessToken },
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] }
            };

            var bodyParameters = new BodyParameters
            {
                { "provider", provider },
                { "providerId", providerId }
            };

            var resourcePath = "identity/v2/auth/socialidentity";
            
            return await ConfigureAndExecute<DeleteResponse>(HttpMethod.DELETE, resourcePath, queryParameters, ConvertToJson(bodyParameters));
        }
        /// <summary>
        /// This API is used to link up a social provider account with an existing LoginRadius account on the basis of access token and the social providers user access token.
        /// </summary>
        /// <param name="accessToken">Uniquely generated identifier key by LoginRadius that is activated after successful authentication.</param>
        /// <param name="candidateToken">Access token of the account to be linked</param>
        /// <returns>Response containing Definition of Complete Validation data</returns>
        /// 12.4

        public async Task<ApiResponse<PostResponse>> LinkSocialIdentities(string accessToken, string candidateToken)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(accessToken));
            }
            if (string.IsNullOrWhiteSpace(candidateToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(candidateToken));
            }
            var queryParameters = new QueryParameters
            {
                { "access_token", accessToken },
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] }
            };

            var bodyParameters = new BodyParameters
            {
                { "candidateToken", candidateToken }
            };

            var resourcePath = "identity/v2/auth/socialidentity";
            
            return await ConfigureAndExecute<PostResponse>(HttpMethod.POST, resourcePath, queryParameters, ConvertToJson(bodyParameters));
        }
        /// <summary>
        /// This API is used to link up a social provider account with an existing LoginRadius account on the basis of ping and the social providers user access token.
        /// </summary>
        /// <param name="accessToken">Uniquely generated identifier key by LoginRadius that is activated after successful authentication.</param>
        /// <param name="clientGuid">Unique ID generated by client</param>
        /// <returns>Response containing Definition of Complete Validation data</returns>
        /// 12.5

        public async Task<ApiResponse<PostResponse>> LinkSocialIdentitiesByPing(string accessToken, string clientGuid)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(accessToken));
            }
            if (string.IsNullOrWhiteSpace(clientGuid))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(clientGuid));
            }
            var queryParameters = new QueryParameters
            {
                { "access_token", accessToken },
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] }
            };

            var bodyParameters = new BodyParameters
            {
                { "clientGuid", clientGuid }
            };

            var resourcePath = "identity/v2/auth/socialidentity";
            
            return await ConfigureAndExecute<PostResponse>(HttpMethod.POST, resourcePath, queryParameters, ConvertToJson(bodyParameters));
        }
        /// <summary>
        /// This API is used to set or change UserName by access token.
        /// </summary>
        /// <param name="accessToken">Uniquely generated identifier key by LoginRadius that is activated after successful authentication.</param>
        /// <param name="username">Username of the user</param>
        /// <returns>Response containing Definition of Complete Validation data</returns>
        /// 13.1

        public async Task<ApiResponse<PostResponse>> SetOrChangeUserName(string accessToken, string username)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(accessToken));
            }
            if (string.IsNullOrWhiteSpace(username))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(username));
            }
            var queryParameters = new QueryParameters
            {
                { "access_token", accessToken },
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] }
            };

            var bodyParameters = new BodyParameters
            {
                { "username", username }
            };

            var resourcePath = "identity/v2/auth/username";
            
            return await ConfigureAndExecute<PostResponse>(HttpMethod.PUT, resourcePath, queryParameters, ConvertToJson(bodyParameters));
        }
        /// <summary>
        /// This API is used to check the UserName exists or not on your site.
        /// </summary>
        /// <param name="username">UserName of the user</param>
        /// <returns>Response containing Definition Complete ExistResponse data</returns>
        /// 13.2

        public async Task<ApiResponse<ExistResponse>> CheckUserNameAvailability(string username)
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

            var resourcePath = "identity/v2/auth/username";
            
            return await ConfigureAndExecute<ExistResponse>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// This API is used to update the privacy policy stored in the user's profile by providing the access token of the user accepting the privacy policy
        /// </summary>
        /// <param name="accessToken">Uniquely generated identifier key by LoginRadius that is activated after successful authentication.</param>
        /// <param name="fields">The fields parameter filters the API response so that the response only includes a specific set of fields</param>
        /// <returns>Response containing Definition for Complete profile data</returns>
        /// 15.1

        public async Task<ApiResponse<Identity>> AcceptPrivacyPolicy(string accessToken, string fields = "")
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
            if (!string.IsNullOrWhiteSpace(fields))
            {
               queryParameters.Add("fields", fields);
            }

            var resourcePath = "identity/v2/auth/privacypolicy/accept";
            
            return await ConfigureAndExecute<Identity>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// This API will return all the accepted privacy policies for the user by providing the access token of that user.
        /// </summary>
        /// <param name="accessToken">Uniquely generated identifier key by LoginRadius that is activated after successful authentication.</param>
        /// <returns>Complete Policy History data</returns>
        /// 15.2

        public async Task<ApiResponse<PrivacyPolicyHistoryResponse>> GetPrivacyPolicyHistoryByAccessToken(string accessToken)
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

            var resourcePath = "identity/v2/auth/privacypolicy/history";
            
            return await ConfigureAndExecute<PrivacyPolicyHistoryResponse>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// This API creates a user in the database as well as sends a verification email to the user.
        /// </summary>
        /// <param name="authUserRegistrationModel">Model Class containing Definition of payload for Auth User Registration API</param>
        /// <param name="sott">LoginRadius Secured One Time Token</param>
        /// <param name="emailTemplate">Email template name</param>
        /// <param name="fields">The fields parameter filters the API response so that the response only includes a specific set of fields</param>
        /// <param name="options">PreventVerificationEmail (Specifying this value prevents the verification email from being sent. Only applicable if you have the optional email verification flow)</param>
        /// <param name="verificationUrl">Email verification url</param>
        /// <param name="welcomeEmailTemplate">Name of the welcome email template</param>
        /// <returns>Response containing Definition of Complete Validation, UserProfile data and Access Token</returns>
        /// 17.1.1

        public async Task<ApiResponse<UserProfilePostResponse<AccessToken<Identity>>>> UserRegistrationByEmail(AuthUserRegistrationModel authUserRegistrationModel, string sott,
        string emailTemplate = null, string fields = "", string options = "", string verificationUrl = null, string welcomeEmailTemplate = null)
        {
            if (authUserRegistrationModel == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(authUserRegistrationModel));
            }
            if (string.IsNullOrWhiteSpace(sott))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(sott));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "sott", sott }
            };
            if (!string.IsNullOrWhiteSpace(emailTemplate))
            {
               queryParameters.Add("emailTemplate", emailTemplate);
            }
            if (!string.IsNullOrWhiteSpace(fields))
            {
               queryParameters.Add("fields", fields);
            }
            if (!string.IsNullOrWhiteSpace(options))
            {
               queryParameters.Add("options", options);
            }
            if (!string.IsNullOrWhiteSpace(verificationUrl))
            {
               queryParameters.Add("verificationUrl", verificationUrl);
            }
            if (!string.IsNullOrWhiteSpace(welcomeEmailTemplate))
            {
               queryParameters.Add("welcomeEmailTemplate", welcomeEmailTemplate);
            }

            var resourcePath = "identity/v2/auth/register";
            
            return await ConfigureAndExecute<UserProfilePostResponse<AccessToken<Identity>>>(HttpMethod.POST, resourcePath, queryParameters, ConvertToJson(authUserRegistrationModel));
        }
        /// <summary>
        /// This API creates a user in the database as well as sends a verification email to the user.
        /// </summary>
        /// <param name="authUserRegistrationModelWithCaptcha">Model Class containing Definition of payload for Auth User Registration by Recaptcha API</param>
        /// <param name="emailTemplate">Email template name</param>
        /// <param name="fields">The fields parameter filters the API response so that the response only includes a specific set of fields</param>
        /// <param name="options">PreventVerificationEmail (Specifying this value prevents the verification email from being sent. Only applicable if you have the optional email verification flow)</param>
        /// <param name="smsTemplate">SMS Template name</param>
        /// <param name="verificationUrl">Email verification url</param>
        /// <param name="welcomeEmailTemplate">Name of the welcome email template</param>
        /// <returns>Response containing Definition of Complete Validation, UserProfile data and Access Token</returns>
        /// 17.2

        public async Task<ApiResponse<UserProfilePostResponse<AccessToken<Identity>>>> UserRegistrationByCaptcha(AuthUserRegistrationModelWithCaptcha authUserRegistrationModelWithCaptcha, string emailTemplate = null,
        string fields = "", string options = "", string smsTemplate = null, string verificationUrl = null, string welcomeEmailTemplate = null)
        {
            if (authUserRegistrationModelWithCaptcha == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(authUserRegistrationModelWithCaptcha));
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
            if (!string.IsNullOrWhiteSpace(options))
            {
               queryParameters.Add("options", options);
            }
            if (!string.IsNullOrWhiteSpace(smsTemplate))
            {
               queryParameters.Add("smsTemplate", smsTemplate);
            }
            if (!string.IsNullOrWhiteSpace(verificationUrl))
            {
               queryParameters.Add("verificationUrl", verificationUrl);
            }
            if (!string.IsNullOrWhiteSpace(welcomeEmailTemplate))
            {
               queryParameters.Add("welcomeEmailTemplate", welcomeEmailTemplate);
            }

            var resourcePath = "identity/v2/auth/register/captcha";
            
            return await ConfigureAndExecute<UserProfilePostResponse<AccessToken<Identity>>>(HttpMethod.POST, resourcePath, queryParameters, ConvertToJson(authUserRegistrationModelWithCaptcha));
        }
        /// <summary>
        /// This API resends the verification email to the user.
        /// </summary>
        /// <param name="email">user's email</param>
        /// <param name="emailTemplate">Email template name</param>
        /// <param name="verificationUrl">Email verification url</param>
        /// <returns>Response containing Definition of Complete Validation data</returns>
        /// 17.3

        public async Task<ApiResponse<PostResponse>> AuthResendEmailVerification(string email, string emailTemplate = null,
        string verificationUrl = null)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(email));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] }
            };
            if (!string.IsNullOrWhiteSpace(emailTemplate))
            {
               queryParameters.Add("emailTemplate", emailTemplate);
            }
            if (!string.IsNullOrWhiteSpace(verificationUrl))
            {
               queryParameters.Add("verificationUrl", verificationUrl);
            }

            var bodyParameters = new BodyParameters
            {
                { "email", email }
            };

            var resourcePath = "identity/v2/auth/register";
            
            return await ConfigureAndExecute<PostResponse>(HttpMethod.PUT, resourcePath, queryParameters, ConvertToJson(bodyParameters));
        }
    }
}