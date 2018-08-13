using System.Collections.Generic;
using LoginRadiusSDK.V2.Util.Serialization;

namespace LoginRadiusSDK.V2.Models.Password
{
    public class ResetPasswordBySecurityAnswerModel : LoginRadiusSerializableObject
    {
        public Dictionary<string, string> SecurityAnswer { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string resetpasswordemailtemplate { get; set; }
    }
}