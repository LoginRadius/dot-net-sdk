// -----------------------------------------------------------------------
// <copyright file="LoginRadiusGetCompaines.cs" company="">
// TODO: Update copyright text.
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
    /// 
    /// </summary>
    public class LoginRadiusGetContacts
    {
        string _token;
        string _secret;
        public string Resonse { get; set; }
        /// <summary>
        /// Initialize Loginradius status api wrapper
        /// </summary>
        /// <param name="_token">token for current user</param>
        /// <param name="_secret">seceret of loginradius api</param>
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

        public List<LoginRadiusContact> Getcontacts()
        {
            List<LoginRadiusContact> contacts = new List<LoginRadiusContact>();

            try
            {

                WebClient wc = new WebClient();

                string validateUrl = string.Format(Requesturl.url + "/contacts/{0}/{1}", _secret, _token);

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
