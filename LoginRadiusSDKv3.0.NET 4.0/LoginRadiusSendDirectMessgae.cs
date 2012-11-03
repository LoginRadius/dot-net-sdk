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
    public class LoginRadiusSendDirectMessgae
    {
        string _token;
        string _secret;
        public string Resonse { get; set; }
        /// <summary>
        /// Initialize Loginradius status api wrapper
        /// </summary>
        /// <param name="_token">token for current user</param>
        /// <param name="_secret">seceret of loginradius api</param>
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
