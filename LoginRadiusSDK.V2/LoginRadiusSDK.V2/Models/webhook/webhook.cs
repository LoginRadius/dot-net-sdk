using LoginRadiusSDK.V2.Util.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginRadiusSDK.V2.Models.webhook
{
    public class webhookPost : LoginRadiusSerializableObject
    {
        public string TargetUrl { get; set; }
        public string Event { get; set; }
    }


    public class LoginRadiouswebhookEvent
    {
        public string Count { get; set; }
        public List<webhookPost> data { get; set; }
    }



    public class LoginRadiusWebhookSubscribe
    {
        public bool? IsPosted { get; set; }
    }
    public class LoginRadiusWebhookUnSubscribe
    {
        public bool? IsDeleted{ get; set; }
    }
    public class LoginRadiusWebhookTestResponse
    {
        public bool? IsAllowed { get; set; }
    }
}