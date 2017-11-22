namespace LoginRadiusSDK.V2.Models
{
    public class TwoFactorAuthenticationSettings
    {
        public string SecondFactorAuthenticationToken { get; set; }
        public string ExpireIn { get; set; }
        public string QRCode { get; set; }
        public string ManualEntryCode { get; set; }
        public bool ?IsGoogleAuthenticatorVerified { get; set; }
        public bool ?IsOTPAuthenticatorVerified { get; set; }
        public string OTPPhoneNo { get; set; }
        public SmsResponseData OTPStatus { get; set; }
    }

    public class SecondFactorAuthenticationSettings
    {
        public string QRCode { get; set; }
        public string ManualEntryCode { get; set; }
        public bool ?IsGoogleAuthenticatorVerified { get; set; }
        public bool ?IsOTPAuthenticatorVerified { get; set; }
        public string OTPPhoneNo { get; set; }
        public SmsSendResponse OTPStatus { get; set; }
    }

    public class ResendOtpResponse  : LoginRadiusPostResponse
    {
        public SmsSendResponse Data { get; set; }
    }

    public class SmsSendResponse
    {
        public string AccountSid { get; set; }
        public string Sid { get; set; }
    }

    public class UpdatePhoneResponse
    {
         public SmsSendResponse Data { get; set; }
        public string IsPosted { get; set; }
    }
}