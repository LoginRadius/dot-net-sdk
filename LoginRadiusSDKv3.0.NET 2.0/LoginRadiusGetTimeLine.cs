// -----------------------------------------------------------------------
// <copyright file="LoginRadiusGetTimeLine.cs" company="LoginRadius Inc.">
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
    using LoginRadiusDataModal.LoginRadiusDataObject.LoginRadiusDataObject.StatusUpdate;

    /// <summary>
    /// LoginRadius class to get user's timeline
    /// </summary>
    public class LoginRadiusGetTimeLine {
        string _token;
        string _secret;
        public string Resonse { get; set; }
        /// <summary>
        /// Connstructor to create environment for LoginRadius API
        /// It validates the GUID format of current user's token and LoginRadius secret. 
        /// </summary>
        /// <param name="_token">Token for current user</param>
        /// <param name="_secret">API Secret of LoginRadius App</param>
        public LoginRadiusGetTimeLine(string token, string secret) {
            if (Utility.IsGuid(token) && Utility.IsGuid(secret)) {
                this._secret = secret;
                this._token = token;
            }
            else {
                throw new Exception("Session token and/or API secret is not in valid GUID format.");
            }
        }
        /// <summary>
        /// GetTimeLine function is used to get User's TimeLine
        /// LoginRadius Rest API for getting User's Timeline list
        /// https://www.hub.loginradius.com/status/timeline/{yourapisecret}/{yourtoken}
        /// </summary>
        /// <returns>Returns Timeline in List format</returns>
        public List<LoginRadiusStatuses> GetTimeLine() {
            List<LoginRadiusStatuses> timeline = new List<LoginRadiusStatuses>();

            try {
                WebClient wc = new WebClient();
                string validateUrl = string.Format(Requesturl.url + "/status/timeline/{0}/{1}", _secret, _token);
                wc.Encoding = System.Text.Encoding.UTF8;
                Resonse = wc.DownloadString(validateUrl);
                timeline = (List<LoginRadiusStatuses>)Newtonsoft.Json.JsonConvert.DeserializeObject(Resonse, typeof(List<LoginRadiusStatuses>));
                return timeline;
            } catch {
                return timeline;
            }
        }
    }
}