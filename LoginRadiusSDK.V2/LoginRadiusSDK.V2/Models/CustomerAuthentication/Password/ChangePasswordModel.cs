using LoginRadiusSDK.V2.Util.Serialization;

namespace LoginRadiusSDK.V2.Models.Password
{
    public class ChangePasswordModel : LoginRadiusSerializableObject
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }

    public class ChangePasswordModels
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}