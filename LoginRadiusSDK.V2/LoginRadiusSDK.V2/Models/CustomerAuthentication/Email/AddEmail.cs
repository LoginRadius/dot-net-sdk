using LoginRadiusSDK.V2.Util.Serialization;

namespace LoginRadiusSDK.V2.Models.Email
{
    public class AddEmail : LoginRadiusSerializableObject
    {
        public string Email { get; set; }
        public string Type { get; set; }
    }
}