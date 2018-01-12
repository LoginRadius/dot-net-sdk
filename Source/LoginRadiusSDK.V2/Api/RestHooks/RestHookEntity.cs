using LoginRadiusSDK.V2.Models;

namespace LoginRadiusSDK.V2.Api
{
    public class RestHookEntity: LoginRadiusResource
    {
        public ApiResponse<LoginRadiusPostResponse> TestRestHook()
        {
            return ConfigureAndExecute<LoginRadiusPostResponse>(RequestType.RestHook, HttpMethod.Get, "test");
        }
        public ApiResponse<LoginRadiusRestHookUserProfile> GetRestHookFieldList()
        {
            return ConfigureAndExecute<LoginRadiusRestHookUserProfile>(RequestType.RestHook, HttpMethod.Get, "fields");
        }
        public ApiResponse<RestHookSubscribeModel> GetRestHookSubscribedUrl()
        {
            return ConfigureAndExecute<RestHookSubscribeModel>(RequestType.RestHook, HttpMethod.Get, "subscription");
        }
        public ApiResponse<LoginRadiusPostResponse> PostSubscribeRestHook(RestHookSubscribeModel restHookSubscribeModel)
        {
            return ConfigureAndExecute<LoginRadiusPostResponse>(RequestType.RestHook, HttpMethod.Post,
                "subscribe", restHookSubscribeModel.ConvertToJson());
        }
        public ApiResponse<LoginRadiusPostResponse> PostUnsubscribeRestHook(RestHookUnsubscribeModel restHookUnsubscribeModel)
        {
            return ConfigureAndExecute<LoginRadiusPostResponse>(RequestType.RestHook, HttpMethod.Post,
                "subscribe", restHookUnsubscribeModel.ConvertToJson());
        }
    }
}
