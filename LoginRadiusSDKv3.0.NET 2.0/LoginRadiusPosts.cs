// -----------------------------------------------------------------------
// <copyright file="LoginRadiusPosts.cs" company="LoginRadius Inc.">
// Copyright LoginRadius.com 2013
// This file is part of the LoginRadius SDK package.
// </copyright>
// -----------------------------------------------------------------------


namespace LoginRadiusSDK {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Net;
    using System.Web;
    using LoginRadiusDataModal.LoginRadiusDataObject.LoginRadiusDataObject.PostComman;

    /// <summary>
    /// LoginRadius class to get user's posts
    /// </summary>
    public class LoginRadiusPosts {
        string _token;
        string _secret;
        public string Resonse { get; set; }
        /// <summary>
        /// Connstructor to create environment for LoginRadius API
        /// It validates the GUID format of current user's token and LoginRadius secret. 
        /// </summary>
        /// <param name="_token">Token for current user</param>
        /// <param name="_secret">API Secret of LoginRadius App</param>
        public LoginRadiusPosts(string token, string secret) {
            if (Utility.IsGuid(token) && Utility.IsGuid(secret)) {
                this._secret = secret;
                this._token = token;
            }
            else {
                throw new Exception("Session token and/or API secret is not in valid GUID format.");
            }
        }
        /// <summary>
        /// GetPosts function is use to get User's Posts in list format
        /// LoginRadius Rest API for getting user Posts list
        /// https://www.hub.loginradius.com/GetPosts/{yourapisecret}/{yourtoken}
        /// </summary>
        /// <returns>Returns Posts in List Format</returns>
        public List<LoginRadiusPost> GetPosts() {
            List<LoginRadiusPost> posts = new List<LoginRadiusPost>();

            try {
                WebClient wc = new WebClient();
                string validateUrl = string.Format(Requesturl.url + "/GetPosts/{0}/{1}", _secret, _token);
                wc.Encoding = System.Text.Encoding.UTF8;
                Resonse = wc.DownloadString(validateUrl);
                posts = (List<LoginRadiusPost>)Newtonsoft.Json.JsonConvert.DeserializeObject(Resonse, typeof(List<LoginRadiusPost>));
                return posts;
            } catch {
                return posts;
            }
        }
    }
}