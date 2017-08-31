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


    public class BOLSecondFactorAuthenticationSettings
    {
        public string QRCode { get; set; }
        public string ManualEntryCode { get; set; }
        public bool ?IsGoogleAuthenticatorVerified { get; set; }
        public bool ?IsOTPAuthenticatorVerified { get; set; }
        public string OTPPhoneNo { get; set; }
        public BOLSMSResponseData OTPStatus { get; set; }
    }

    public class ResendOtpResponse  : LoginRadiusPostResponse
    {
        public BOLSMSResponseData Data { get; set; }
    }
    public class BOLSMSResponseData
    {
        public string AccountSid { get; set; }
        public string Sid { get; set; }
    }

    public class UpdatePhoneResponse
    {
         public BOLSMSResponseData Data { get; set; }
        public string IsPosted { get; set; }
    }


}