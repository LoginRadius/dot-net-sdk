// -----------------------------------------------------------------------
// <copyright file="LoginRadiusStatus.cs" company="LoginRadius Inc.">
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
    /// LoginRadius class for the status message get and post to user's wall
    /// </summary>
    public class LoginRadiusStatus
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
        public LoginRadiusStatus(string token, string secret)
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
        /// GetStatusMessages function is use to get User Status messages
        /// LoginRadius Rest API for getting user status messages
        /// https://www.hub.loginradius.com/status/get/{yourapisecret}/{yourtoken}
        /// </summary>
        /// <returns>Returns Status message in List</returns>
        public List<LoginRadiusStatuses> GetStatuses()
        {
            List<LoginRadiusStatuses> statuses = new List<LoginRadiusStatuses>();

            try
            {

                WebClient wc = new WebClient();

                string validateUrl = string.Format(Requesturl.url + "/status/get/{0}/{1}", _secret, _token);
                wc.Encoding = System.Text.Encoding.UTF8;

                Resonse = wc.DownloadString(validateUrl);
                statuses = (List<LoginRadiusStatuses>)Newtonsoft.Json.JsonConvert.DeserializeObject(Resonse, typeof(List<LoginRadiusStatuses>));
                return statuses;
            }
            catch
            {
                return null;
            }
            
        }
        /// <summary>
        /// UpdateStatus function is use to post/update status on users or friends Facebook Wall
        /// LoginRadius REST API for updateing status message
        /// https://www.hub.loginradius.com/status/update/{yourapisecret}/{yourtoken}?to={to}&title={title}&url={url}&imageurl={imageurl}&status={statusmessage}&caption={caption}&description={description}
        /// </summary>
        /// <returns>return true/false</returns>
        /// <param name="to">[Optional] Pass FriendID- if you want to update status message for a particular friend, else leave blank to post it on current user's wall</param>
        /// <param name="title">[Optional] Title of the status message</param>
        /// <param name="url">[Optional] URL of the status message</param>
        /// <param name="imageurl">[Optional] Image URL that you want to add to status message</param>
        /// <param name="message">Message of the status post</param>
        /// <param name="caption">[Optional] Caption that you want add to staus message</param>
        /// <param name="description">[Optional] Description that you want to add to status message</param>
        /// <returns>return true/false, if the post is successful or not</returns>
        public bool UpdateStatus(string to, string title, string url, string imageurl, string message, string caption, string description)
        {
            try
            {

                WebClient wc = new WebClient();

                string validateUrl = string.Format(Requesturl.url + "/status/update/{0}/{1}?to={2}&title={3}&url={4}&imageurl={5}&status={6}&caption={7}&description={8}", _secret, _token, to, title, url, imageurl, message, caption, description);

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
