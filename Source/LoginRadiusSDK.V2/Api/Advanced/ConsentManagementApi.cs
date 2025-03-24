//-----------------------------------------------------------------------
// <copyright file="ConsentManagementApi.cs" company="LoginRadius">
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

namespace LoginRadiusSDK.V2.Api.Advanced
{
    public class ConsentManagementApi : LoginRadiusResource
    {
        /// <summary>
        /// This API is used to get the Consent logs of the user.
        /// </summary>
        /// <param name="uid">UID, the unified identifier for each user account</param>
        /// <returns>Response containing consent logs</returns>
        /// 18.37

        public async Task<ApiResponse<ConsentLogsResponseModel>> GetConsentLogsByUid(string uid)
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

            var resourcePath = $"identity/v2/manage/account/{uid}/consent/logs";
            
            return await ConfigureAndExecute<ConsentLogsResponseModel>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// This API is to submit consent form using consent token.
        /// </summary>
        /// <param name="consentToken">The consent token received after login error 1226 </param>
        /// <param name="consentSubmitModel">Model class containing list of multiple consent</param>
        /// <returns>Response containing User Profile Data and access token</returns>
        /// 43.1

        public async Task<ApiResponse<AccessToken<Identity>>> SubmitConsentByConsentToken(string consentToken, ConsentSubmitModel consentSubmitModel)
        {
            if (string.IsNullOrWhiteSpace(consentToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(consentToken));
            }
            if (consentSubmitModel == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(consentSubmitModel));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "consentToken", consentToken }
            };

            var resourcePath = "identity/v2/auth/consent";
            
            return await ConfigureAndExecute<AccessToken<Identity>>(HttpMethod.POST, resourcePath, queryParameters, ConvertToJson(consentSubmitModel));
        }
        /// <summary>
        /// This API is used to fetch consent logs.
        /// </summary>
        /// <param name="accessToken">Uniquely generated identifier key by LoginRadius that is activated after successful authentication.</param>
        /// <returns>Response containing consent logs</returns>
        /// 43.2

        public async Task<ApiResponse<ConsentLogsResponseModel>> GetConsentLogs(string accessToken)
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

            var resourcePath = "identity/v2/auth/consent/logs";
            
            return await ConfigureAndExecute<ConsentLogsResponseModel>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// API to provide a way to end user to submit a consent form for particular event type.
        /// </summary>
        /// <param name="accessToken">Uniquely generated identifier key by LoginRadius that is activated after successful authentication.</param>
        /// <param name="consentSubmitModel">Model class containing list of multiple consent</param>
        /// <returns>Response containing Definition for Complete profile data</returns>
        /// 43.3

        public async Task<ApiResponse<Identity>> SubmitConsentByAccessToken(string accessToken, ConsentSubmitModel consentSubmitModel)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(accessToken));
            }
            if (consentSubmitModel == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(consentSubmitModel));
            }
            var queryParameters = new QueryParameters
            {
                { "access_token", accessToken },
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] }
            };

            var resourcePath = "identity/v2/auth/consent/profile";
            
            return await ConfigureAndExecute<Identity>(HttpMethod.POST, resourcePath, queryParameters, ConvertToJson(consentSubmitModel));
        }
        /// <summary>
        /// This API is used to check if consent is submitted for a particular event or not.
        /// </summary>
        /// <param name="accessToken">Uniquely generated identifier key by LoginRadius that is activated after successful authentication.</param>
        /// <param name="@event">Allowed events: Login, Register, UpdateProfile, ResetPassword, ChangePassword, emailVerification, AddEmail, RemoveEmail, BlockAccount, DeleteAccount, SetUsername, AssignRoles, UnassignRoles, SetPassword, LinkAccount, UnlinkAccount, UpdatePhoneId, VerifyPhoneNumber, CreateCustomObject, UpdateCustomobject, DeleteCustomObject</param>
        /// <param name="isCustom">true/false</param>
        /// <returns>Response containing consent profile</returns>
        /// 43.4

        public async Task<ApiResponse<ConsentProfileValidResponse>> VerifyConsentByAccessToken(string accessToken, string @event,
        bool? isCustom)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(accessToken));
            }
            if (string.IsNullOrWhiteSpace(@event))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(@event));
            }
            var queryParameters = new QueryParameters
            {
                { "access_token", accessToken },
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "event", @event },
                { "isCustom", isCustom.ToString() }
            };

            var resourcePath = "identity/v2/auth/consent/verify";
            
            return await ConfigureAndExecute<ConsentProfileValidResponse>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// This API is to update consents using access token.
        /// </summary>
        /// <param name="accessToken">Uniquely generated identifier key by LoginRadius that is activated after successful authentication.</param>
        /// <param name="consentUpdateModel">Model class containg list of multiple consent</param>
        /// <returns>Response containing consent profile</returns>
        /// 43.5

        public async Task<ApiResponse<ConsentProfile>> UpdateConsentProfileByAccessToken(string accessToken, ConsentUpdateModel consentUpdateModel)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(accessToken));
            }
            if (consentUpdateModel == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(consentUpdateModel));
            }
            var queryParameters = new QueryParameters
            {
                { "access_token", accessToken },
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] }
            };

            var resourcePath = "identity/v2/auth/consent";
            
            return await ConfigureAndExecute<ConsentProfile>(HttpMethod.PUT, resourcePath, queryParameters, ConvertToJson(consentUpdateModel));
        }
    }
}