using System;
#if NetFramework
using System.Web; 
#endif
using LoginRadiusSDK.V2.Api.Social;

namespace LoginRadiusSDK.V2.Entity
{
    /// <summary>
    /// model class for LoginRadius access token
    /// </summary>
    public class LoginRadiusAccessToken
    {
        private readonly SocialEntity _socialEntity = new SocialEntity();

        public LoginRadiusAccessToken()
        {
        }

        /// <summary>
        /// Constructor to set LoginRadius access token
        /// </summary>
        /// <param name="httpContextToken">Token for current user</param>
        public LoginRadiusAccessToken(string httpContextToken)
        {
            if (!string.IsNullOrWhiteSpace(httpContextToken))
            {
                var token = _socialEntity.GetAccessToken(httpContextToken);
                access_token = token.Response.access_token;
                expires_in = token.Response.expires_in;
                IsFetched = true;
            }
            else
            {
                IsFetched = false;
                access_token = null;
            }
        }

#if NetFramework
        public LoginRadiusAccessToken(HttpContext httpContext)
        {
            if (httpContext.Request.Params["token"] != null)
            {
                var token = _socialEntity.GetAccessToken(httpContext.Request.Params["token"]);
                access_token = token.Response.access_token;
                expires_in = token.Response.expires_in;
                IsFetched = true;
            }
            else
            {
                IsFetched = false;
                access_token = null;
            }
        }
#endif
        public Guid? access_token { get; set; }
        public DateTime expires_in { get; set; }
        public bool IsFetched { get; set; }
    }
}