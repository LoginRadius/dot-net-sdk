//-----------------------------------------------------------------------
// <copyright file="WebHookApi.cs" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2019 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using LoginRadiusSDK.V2.Common;
using LoginRadiusSDK.V2.Util;
using LoginRadiusSDK.V2.Models.ResponseModels;
using LoginRadiusSDK.V2.Models.ResponseModels.OtherObjects;

namespace LoginRadiusSDK.V2.Api.Advanced
{
    public class WebHookApi : LoginRadiusResource
    {
        /// <summary>
        /// This API is used to fatch all the subscribed URLs, for particular event
        /// </summary>
        /// <param name="@event">Allowed events: Login, Register, UpdateProfile, ResetPassword, ChangePassword, emailVerification, AddEmail, RemoveEmail, BlockAccount, DeleteAccount, SetUsername, AssignRoles, UnassignRoles, SetPassword, LinkAccount, UnlinkAccount, UpdatePhoneId, VerifyPhoneNumber, CreateCustomObject, UpdateCustomobject, DeleteCustomObject</param>
        /// <returns>Response Containing List of Webhhook Data</returns>
        /// 40.1

        public ApiResponse<ListData<LoginRadiusSDK.V2.Models.ResponseModels.OtherObjects.WebHookSubscribeModel>> GetWebHookSubscribedURLs(string @event)
        {
            if (string.IsNullOrWhiteSpace(@event))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(@event));
            }
            var queryParameters = new QueryParameters
            {
                { "apikey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "apisecret", ConfigDictionary[LRConfigConstants.LoginRadiusApiSecret] },
                { "event", @event }
            };

            var resourcePath = "api/v2/webhook";
            
            return ConfigureAndExecute<ListData<LoginRadiusSDK.V2.Models.ResponseModels.OtherObjects.WebHookSubscribeModel>>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// API can be used to configure a WebHook on your LoginRadius site. Webhooks also work on subscribe and notification model, subscribe your hook and get a notification. Equivalent to RESThook but these provide security on basis of signature and RESThook work on unique URL. Following are the events that are allowed by LoginRadius to trigger a WebHook service call.
        /// </summary>
        /// <param name="webHookSubscribeModel">Model Class containing Definition of payload for Webhook Subscribe API</param>
        /// <returns>Response containing Definition of Complete Validation data</returns>
        /// 40.2

        public ApiResponse<PostResponse> WebHookSubscribe(LoginRadiusSDK.V2.Models.RequestModels.WebHookSubscribeModel webHookSubscribeModel)
        {
            if (webHookSubscribeModel == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(webHookSubscribeModel));
            }
            var queryParameters = new QueryParameters
            {
                { "apikey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "apisecret", ConfigDictionary[LRConfigConstants.LoginRadiusApiSecret] }
            };

            var resourcePath = "api/v2/webhook";
            
            return ConfigureAndExecute<PostResponse>(HttpMethod.POST, resourcePath, queryParameters, ConvertToJson(webHookSubscribeModel));
        }
        /// <summary>
        /// API can be used to test a subscribed WebHook.
        /// </summary>
        /// <returns>Response containing Definition of Complete Validation data</returns>
        /// 40.3

        public ApiResponse<EntityPermissionAcknowledgement> WebhookTest()
        {
            var queryParameters = new QueryParameters
            {
                { "apikey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "apisecret", ConfigDictionary[LRConfigConstants.LoginRadiusApiSecret] }
            };

            var resourcePath = "api/v2/webhook/test";
            
            return ConfigureAndExecute<EntityPermissionAcknowledgement>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// API can be used to unsubscribe a WebHook configured on your LoginRadius site.
        /// </summary>
        /// <param name="webHookSubscribeModel">Model Class containing Definition of payload for Webhook Subscribe API</param>
        /// <returns>Response containing Definition of Delete Request</returns>
        /// 40.4

        public ApiResponse<DeleteResponse> WebHookUnsubscribe(LoginRadiusSDK.V2.Models.RequestModels.WebHookSubscribeModel webHookSubscribeModel)
        {
            if (webHookSubscribeModel == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(webHookSubscribeModel));
            }
            var queryParameters = new QueryParameters
            {
                { "apikey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "apisecret", ConfigDictionary[LRConfigConstants.LoginRadiusApiSecret] }
            };

            var resourcePath = "api/v2/webhook";
            
            return ConfigureAndExecute<DeleteResponse>(HttpMethod.DELETE, resourcePath, queryParameters, ConvertToJson(webHookSubscribeModel));
        }
    }
}