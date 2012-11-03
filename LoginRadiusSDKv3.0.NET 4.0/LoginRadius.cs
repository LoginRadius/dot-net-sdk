// -----------------------------------------------------------------------
// <copyright file="LoginRadius.cs" company="LoginRadius">
// Copyright Loginradius 2011-2012
// </copyright>
// -----------------------------------------------------------------------

namespace LoginRadiusSDK
{
    using System;
    using System.Web;
    using System.Net;
    using LoginRadiusDataModal.LoginRadiusDataObject.UserProfile.Factory;
    using LoginRadiusDataModal.LoginRadiusDataObject.UserProfile.Objects;


    public class LoginRadius
    {
        readonly HttpRequest request;

        /// <summary>
        /// If IsAuthenticate id true then user successfully logged in and collect data
        /// </summary>
        public bool IsAuthenticated { get; set; }
        public string Resonse { get; set; }
        public string Resonsetoken { get; set; }
        public const string TOKEN = "token";
        public const string Providertoken = "providertoken";

        /// <summary>
        /// Connstructor Create environment for LoginRadius API
        /// </summary>
        /// <param name="ApiSecrete">Your API Secrete</param>
        public LoginRadius(string apiSecrete)
        {
            IsAuthenticated = false;
            if (Extensions.IsGuid(apiSecrete))
            {
                request = HttpContext.Current.Request;

                if (!string.IsNullOrEmpty(request[TOKEN]))
                {
                    WebClient wc = new WebClient();


                    string validateUrl = string.Format(Requesturl.url+ "/userprofile.ashx?token={0}&apisecrete={1}", request[TOKEN], apiSecrete);
                    Resonse = wc.DownloadString(validateUrl);
                    Resonsetoken = validateUrl;
                    IsAuthenticated = true;
                }
            }
            else
            {
                throw new Exception("Invalid API key");
            }
        }

        /// <summary>
        /// Call Basic user it returns Premium user profile.
        /// </summary>
        /// <returns>returns PremiumUserLoginRadiusUserProfile</returns>
        public BasicUserLoginRadiusUserProfile GetBasicUserProfile()
        {
            BasicUserLoginRadiusUserProfile userprofile = (BasicUserLoginRadiusUserProfile)Newtonsoft.Json.JsonConvert.DeserializeObject(Resonse, typeof(BasicUserLoginRadiusUserProfile));
            SetIsAuthenticated(userprofile);
            return userprofile;
        }

        /// <summary>
        /// Call Premium user it returns Premium user profile. if you are not Premium user then you will get null fields
        /// </summary>
        /// <returns>returns PremiumUserLoginRadiusUserProfile</returns>
        public PremiumUserLoginRadiusUserProfile GetPremiumUserProfile()
        {
            PremiumUserLoginRadiusUserProfile userprofile = (PremiumUserLoginRadiusUserProfile)Newtonsoft.Json.JsonConvert.DeserializeObject(Resonse, typeof(PremiumUserLoginRadiusUserProfile));
            SetIsAuthenticated(userprofile);
            return userprofile;
        }

        /// <summary>
        /// Call ultimate user it returns ultimate user profile. if you are not ultiamte user then you will get null fields
        /// </summary>
        /// <returns>returns UltimateUserLoginRadiusUserProfile</returns>
        public UltimateUserLoginRadiusUserProfile GetUltimateUserProfile()
        {
            UltimateUserLoginRadiusUserProfile userprofile = (UltimateUserLoginRadiusUserProfile)Newtonsoft.Json.JsonConvert.DeserializeObject(Resonse, typeof(UltimateUserLoginRadiusUserProfile));
            SetIsAuthenticated(userprofile);
            return userprofile;
        }

        /// <summary>
        /// set is authenicated property 
        /// </summary>
        /// <param name="userprofile"></param>
        private void SetIsAuthenticated(IBasicUserLoginRadiusUserProfile userprofile)
        {
            if (!String.IsNullOrEmpty(userprofile.ID))
            {
                IsAuthenticated = true;
            }
            else
            {
                IsAuthenticated = false;
            }
        }
    }
}