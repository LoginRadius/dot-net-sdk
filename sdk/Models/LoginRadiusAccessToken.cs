using System;

namespace LoginRadius.SDK.Models
{
    /// <summary>
    /// model class for loginradius access token
    /// </summary>
    public class LoginRadiusAccessToken
    {
        public LoginRadiusAccessToken()
        {

        }

        /// <summary>
        /// Constructor to set loginradius access token
        /// </summary>
        /// <param name="token">Token for current user</param>
        public LoginRadiusAccessToken(string token)
        {
            Guid guidtoken;

            if (Guid.TryParse(token, out guidtoken))
            {
                this.access_token = guidtoken;
            }
            else
            {
                throw new ArgumentNullException("token");
            }
        }

        public Guid access_token { get; set; }
        public DateTime expires_in { get; set; }
    }
}
