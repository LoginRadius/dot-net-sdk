namespace LoginRadiusSDK.Models.Object
{
    public class UserRegistrationModel:User
    {
        public string EmailVerificationUrl { get; set; }
        public string Template { get; set; }
    }
}