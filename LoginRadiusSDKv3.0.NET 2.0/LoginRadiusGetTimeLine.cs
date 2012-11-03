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
    using LoginRadiusDataModal.LoginRadiusDataObject.LoginRadiusDataObject.StatusUpdate;

    /// <summary>
    /// 
    /// </summary>
    public class LoginRadiusGetTimeLine
    {
        string _token;
        string _secret;
        public string Resonse { get; set; }
        /// <summary>
        /// Initialize Loginradius status api wrapper
        /// </summary>
        /// <param name="_token">token for current user</param>
        /// <param name="_secret">seceret of loginradius api</param>
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

        public List<LoginRadiusStatuses> GetTimeLine()
        {
            List<LoginRadiusStatuses> timeline = new List<LoginRadiusStatuses>();

            try
            {

                WebClient wc = new WebClient();

                string validateUrl = string.Format(Requesturl.url + "/status/timeline/{0}/{1}", _secret, _token);

                Resonse = wc.DownloadString(validateUrl);
                timeline = (List<LoginRadiusStatuses>)Newtonsoft.Json.JsonConvert.DeserializeObject(Resonse, typeof(List<LoginRadiusStatuses>));
                return timeline;
            }
            catch
            {
                return timeline;
            }
            
        }
       

    }
}
