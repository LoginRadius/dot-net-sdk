// -----------------------------------------------------------------------
// <copyright file="LoginRadiusGetCompaines.cs" company="">
// TODO: Update copyright text.
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
    /// 
    /// </summary>
    public class LoginRadiusGetCompaines
    {
        string _token;
        string _secret;
        public string Resonse { get; set; }
        /// <summary>
        /// Initialize Loginradius status api wrapper
        /// </summary>
        /// <param name="_token">token for current user</param>
        /// <param name="_secret">seceret of loginradius api</param>
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

        public List<LoginRadiusCompanyFollow> GetFollowCompaines()
        {
            List<LoginRadiusCompanyFollow> getfollowcompaines = new List<LoginRadiusCompanyFollow>();

            try
            {

                WebClient wc = new WebClient();

                string validateUrl = string.Format(Requesturl.url + "/GetCompany/{0}/{1}", _secret, _token);

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
