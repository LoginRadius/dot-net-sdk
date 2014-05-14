using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace LoginRadius.SDK.Models.UserProfile
{
         
    public class LoginRadiusBasicUserrProfile
    {
       
        public string ID { get; set; }
        public string Provider { get; set; }
        public string Prefix { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public string FullName { get; set; }
        public string NickName { get; set; }
        public string ProfileName { get; set; }
        public string BirthDate { get; set; }
        public string Gender { get; set; }
        public string ImageUrl { get; set; }
        public string ThumbnailImageUrl { get; set; }

        public List<LoginRadiusEmail> Email { get; set; }
        public LoginRadiusCountry Country { get; set; }

        [ScriptIgnore]
        public DateTime CreatedDate
        {
            get;
            set;
        }

        [ScriptIgnore]
        public DateTime ModifiedDate
        {
            get;
            set;
        }


        public string LocalCountry
        {
            get;
            set;
        }

        public string ProfileCountry
        {
            get;
            set;
        }
    }
}
