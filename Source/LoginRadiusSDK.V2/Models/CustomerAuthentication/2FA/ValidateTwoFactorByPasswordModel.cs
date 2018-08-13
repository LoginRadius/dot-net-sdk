using LoginRadiusSDK.V2.Util.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoginRadiusSDK.V2.Models.CustomerAuthentication._2FA
{
  public  class ValidateTwoFactorByPasswordModel : LoginRadiusSerializableObject
    {
        public Dictionary<string, string> SecurityAnswer { get; set; }
        public string password { get; set; }
        public string qq_captcha_ticket { get; set; }
        public string qq_captcha_randstr { get; set; }

        [JsonProperty("g-recaptcha-response")]
        public string g_recaptcha_response { get; set; }
    }
   
}
