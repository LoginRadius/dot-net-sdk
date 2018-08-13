using LoginRadiusSDK.V2.Util.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoginRadiusSDK.V2.Models.CustomerAuthentication.Login
{
   public class LoginModel : LoginRadiusSerializableObject
    {
        public Dictionary<string, string> SecurityAnswer { get; set; }
        public string password { get; set; }
    }

    public class EmailLoginModel : LoginModel
    {

        public string email { get; set; }
    }

    public class UserNameLoginModel : LoginModel
    {

        public string username { get; set; }
    }

    public class PhoneLoginModel : LoginModel
    {

        public string phone { get; set; }
    }
}
