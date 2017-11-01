namespace LoginRadiusSDK.V2.Models.UserProfile
{
    public class LoginRadiusTraditionalUserProfile : LoginRadiusSocialUserProfile
    {
        public string Password { get; set; }
        public bool EmailVerified { get; set; }
        public bool IsDeleted { get; set; }
        public string Uid { get; set; }
        public int NoOfLogins { get; set; }
        public string PhoneId { get; set; }
        public bool PhoneIdVerified { get; set; }
    }
}
