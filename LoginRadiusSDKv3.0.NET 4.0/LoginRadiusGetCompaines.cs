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
    using System.Net;
    using LoginRadiusDataModal.LoginRadiusDataObject.LoginRadiusDataObject.CompanyFollow;


    /// <summary>
    /// LoginRadius class to get user's LinkedIn profile companies
    /// </summary>
    public class LoginRadiusGetCompanies
    {
        string _token;
        string _secret;

        /// <summary>
        /// Raw JSON response for companies data returned from LoginRadius API
        /// </summary>
        public string Response { get; set; }


        /// <summary>
        /// Connstructor to create environment for LoginRadius API
        /// It validates the GUID format of current user's token and LoginRadius secret. 
        /// </summary>
        /// <param name="token">Token for current user</param>
        /// <param name="secret">API Secret of LoginRadius App</param>
        public LoginRadiusGetCompanies(string token, string secret)
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
        /// <![CDATA[
        /// https://www.hub.loginradius.com/GetCompany/{yourapisecret}/{yourtoken}
        /// ]]>
        /// 
        /// </summary>
        /// <returns>return Companies in List Format</returns>
        public List<LoginRadiusCompanyFollow> GetFollowCompanies()
        {
            List<LoginRadiusCompanyFollow> getfollowcompaines = new List<LoginRadiusCompanyFollow>();

            try
            {

                WebClient wc = new WebClient();

                string validateUrl = string.Format(Requesturl.url + "/GetCompany/{0}/{1}", _secret, _token);
                wc.Encoding = System.Text.Encoding.UTF8;
                Response = wc.DownloadString(validateUrl);
                getfollowcompaines = (List<LoginRadiusCompanyFollow>)Newtonsoft.Json.JsonConvert.DeserializeObject(Response, typeof(List<LoginRadiusCompanyFollow>));
                return getfollowcompaines;
            }
            catch
            {
                return getfollowcompaines;
            }
            
        }
       

    }
}
