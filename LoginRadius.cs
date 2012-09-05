//
// Copyright 2012 LoginRadius Inc.
//

using System;
using System.Net;
using System.Web;
using LoginRadiusDataModal.LoginRadiusDataObject.Factory;
using LoginRadiusDataModal.LoginRadiusDataObject.Objects;

namespace LoginRadiusSDK {
    public class LoginRadius {
        readonly HttpRequest request;
        private bool isAuthenticated;

        public override string ToString() { return string.Format("Token: {0}", Token); }

        /// <summary>
        /// If IsAuthenticate true then user successfully logged in and collect user profile data
        /// </summary>
        public bool IsAuthenticated {
            get { return isAuthenticated; }
            set { isAuthenticated = value; }
        }

        private String token;
        public String Token {
            get { return string.IsNullOrEmpty(token) ? string.Empty : token; }
        }

        public string Resonse { get; set; }
        public const string APIToken = "token";
        public const string Providertoken = "providertoken";

        /// <summary>
        /// Constructor to create environment for LoginRadius SDK
        /// </summary>
        /// <param name="apiSecret">Your unique LoginRadius API Secret (You can get it from your LoginRadius user account)</param>
        public LoginRadius(string apiSecret) {
            IsAuthenticated = false;
            if (IsGuid(apiSecret)) {
                request = HttpContext.Current.Request;
                if (!string.IsNullOrEmpty(request[APIToken])) {
                    token = request[APIToken];
                    string hubUrl = string.Empty;
                    if (request.Url.AbsoluteUri.ToLower().Contains("www.")) hubUrl = "hub.loginradius.com";

                    try {
                        if (hubUrl != "") {
                            WebClient wc = new WebClient();
                            string validateUrl = string.Format("http://" + hubUrl + "/userprofile.ashx?token={0}&apisecrete={1}", request[APIToken], apiSecret);
                            Resonse = wc.DownloadString(validateUrl);
                            IsAuthenticated = true;
                        }
                    }
                    catch { IsAuthenticated = false; }
                }
            }
            else { throw new Exception("Invalid API Secret for LoginRadius. Please enter valid API secret."); }
        }

        /// <summary>
        /// Call Basic user it returns Premium user profile.
        /// </summary>
        /// <returns>returns PremiumUserLoginRadiusUserProfile</returns>
        public BasicUserLoginRadiusUserProfile GetBasicUserProfile() {
            BasicUserLoginRadiusUserProfile userprofile = (BasicUserLoginRadiusUserProfile)Newtonsoft.Json.JsonConvert.DeserializeObject(Resonse, typeof(BasicUserLoginRadiusUserProfile));
            SetIsAuthenticated(userprofile);
            return userprofile;
        }

        /// <summary>
        /// Call PremiumUserLoginRadiusUserProfile to get Premium user profile data. If you are not Premium user then you will get null fields
        /// </summary>
        /// <returns>returns PremiumUserLoginRadiusUserProfile</returns>
        public PremiumUserLoginRadiusUserProfile GetPremiumUserProfile() {
            PremiumUserLoginRadiusUserProfile userprofile = (PremiumUserLoginRadiusUserProfile)Newtonsoft.Json.JsonConvert.DeserializeObject(Resonse, typeof(PremiumUserLoginRadiusUserProfile));
            SetIsAuthenticated(userprofile);
            return userprofile;
        }

        /// <summary>
        /// Call UltimateUserLoginRadiusUserProfile to get ultimate user profile data. If you are not ultiamte user then you will get null fields
        /// </summary>
        /// <returns>returns UltimateUserLoginRadiusUserProfile</returns>
        public UltimateUserLoginRadiusUserProfile GetUltimateUserProfile() {
            UltimateUserLoginRadiusUserProfile userprofile = (UltimateUserLoginRadiusUserProfile)Newtonsoft.Json.JsonConvert.DeserializeObject(Resonse, typeof(UltimateUserLoginRadiusUserProfile));
            SetIsAuthenticated(userprofile);
            return userprofile;
        }

        /// <summary>
        /// set IsAuthenicated property for LoginRadiusUserProfile
        /// </summary>
        /// <param name="userprofile"></param>
        private void SetIsAuthenticated(IBasicUserLoginRadiusUserProfile userprofile) {
            if (!String.IsNullOrEmpty(userprofile.ID)) IsAuthenticated = true;
            else IsAuthenticated = false;
        }

        /// <summary>
        /// validate GUID
        /// </summary>
        /// <param name="candidate">string to validate</param>
        /// <returns>boolean</returns>
        private static bool IsGuid(string candidate) {
            Guid output;
            return Guid.TryParse(candidate, out output);
        }
    }
}