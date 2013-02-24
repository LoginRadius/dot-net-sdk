// -----------------------------------------------------------------------
// <copyright file="LoginRadiusGetContacts.cs" company="LoginRadius Inc.">
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
    using LoginRadiusDataModal.LoginRadiusDataObject.LoginRadiusDataObject.Groups;
    using LoginRadiusDataModal.LoginRadiusDataObject.UserProfile.Objects;

    /// <summary>
    /// LoginRadius class to get user's friends/connections/contacts
    /// </summary>
    public class LoginRadiusGetContacts
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
        public LoginRadiusGetContacts(string token, string secret)
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
        /// Getcontacts function is use to get User's contacts. It returns contacts in the List format
        /// LoginRadius rest API for getting users contacts list
        /// https://www.hub.loginradius.com/contacts/{yourapisecret}/{yourtoken}
        /// </summary>
        /// <returns>User's contacts in List format</returns>
        public List<LoginRadiusContact> Getcontacts()
        {
            List<LoginRadiusContact> contacts = new List<LoginRadiusContact>();

            try
            {

                WebClient wc = new WebClient();

                string validateUrl = string.Format(Requesturl.url + "/contacts/{0}/{1}", _secret, _token);
                wc.Encoding = System.Text.Encoding.UTF8;
                Resonse = wc.DownloadString(validateUrl);
                contacts = (List<LoginRadiusContact>)Newtonsoft.Json.JsonConvert.DeserializeObject(Resonse, typeof(List<LoginRadiusContact>));
                return contacts;
            }
            catch
            {
                return null;
            }
            
        }
       

    }
}
