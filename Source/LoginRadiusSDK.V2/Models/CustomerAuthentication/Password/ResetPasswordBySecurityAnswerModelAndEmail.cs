using LoginRadiusSDK.V2.Util.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoginRadiusSDK.V2.Models.CustomerAuthentication.Password
{
   public class ResetPasswordBySecurityAnswerModelAndEmail : LoginRadiusSerializableObject
    {
        public Dictionary<string, string> SecurityAnswer { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ResetPasswordEmailTemplate { get; set; }
    }
}
