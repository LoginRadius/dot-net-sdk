using System;
namespace LoginRadiusSDK.Entity
{
    /// <summary>
    /// model class for LoginRadius access token
    /// </summary>
    public class LoginRadiusAccessToken
    {
        /// <summary>
        /// constructor of LoginRadius access token class
        /// </summary>
        public LoginRadiusAccessToken()
        {

        }


        /// <summary>
        /// Constructor to set LoginRadius access token
        /// </summary>
        /// <param name="token">Token for current user</param>
        public LoginRadiusAccessToken(string token)
        {

            Guid guidtoken;

            if (Guid.TryParse(token, out guidtoken))
            {
                access_token = guidtoken;
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
