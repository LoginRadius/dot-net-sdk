using LoginRadiusSDK.V2.Util.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoginRadiusSDK.V2.Models.CustomerAuthentication.Password
{
   public class ResetPasswordByEmailAndOtpModel : LoginRadiusSerializableObject
  
    {
        public string password { get; set; }
        public string welcomeemailtemplate { get; set; }
        public string resetpasswordemailtemplate { get; set; }
        public string email { get; set; }
        public string otp { get; set; }
    }
}
