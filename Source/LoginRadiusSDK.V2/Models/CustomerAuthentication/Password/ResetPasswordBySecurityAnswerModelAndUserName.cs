using LoginRadiusSDK.V2.Util.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoginRadiusSDK.V2.Models.CustomerAuthentication.Password
{
   public class ResetPasswordBySecurityAnswerModelAndUserName : LoginRadiusSerializableObject
    {
        public Dictionary<string, string> SecurityAnswer { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string resetpasswordemailtemplate { get; set; }
    }
}
