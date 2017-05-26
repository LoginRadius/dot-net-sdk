using System.Collections.Generic;
using LoginRadiusSDK.V2.Models.UserProfile;

namespace LoginRadiusSDK.V2.Models
{
    public class LoginRadiusIdentityModel : LoginRadiusUserIdentity
    {
        public string SignupDate { get; set; }
        public bool ?IsBlocked { get; set; }
    }

    public class LoginRadiusIdentityUserList
    {
        public List<LoginRadiusIdentityModel> UserProfile { get; set; }
    }

     
}