using LoginRadiusSDK.V2.Util;

namespace LoginRadiusSDK.V2.Models
{
    public class RestHookUnsubscribeModel : BodyParameters
    {
        public string target_url { get; set; }
    }
}