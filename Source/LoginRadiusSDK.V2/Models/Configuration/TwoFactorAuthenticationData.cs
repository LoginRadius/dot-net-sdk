using System;
using System.Collections.Generic;
using System.Text;

namespace LoginRadiusSDK.V2.Models.Configuration
{
    public class TwoFactorAuthenticationData
    {
        public bool IsEnabled { get; set; }
        public bool IsRequired { get; set; }
        public bool IsGoogleAuthenticator { get; set; }
    }
}
