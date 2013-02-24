// -----------------------------------------------------------------------
// <copyright file="LoginRadiusSendDirectMessgae.cs" company="LoginRadius Inc.">
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
    using LoginRadiusDataModal.LoginRadiusDataObject.LoginRadiusDataObject.StatusUpdate;
    using System.Net;
    using System.Web;
    /// <summary>
    /// LoginRadius class to send direct message to user's contacts
    /// </summary>
    public class LoginRadiusSendDirectMessgae
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
        public LoginRadiusSendDirectMessgae(string token, string secret)
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
        /// SendDirectMessgae function is use to send direct message in Twitter/LinkedIn 
        /// LoginRadius Rest API for sending direct message
        /// https://www.hub.loginradius.com/directmessage/{yourapisecret}/{yourtoken}
        /// </summary>
        /// <returns>Returns true/false</returns>
        /// <param name="sendto">User ID of User's contact/friend list (retrun list from LoginRadiusGetContacts function)</param>
        /// <param name="subject">Subject of the Message</param>
        /// <param name="message">Message to be send</param>
        public bool SendDirectMessgae(string sendto, string subject, string message)
        {
            try
            {

                WebClient wc = new WebClient();

                string validateUrl = string.Format(Requesturl.url + "/directmessage/{0}/{1}?sendto={2}&subject={3}&message={4}", _secret, _token, sendto,subject ,message);

                Resonse = wc.DownloadString(validateUrl);
                return true;
            }
            catch
            {
                return false;
            }
           
        }

    }
}
