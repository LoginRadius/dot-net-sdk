// -----------------------------------------------------------------------
// <copyright file="LoginRadiusGetCompaines.cs" company="LoginRadius Inc.">
// Copyright LoginRadius.com 2013
// This file is part of the LoginRadius SDK package.
// </copyright>
// -----------------------------------------------------------------------

namespace LoginRadiusSDK
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Net;
    using System.Web;
    using LoginRadiusDataModal.LoginRadiusDataObject.LoginRadiusDataObject.CompanyFollow;


    /// <summary>
    /// LoginRadius class to get user's LinkedIn profile companies
    /// </summary>
    public class LoginRadiusGetCompaines
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
        public LoginRadiusGetCompaines(string token, string secret)
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
        /// GetFollowCompaines function is use to get user's followed companies. It return companies in List format
        /// This is the LoginRadius rest API used for getting user followed companies list
        /// https://www.hub.loginradius.com/GetCompany/{yourapisecret}/{yourtoken}
        /// </summary>
        /// <returns>return Companies in List Format</returns>
        public List<LoginRadiusCompanyFollow> GetFollowCompaines()
        {
            List<LoginRadiusCompanyFollow> getfollowcompaines = new List<LoginRadiusCompanyFollow>();

            try
            {

                WebClient wc = new WebClient();

                string validateUrl = string.Format(Requesturl.url + "/GetCompany/{0}/{1}", _secret, _token);
                wc.Encoding = System.Text.Encoding.UTF8;
                Resonse = wc.DownloadString(validateUrl);
                getfollowcompaines = (List<LoginRadiusCompanyFollow>)Newtonsoft.Json.JsonConvert.DeserializeObject(Resonse, typeof(List<LoginRadiusCompanyFollow>));
                return getfollowcompaines;
            }
            catch
            {
                return getfollowcompaines;
            }
            
        }
       

    }
}
