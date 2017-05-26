using LoginRadiusSDK.V2.Models.CustomerManagement.UserProfile.UserProfileSubModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace LoginRadiusSDK.V2.Models.UserProfile
{
    public class LoginRadiusLanguage
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string proficiency { get; set; }
    }

    public class RemoveLanguage : LoginRadiusLanguage
    {
        public string op { get; set; }
    }


    public class PostResponse
    {
        public string IsPosted { get; set; }
        public LoginRadiusUpdateProfileResponse Data { get; set; }
    }

   
}

