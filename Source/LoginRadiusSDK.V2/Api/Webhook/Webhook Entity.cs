using LoginRadiusSDK.V2.Models;
using LoginRadiusSDK.V2.Models.webhook;
using LoginRadiusSDK.V2.Util;

namespace LoginRadiusSDK.V2.Api.Webhook
{
    public class WebhookEntity : LoginRadiusResource
    {
        public ApiResponse<LoginRadiusWebhookTestResponse> WebhookTest()
        {
            return ConfigureAndExecute<LoginRadiusWebhookTestResponse>(RequestType.Webhook, HttpMethod.GET, "/test");
        }

        public ApiResponse<LoginRadiusWebhookSubscribe> WebHookSubscribeAPI(webhookPost webhookPost)
        {
            return ConfigureAndExecute<LoginRadiusWebhookSubscribe>(RequestType.Webhook, HttpMethod.POST, string.Empty,
                webhookPost.ConvertToJson());
        }

        public ApiResponse<LoginRadiusWebhookUnSubscribe> WebHookUnsubscribe(webhookPost webhookPost)
        {
            return ConfigureAndExecute<LoginRadiusWebhookUnSubscribe>(RequestType.Webhook, HttpMethod.DELETE, string.Empty,
                webhookPost.ConvertToJson());
        }

        public ApiResponse<LoginRadiouswebhookEvent> WebhookSubscribedURLs(string Event)
        {
            var additionalparams = new QueryParameters { ["event"] = Event };
            return ConfigureAndExecute<LoginRadiouswebhookEvent>(RequestType.Webhook, HttpMethod.GET, null, additionalparams);
        }
    }
}