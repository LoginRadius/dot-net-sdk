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

    /// <summary>
    /// LoginRadius Authantication class
    /// </summary>
    public class LoginRadius
    {
        readonly HttpRequest request;

        private const string TOKEN = "token";
        private const string Providertoken = "providertoken";

        /// <summary>
        /// If IsAuthenticate id true then user successfully logged in and collect data
        /// </summary>
        public bool IsAuthenticated { get; set; }

        /// <summary>
        /// Raw JSON response for user profile data returned from LoginRadius API
        /// </summary>
        public string Response { get; set; }

   
        /// <summary>
        /// LoginRadius session token, a session key to access current user's data
        /// </summary>
        public string Token { get; set; }


        /// <summary>
        /// Connstructor to create the environment for LoginRadius API. It would first validate the API key format and
        /// then get user profile data (Basic or Exteneded) from loginradius rest api and set IsAuthenticated true 
        /// The following Rest API is used to get user profile data 
        ///  <![CDATA[ 
        ///  https://hub.loginradius.com/userprofile.ashx?token={yourtoken}&apisecrete={yourapisecret}
        /// ]]> 
        /// </summary>
        /// <param name="apiSecret">LoginRadius API Secret</param>
        public LoginRadius(string apiSecret)
        {
            IsAuthenticated = false;
            if (Utility.IsGuid(apiSecret))
            {
                request = HttpContext.Current.Request;

                if (!string.IsNullOrEmpty(request[TOKEN]))
                {
                    WebClient wc = new WebClient();
                    string validateUrl = string.Format(Requesturl.url+ "/userprofile.ashx?token={0}&apisecrete={1}", request[TOKEN], apiSecret);
                    wc.Encoding = System.Text.Encoding.UTF8;
                    Response = wc.DownloadString(validateUrl);
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
            BasicUserLoginRadiusUserProfile userprofile = (BasicUserLoginRadiusUserProfile)Newtonsoft.Json.JsonConvert.DeserializeObject(Response, typeof(BasicUserLoginRadiusUserProfile));
            SetIsAuthenticated(userprofile);
            return userprofile;
        }


        /// <summary>
        /// Call GetExtendedUserProfile it returns extended user profile. if you are not ultiamte user then you will get null fields
        /// </summary>
        /// <returns>returns UltimateUserLoginRadiusUserProfile</returns>
        public UltimateUserLoginRadiusUserProfile GetExtendedUserProfile()
        {
            UltimateUserLoginRadiusUserProfile userprofile = (UltimateUserLoginRadiusUserProfile)Newtonsoft.Json.JsonConvert.DeserializeObject(Response, typeof(UltimateUserLoginRadiusUserProfile));
            SetIsAuthenticated(userprofile);
            return userprofile;
        }

        /// <summary>
        /// set is authenicated property
        /// </summary>
        /// <param name="userprofile">For setting up IsAuthenticated property</param>
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