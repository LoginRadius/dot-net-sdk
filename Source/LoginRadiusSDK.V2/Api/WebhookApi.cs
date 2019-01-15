using LoginRadiusSDK.V2.Models;
using LoginRadiusSDK.V2.Models.webhook;
using LoginRadiusSDK.V2.Util;

namespace LoginRadiusSDK.V2.Api
{
    public class WebhookApi : LoginRadiusResource
    {
        /// <summary>
        /// This API can be used to test a subscribed WebHook.
        /// </summary>
        /// <returns>LoginRadiusWebhookTestResponse: Boolean to check if webhook is allowed.</returns>
        public ApiResponse<LoginRadiusWebhookTestResponse> WebhookTest()
        {
            return ConfigureAndExecute<LoginRadiusWebhookTestResponse>(RequestType.Webhook, HttpMethod.GET, "/test");
        }

        /// <summary>
        /// This API can be used to configure a WebHook on your LoginRadius site.
        /// </summary>
        /// <param name="webhookPost">Name of the role context.</param>
        /// <returns>LoginRadiusWebhookSubscribe: Boolean to check if webhook is subscribed.</returns>
        public ApiResponse<LoginRadiusWebhookSubscribe> WebHookSubscribeApi(webhookPost webhookPost)
        {
            return ConfigureAndExecute<LoginRadiusWebhookSubscribe>(RequestType.Webhook, HttpMethod.POST, string.Empty,
                webhookPost.ConvertToJson());
        }

        /// <summary>
        /// This API can be used to unsubscribe a WebHook configured on your LoginRadius site.
        /// </summary>
        /// <param name="webhookPost">Object of the unsubscribing webhook.</param>
        /// <returns>LoginRadiusWebhookUnSubscribe: Boolean to check if webhook is removed.</returns>
        public ApiResponse<LoginRadiusWebhookUnSubscribe> WebHookUnsubscribe(webhookPost webhookPost)
        {
            return ConfigureAndExecute<LoginRadiusWebhookUnSubscribe>(RequestType.Webhook, HttpMethod.DELETE, string.Empty,
                webhookPost.ConvertToJson());
        }

        /// <summary>
        /// This API is used to fatch all the subscribed URLs, for particular event.
        /// </summary>
        /// <param name="Event">Name of the hooked event.</param>
        /// <returns>LoginRadiouswebhookEvent: List of webhooks attached to event.</returns>
        public ApiResponse<LoginRadiouswebhookEvent> WebhookSubscribedUrls(string Event)
        {
            var additionalparams = new QueryParameters { ["event"] = Event };
            return ConfigureAndExecute<LoginRadiouswebhookEvent>(RequestType.Webhook, HttpMethod.GET, null, additionalparams);
        }
    }
}