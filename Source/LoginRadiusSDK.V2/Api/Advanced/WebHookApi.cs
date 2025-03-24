//-----------------------------------------------------------------------
// <copyright file="WebHookApi.cs" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2025 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using LoginRadiusSDK.V2.Common;
using System.Threading.Tasks;
using LoginRadiusSDK.V2.Util;
using LoginRadiusSDK.V2.Models.ResponseModels.OtherObjects;
using LoginRadiusSDK.V2.Models.RequestModels;
using LoginRadiusSDK.V2.Models.ResponseModels;
namespace LoginRadiusSDK.V2.Api.Advanced
{
    public class WebHookApi : LoginRadiusResource
    {
        /// <summary>
        /// This API is used to get details of a webhook subscription by Id
        /// </summary>
        /// <param name="hookId">Unique ID of the webhook</param>
        /// <returns>Response containing Definition for Complete WebHook data</returns>
        /// 40.1

        public async Task<ApiResponse<Models.ResponseModels.OtherObjects.WebHookSubscribeModel>> GetWebhookSubscriptionDetail(string hookId)
        {
            if (string.IsNullOrWhiteSpace(hookId))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(hookId));
            }
            var queryParameters = new QueryParameters();
            queryParameters.Add("apikey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey]);
            queryParameters.Add("apisecret", ConfigDictionary[LRConfigConstants.LoginRadiusApiSecret]);

            var resourcePath = $"v2/manage/webhooks/{hookId}";
            
            return await ConfigureAndExecute<Models.ResponseModels.OtherObjects.WebHookSubscribeModel>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// This API is used to create a new webhook subscription on your LoginRadius site.
        /// </summary>
        /// <param name="webHookSubscribeModel">Model Class containing Definition of payload for Webhook Subscribe API</param>
        /// <returns>Response containing Definition for Complete WebHook data</returns>
        /// 40.2

        public async Task<ApiResponse<Models.ResponseModels.OtherObjects.WebHookSubscribeModel>> CreateWebhookSubscription(LoginRadiusSDK.V2.Models.RequestModels.WebHookSubscribeModel webHookSubscribeModel)
        {
            if (webHookSubscribeModel == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(webHookSubscribeModel));
            }
            var queryParameters = new QueryParameters();
            queryParameters.Add("apikey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey]);
            queryParameters.Add("apisecret", ConfigDictionary[LRConfigConstants.LoginRadiusApiSecret]);

            var resourcePath = "v2/manage/webhooks";
            
            return await ConfigureAndExecute<Models.ResponseModels.OtherObjects.WebHookSubscribeModel>(HttpMethod.POST, resourcePath, queryParameters, ConvertToJson(webHookSubscribeModel));
        }
        /// <summary>
        /// This API is used to delete webhook subscription
        /// </summary>
        /// <param name="hookId">Unique ID of the webhook</param>
        /// <returns>Response containing Definition of Delete Request</returns>
        /// 40.3

        public async Task<ApiResponse<DeleteResponse>> DeleteWebhookSubscription(string hookId)
        {
            if (string.IsNullOrWhiteSpace(hookId))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(hookId));
            }
            var queryParameters = new QueryParameters();
            queryParameters.Add("apikey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey]);
            queryParameters.Add("apisecret", ConfigDictionary[LRConfigConstants.LoginRadiusApiSecret]);

            var resourcePath = $"v2/manage/webhooks/{hookId}";
            
            return await ConfigureAndExecute<DeleteResponse>(HttpMethod.DELETE, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// This API is used to update a webhook subscription
        /// </summary>
        /// <param name="hookId">Unique ID of the webhook</param>
        /// <param name="webHookSubscriptionUpdateModel">Model Class containing Definition for WebHookSubscriptionUpdateModel Property</param>
        /// <returns>Response containing Definition for Complete WebHook data</returns>
        /// 40.4

        public async Task<ApiResponse<Models.ResponseModels.OtherObjects.WebHookSubscribeModel>> UpdateWebhookSubscription(string hookId, WebHookSubscriptionUpdateModel webHookSubscriptionUpdateModel)
        {
            if (string.IsNullOrWhiteSpace(hookId))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(hookId));
            }
            if (webHookSubscriptionUpdateModel == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(webHookSubscriptionUpdateModel));
            }
            var queryParameters = new QueryParameters();
            queryParameters.Add("apikey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey]);
            queryParameters.Add("apisecret", ConfigDictionary[LRConfigConstants.LoginRadiusApiSecret]);

            var resourcePath = $"v2/manage/webhooks/{hookId}";
            
            return await ConfigureAndExecute<Models.ResponseModels.OtherObjects.WebHookSubscribeModel>(HttpMethod.PUT, resourcePath, queryParameters, ConvertToJson(webHookSubscriptionUpdateModel));
        }
        /// <summary>
        /// This API is used to get the list of all the webhooks
        /// </summary>
        /// <returns>Response Containing List of Webhhook Data</returns>
        /// 40.5

        public async Task<ApiResponse<ListReturn<Models.ResponseModels.OtherObjects.WebHookSubscribeModel>>> ListAllWebhooks()
        {
            var queryParameters = new QueryParameters();
            queryParameters.Add("apikey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey]);
            queryParameters.Add("apisecret", ConfigDictionary[LRConfigConstants.LoginRadiusApiSecret]);

            var resourcePath = "v2/manage/webhooks";
            
            return await ConfigureAndExecute<ListReturn<Models.ResponseModels.OtherObjects.WebHookSubscribeModel>>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// This API is used to retrieve all the webhook events.
        /// </summary>
        /// <returns>Model Class containing Definition for WebHookEventModel Property</returns>
        /// 40.6

        public async Task<ApiResponse<WebHookEventModel>> GetWebhookEvents()
        {
            var queryParameters = new QueryParameters();
            queryParameters.Add("apikey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey]);
            queryParameters.Add("apisecret", ConfigDictionary[LRConfigConstants.LoginRadiusApiSecret]);

            var resourcePath = "v2/manage/webhooks/events";
            
            return await ConfigureAndExecute<WebHookEventModel>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
    }
}