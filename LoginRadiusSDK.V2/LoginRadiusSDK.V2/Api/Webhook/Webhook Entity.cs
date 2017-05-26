using LoginRadiusSDK.V2.Models;
using LoginRadiusSDK.V2.Models.webhook;
using LoginRadiusSDK.V2.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LoginRadiusSDK.V2.Api.LoginRadiusResource;

namespace LoginRadiusSDK.V2.Api.Webhook
{
    public class WebhookEntity : LoginRadiusResource
    {
        public ApiResponse<LoginRadiusWebhookTestResponse> WebhookTest()
        {
            return ConfigureAndExecute<LoginRadiusWebhookTestResponse>(RequestType.Webhook, HttpMethod.Get,
                "/test");
        }

        public ApiResponse<LoginRadiusWebhookSubscribe> WebHookSubscribeAPI(webhookPost webhookPost)
        {
            return ConfigureAndExecute<LoginRadiusWebhookSubscribe>(RequestType.Webhook, HttpMethod.Post, "",
                webhookPost.ConvertToJson());
        }

        public ApiResponse<LoginRadiusWebhookUnSubscribe> WebHookUnsubscribe(webhookPost webhookPost)
        {
            return ConfigureAndExecute<LoginRadiusWebhookUnSubscribe>(RequestType.Webhook, HttpMethod.Delete, "",
                webhookPost.ConvertToJson());
        }

        public ApiResponse<LoginRadiouswebhookEvent> WebhookSubscribedURLs(string Event)
        {
            var additionalparams = new QueryParameters {["event"] = Event};
            return ConfigureAndExecute<LoginRadiouswebhookEvent>(RequestType.Webhook, HttpMethod.Get, null, additionalparams);
        }
    }
}