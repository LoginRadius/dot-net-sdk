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
    using LoginRadiusDataModal.LoginRadiusDataObject.LoginRadiusDataObject.PostComman;

    /// <summary>
    /// 
    /// </summary>
    public class  LoginRadiusPosts
    {
        string _token;
        string _secret;
        public string Resonse { get; set; }
        /// <summary>
        /// Initialize Loginradius status api wrapper
        /// </summary>
        /// <param name="_token">token for current user</param>
        /// <param name="_secret">seceret of loginradius api</param>
        public LoginRadiusPosts(string token, string secret)
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

        public List<LoginRadiusPost> GetPosts()
        {
            List<LoginRadiusPost> posts = new List<LoginRadiusPost>();

            try
            {

                WebClient wc = new WebClient();

                string validateUrl = string.Format(Requesturl.url + "/GetPosts/{0}/{1}", _secret, _token);

                Resonse = wc.DownloadString(validateUrl);
                posts = (List<LoginRadiusPost>)Newtonsoft.Json.JsonConvert.DeserializeObject(Resonse, typeof(List<LoginRadiusPost>));
                return posts;
            }
            catch
            {
                return posts;
            }
            
        }
       

    }
}
