namespace LoginRadiusSDK.V2.Models
{
    public class RestHookSubscribeModel : RestHookUnsubscribeModel
    {
        public string @event { get; set; }
    }
}