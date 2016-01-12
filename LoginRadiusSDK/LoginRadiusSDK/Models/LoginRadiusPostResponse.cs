namespace LoginRadiusSDK.Models
{
    public class LoginRadiusPostResponse
    {
        public bool isPosted { get; set; }
    }

    public class LoginRadiusEmailResponse
    {
        public bool isExist { get; set; }
    }

    public class LoginRadiusForgotPasswordTokenResponse
    {
         public string Giud { get; set;}
         public string Providers { get; set; }
    }
        
 }
