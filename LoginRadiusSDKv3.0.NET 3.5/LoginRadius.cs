// -----------------------------------------------------------------------
// <copyright file="LoginRadius.cs" company="LoginRadius Inc.">
// Copyright LoginRadius.com 2011-2013
// This file is part of the LoginRadius SDK package.
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
        public string Token { get; set; }
        /// <summary>
        /// Connstructor to create the environment for LoginRadius API. It would first validate the API key format and
        /// then get user profile data (Basic or Exteneded) from loginradius rest api and set IsAuthenticated true 
        /// The following Rest API is used to get user profile data 
        /// https://www.hub.loginradius.com/userprofile.ashx?token={yourtoken}&apisecrete={yourapisecret}
        /// </summary>
        /// <param name="ApiSecret">LoginRadius API Secret</param>
        public LoginRadius(string apiSecrete)
        {
            IsAuthenticated = false;
            if (Utility.IsGuid(apiSecrete))
            {
                request = HttpContext.Current.Request;

                if (!string.IsNullOrEmpty(request[TOKEN]))
                {
                    WebClient wc = new WebClient();


                    string validateUrl = string.Format(Requesturl.url+ "/userprofile.ashx?token={0}&apisecrete={1}", request[TOKEN], apiSecrete);
                    wc.Encoding = System.Text.Encoding.UTF8;
                    Resonse = wc.DownloadString(validateUrl);
                    Resonsetoken = validateUrl;
                    Token = request[TOKEN];
                    IsAuthenticated = true;
                }
            }
            else
            {
                throw new Exception("Invalid API key");
            }
        }
        /// <summary>
        /// GetBasicUserProfile function, returns basic user profile data for user.
        /// </summary>
        /// <returns>returns BasicUserLoginRadiusUserProfile</returns>
        public BasicUserLoginRadiusUserProfile GetBasicUserProfile()
        {
            BasicUserLoginRadiusUserProfile userprofile = (BasicUserLoginRadiusUserProfile)Newtonsoft.Json.JsonConvert.DeserializeObject(Resonse, typeof(BasicUserLoginRadiusUserProfile));
            SetIsAuthenticated(userprofile);
            return userprofile;
        }


        /// <summary>
        /// Call GetPremiumUserProfile function it returns Premium user profile. if you are not Premium user then you will get null fields
        /// </summary>
        /// <returns>returns PremiumUserLoginRadiusUserProfile</returns>
        public PremiumUserLoginRadiusUserProfile GetPremiumUserProfile()
        {
            PremiumUserLoginRadiusUserProfile userprofile = (PremiumUserLoginRadiusUserProfile)Newtonsoft.Json.JsonConvert.DeserializeObject(Resonse, typeof(PremiumUserLoginRadiusUserProfile));
            SetIsAuthenticated(userprofile);
            return userprofile;
        }

        /// <summary>
        /// Call GetUltimateUserProfile it returns ultimate user profile. if you are not ultiamte user then you will get null fields
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