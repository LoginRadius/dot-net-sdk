using LoginRadiusSDK.V2.Util.Serialization;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace LoginRadiusSDK.V2.Models.CustomerAuthentication.Login
{
    public class OneTouchLoginModel : LoginRadiusSerializableObject
    {
        public string name { get; set; }
        public string qq_captcha_ticket { get; set; }
        public string qq_captcha_randstr { get; set; }

        [JsonProperty("g-recaptcha-response")]
        public string g_recaptcha_response { get; set; }
    }

    public class OneTouchEmailLoginModel : OneTouchLoginModel
    {
        public string clientguid { get; set; }
        public string email { get; set; }
    }

    public class OneTouchPhoneLoginModel : OneTouchLoginModel
    {
        public string phone { get; set; }
    }

    public class OneTouchEmailVerificationModel
    {
        public bool? IsPosted { get; set; }
        public bool? IsVerified { get; set; }
    }
}
