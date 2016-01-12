using LoginRadiusSDK.Models.UserProfile;

namespace LoginRadiusSDK.Models.Object
{
    public class RaasUserprofile : LoginRadiusUltimateUserProfile
    {
        public string Password { get; set; }
        public bool EmailVerified { get; set; }
        public string Uid { get; set; }

        public bool IsDeleted { get; set; }
    }
}
