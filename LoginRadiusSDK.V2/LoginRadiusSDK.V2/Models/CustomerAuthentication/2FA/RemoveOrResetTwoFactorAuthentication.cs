using LoginRadiusSDK.V2.Util.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginRadiusSDK.V2.Models.CustomerAuthentication._2FA
{
    public class RemoveOrResetTwoFactorAuthentication : LoginRadiusSerializableObject
    {
        public bool ?otpauthenticator { get; set; }
        public bool ?googleauthenticator { get; set; }
    }
}