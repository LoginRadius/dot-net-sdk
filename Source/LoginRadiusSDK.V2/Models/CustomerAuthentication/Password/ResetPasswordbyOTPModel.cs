using LoginRadiusSDK.V2.Util.Serialization;

namespace LoginRadiusSDK.V2.Models.Password
{
    public class ResetPasswordByOtpModel : LoginRadiusSerializableObject
    {
        public string Otp { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string SmsTemplate { get; set; }
    }
}