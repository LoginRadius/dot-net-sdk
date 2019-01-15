namespace LoginRadiusSDK.V2.Models
{
    public class MultifactorAuthentication
    {
        public string QrCode { get; set; }
        public string ManualEntryCode { get; set; }
        public bool ?IsGoogleAuthenticatorVerified { get; set; }
        public bool ?IsOtpAuthenticatorVerified { get; set; }
        public string OtpPhoneNo { get; set; }
        public SmsResponseData OtpStatus { get; set; }
    }
}