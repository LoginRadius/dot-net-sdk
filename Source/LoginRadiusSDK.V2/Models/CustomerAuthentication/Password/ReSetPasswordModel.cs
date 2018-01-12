using LoginRadiusSDK.V2.Util.Serialization;

namespace LoginRadiusSDK.V2.Models.Password
{
    public class ReSetPasswordModel : LoginRadiusSerializableObject
    {
        public string VToken { get; set; }
        public string resettoken { get; set; }
        public string Password { get; set; }
        public string WelcomeEmailTemplate { get; set; }
    }
}