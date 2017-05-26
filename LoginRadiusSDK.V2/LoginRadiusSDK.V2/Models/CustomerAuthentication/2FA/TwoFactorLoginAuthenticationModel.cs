using System;
using System.Collections.Generic;

namespace LoginRadiusSDK.V2.Models
{
    public class TwoFactorLoginAuthenticationModel : Dictionary<String, String>
    {
        public string Otp { get; set; }
        public string GoogleAuthenticatorCode { get; set; }
    }
}