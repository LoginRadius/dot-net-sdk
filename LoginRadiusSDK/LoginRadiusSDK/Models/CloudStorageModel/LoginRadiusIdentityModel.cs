using LoginRadiusSDK.Models.UserProfile;

namespace LoginRadiusSDK.Models.CloudStorageModel
{
    public class LoginRadiusIdentityModel : RaasUserprofile
    {
        public string SignupDate { get; set; }
        public bool IsBlocked { get; set; }
    }
}
