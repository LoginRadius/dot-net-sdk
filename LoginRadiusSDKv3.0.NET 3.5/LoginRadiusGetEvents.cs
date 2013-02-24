// -----------------------------------------------------------------------
// <copyright file="LoginRadiusGetEvents.cs" company="LoginRadius Inc.">
// Copyright LoginRadius.com 2013
// This file is part of the LoginRadius SDK package.
// </copyright>
// -----------------------------------------------------------------------

namespace LoginRadiusSDK
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Net;
    using System.Web;
    
    using LoginRadiusDataModal.LoginRadiusDataObject.LoginRadiusDataObject.EventComman;

    /// <summary>
    /// LoginRadius class to get users profile events
    /// </summary>
    public class   LoginRadiusGetEvents
    {
        string _token;
        string _secret;
        public string Resonse { get; set; }
        /// <summary>
        /// Connstructor to create environment for LoginRadius API
        /// It validates the GUID format of current user's token and LoginRadius secret. 
        /// </summary>
        /// <param name="_token">Token for current user</param>
        /// <param name="_secret">API Secret of LoginRadius App</param>
        public LoginRadiusGetEvents(string token, string secret)
        {
            if (Utility.IsGuid(token) && Utility.IsGuid(secret))
            {
                this._secret = secret;
                this._token = token;
            }
            else
            {
                throw new Exception("Token or secret not valid guids format!!");
            }
        }
        /// <summary>
        /// GetEvents function is use to get User's Events from his Facebook profile
        /// LoginRadius Rest API for getting User's Events
        /// https://www.hub.loginradius.com/GetEvents/{yourapisecret}/{yourtoken}
        /// </summary>
        /// <returns>Returns User's Events in list format</returns>
        public List<LoginRadiusEvents> GetEvents()
        {
            List<LoginRadiusEvents> events = new List<LoginRadiusEvents>();

            try
            {

                WebClient wc = new WebClient();

                string validateUrl = string.Format(Requesturl.url + "/GetEvents/{0}/{1}", _secret, _token);
                wc.Encoding = System.Text.Encoding.UTF8;
                Resonse = wc.DownloadString(validateUrl);
                events = (List<LoginRadiusEvents>)Newtonsoft.Json.JsonConvert.DeserializeObject(Resonse, typeof(List<LoginRadiusEvents>));
                return events;
            }
            catch
            {
                return events;
            }
            
        }
       

    }
}
