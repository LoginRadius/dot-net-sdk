namespace LoginRadiusSDK.Models.UserProfile
{
    public class RaasUserprofile : LoginRadiusUltimateUserProfile
    {
        public string Password { get; set; }
        public bool EmailVerified { get; set; }
        public string Uid { get; set; }
        public bool IsDeleted { get; set; }
        public int NoOfLogins { get; set; }
    }
}
