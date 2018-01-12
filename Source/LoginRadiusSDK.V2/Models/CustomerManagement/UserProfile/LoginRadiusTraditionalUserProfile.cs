namespace LoginRadiusSDK.V2.Models.UserProfile
{
    public class LoginRadiusTraditionalUserProfile : LoginRadiusSocialUserProfile
    {
        public bool EmailVerified { get; set; }
        public bool IsDeleted { get; set; }
        public int NoOfLogins { get; set; }
        public bool PhoneIdVerified { get; set; }
    }
}
