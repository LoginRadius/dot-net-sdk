namespace LoginRadiusSDK.V2.Models.Identity
{
    public class ForgotPasswordToken
    {
        public string ForgotToken { get; set; }
        public string[] IdentityProviders { get; set; }
    }
}