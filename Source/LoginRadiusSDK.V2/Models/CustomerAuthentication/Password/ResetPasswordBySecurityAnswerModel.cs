using System.Collections.Generic;
using LoginRadiusSDK.V2.Util.Serialization;

namespace LoginRadiusSDK.V2.Models.Password
{
    public class ResetPasswordBySecurityAnswerModel : LoginRadiusSerializableObject
    {
        public Dictionary<string, string> SecurityAnswer { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
    }
}