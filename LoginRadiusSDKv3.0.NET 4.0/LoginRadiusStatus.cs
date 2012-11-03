// -----------------------------------------------------------------------
// <copyright file="LoginRadiusStatus.cs" company="">
// TODO: Update copyright text.
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
    /// 
    /// </summary>
    public class LoginRadiusStatus
    {
        string _token;
        string _secret;
        public string Resonse { get; set; }
        /// <summary>
        /// Initialize Loginradius status api wrapper
        /// </summary>
        /// <param name="_token">token for current user</param>
        /// <param name="_secret">seceret of loginradius api</param>
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

        public List<LoginRadiusStatuses> GetStatuses()
        {
            List<LoginRadiusStatuses> statuses = new List<LoginRadiusStatuses>();

            try
            {

                WebClient wc = new WebClient();

                string validateUrl = string.Format(Requesturl.url + "/status/get/{0}/{1}", _secret, _token);

                Resonse = wc.DownloadString(validateUrl);
                statuses = (List<LoginRadiusStatuses>)Newtonsoft.Json.JsonConvert.DeserializeObject(Resonse, typeof(List<LoginRadiusStatuses>));
                return statuses;
            }
            catch
            {
                return null;
            }
            
        }
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
