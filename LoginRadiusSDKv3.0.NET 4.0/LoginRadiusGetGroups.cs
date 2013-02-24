// -----------------------------------------------------------------------
// <copyright file="LoginRadiusGetGroups.cs" company="LoginRadius Inc.">
// Copyright LoginRadius.com 2013
// This file is part of the LoginRadius SDK package.
// </copyright>
// -----------------------------------------------------------------------

namespace LoginRadiusSDK
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using LoginRadiusDataModal.LoginRadiusDataObject.LoginRadiusDataObject.Groups;


    /// <summary>
    /// LoginRadius class to get user's groups 
    /// </summary>
    public class LoginRadiusGetGroups
    {
        string _token;
        string _secret;

        /// <summary>
        /// Raw JSON response for groups data returned from LoginRadius API
        /// </summary>
        public string Response { get; set; }


        /// <summary>
        /// Connstructor to create environment for LoginRadius API
        /// It validates the GUID format of current user's token and LoginRadius secret. 
        /// </summary>
        /// <param name="token">Token for current user</param>
        /// <param name="secret">API Secret of LoginRadius App</param>
        public LoginRadiusGetGroups(string token, string secret)
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
        /// GetGroups function is use to get User's Groups in list format
        /// LoginRadius Rest API for getting user groups list
        /// <![CDATA[
        /// https://hub.loginradius.com/GetGroups/{yourapisecret}/{yourtoken}
        /// ]]>
        /// </summary>
        /// <returns>Returns User's Groups in List format</returns>
        public List<LoginRadiusGroups> GetGroups()
        {
            List<LoginRadiusGroups> groups = new List<LoginRadiusGroups>();

            try
            {

                WebClient wc = new WebClient();

                string validateUrl = string.Format(Requesturl.url + "/GetGroups/{0}/{1}", _secret, _token);
                wc.Encoding = System.Text.Encoding.UTF8;
                Response = wc.DownloadString(validateUrl);
                groups = (List<LoginRadiusGroups>)Newtonsoft.Json.JsonConvert.DeserializeObject(Response, typeof(List<LoginRadiusGroups>));
                return groups;
            }
            catch
            {
                return groups;
            }
            
        }
       

    }
}
