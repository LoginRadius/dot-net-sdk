using System;
using System.Collections.Generic;

namespace LoginRadiusSDK.V2.Models.UserProfile
{
    public class LoginRadiusSocialUserProfile : UserIdentityCreateModel
    {
        public string ID { get; set; }
        public string Provider { get; set; }
        public string Language { get; set; }
        public string Verified { get; set; }
        public string UpdatedTime { get; set; }
        public string Created { get; set; }
        public string PasswordExpirationDate { get; set; }
        public string IsActive { get; set; }
        public List<string> PreviousUids { get; set; }
        public int ?PinsCount { get; set; }
        public int ?BoardsCount { get; set; }
        public int ?LikesCount { get; set; }
        public DateTime SignupDate { get; set; }
        public DateTime LastLoginDate { get; set; }
        public bool? FirstLogin { get; set; }
        public string LastLoginLocation { get; set; }
        public string IsCustomUid { get; set; }
        public string RegistrationProvider { get; set; }
        public string RegistrationSource { get; set; }
    }
}