// -----------------------------------------------------------------------
// <copyright file="LoginRadiusGetTimeLine.cs" company="LoginRadius Inc.">
// Copyright LoginRadius.com 2013
// This file is part of the LoginRadius SDK package.
// </copyright>
// -----------------------------------------------------------------------



namespace LoginRadiusSDK
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using LoginRadiusDataModal.LoginRadiusDataObject.LoginRadiusDataObject.StatusUpdate;

    /// <summary>
    /// LoginRadius class to get user's timeline
    /// </summary>
    public class LoginRadiusGetTimeLine
    {
        string _token;
        string _secret;

        /// <summary>
        /// Raw JSON response for contacts data returned from LoginRadius API
        /// </summary>
        public string Response { get; set; }


        /// <summary>
        /// Connstructor to create environment for LoginRadius API
        /// It validates the GUID format of current user's token and LoginRadius secret. 
        /// </summary>
        /// <param name="token">Token for current user</param>
        /// <param name="secret">API Secret of LoginRadius App</param>
        public LoginRadiusGetTimeLine(string token, string secret)
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
        /// GetTimeLine function is used to get User's TimeLine
        /// LoginRadius Rest API for getting User's Timeline list
        /// <![CDATA[
        /// https://www.hub.loginradius.com/status/timeline/{yourapisecret}/{yourtoken}
        /// ]]>
        /// </summary>
        /// <returns>Returns Timeline in List format</returns>
        public List<LoginRadiusStatuses> GetTimeLine()
        {
            List<LoginRadiusStatuses> timeline = new List<LoginRadiusStatuses>();

            try
            {

                WebClient wc = new WebClient();

                string validateUrl = string.Format(Requesturl.url + "/status/timeline/{0}/{1}", _secret, _token);
                wc.Encoding = System.Text.Encoding.UTF8;
                Response = wc.DownloadString(validateUrl);
                timeline = (List<LoginRadiusStatuses>)Newtonsoft.Json.JsonConvert.DeserializeObject(Response, typeof(List<LoginRadiusStatuses>));
                return timeline;
            }
            catch
            {
                return timeline;
            }
            
        }
       

    }
}
