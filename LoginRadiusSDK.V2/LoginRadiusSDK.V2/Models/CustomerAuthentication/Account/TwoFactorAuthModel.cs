using LoginRadiusSDK.V2.Util;
using System.Collections.Generic;

namespace LoginRadiusSDK.V2.Models
{
    public class TwoFactorAuthModel : Dictionary<string, string>
    {
        /// <summary>
        /// 
        /// </summary>
        public string Otp { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string GoogleAuthenticatorCode { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string SecondFactorAuthenticationToken { get; set; }
    }

    public class TwoFactorPhoneAuthModel : Util.Serialization.LoginRadiusSerializableObject
    {
        /// <summary>
        /// 
        /// </summary>
        public string PhoneNo2Fa { get; set; }
    }
}