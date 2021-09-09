namespace LoginRadiusSDK.V2.Common
{
    public class JwtValidationParameters
    {
       
        public string JwtToken { get; set; }
        public string Secret { get; set; }
        public bool ValidateIssuerSigningKey { get; set; } = true;
        public bool ValidateIssuer { get; set; } = false;
        public bool ValidateAudience { get; set; } = false;
        public string Issuer { get; set; } = "";
        public string Audience { get; set; } = "";

    }
   
}
