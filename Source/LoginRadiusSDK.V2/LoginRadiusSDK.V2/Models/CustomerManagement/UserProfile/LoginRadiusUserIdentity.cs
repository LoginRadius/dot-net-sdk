using System.Collections.Generic;

namespace LoginRadiusSDK.V2.Models.UserProfile
{
    public class LoginRadiusUserIdentity : NullUpdate
    {
        public bool? EmailVerified { get; set; }
        public bool? IsDeleted { get; set; }
        public int NoOfLogins { get; set; }
        public bool? PhoneIdVerified { get; set; }
        public List<LoginRadiusSocialUserProfile> Identities { get; set; }
    }


    public class NullUpdate : LoginRadiusSocialUserProfile
    {
        public bool NullSupport { get; set; }
    }
}