using System;
using System.Web;
using LoginRadiusSDK.Exception;
using LoginRadiusSDK.Utility.Http;
using LoginRadiusSDK.Utility.Serialization;

//LoginRadius SDK demo
namespace LoginRadiusSDK.Entity
{
    /// <summary>
    /// The LoginRadius callback is used to request loginradius api when user  has successfully logged in the preferred provider.
    /// </summary>
    public class LoginRadiusCallback
    {
        readonly HttpClient _client = new HttpClient();
        string accesstokenendpoint = "api/v2/access_token?token={0}&secret={1}";

        /// <summary>
        /// To get LoginRadius callback for loginradius api.
        /// </summary>
        public bool IsCallback
        {
            get
            {
                return !string.IsNullOrEmpty(HttpContext.Current.Request.Form["token"]);
            }
        }

        /// <summary>
        /// To get requested token as string format
        /// </summary>
        public string RequestToken
        {
            get
            {
                if (IsCallback)
                {
                    return HttpContext.Current.Request.Form["token"];
                }
                else
                {
                    throw new LoginRadiusException("Request token not exists or Loginradius not calling back, please check IsCallback before accessing this property");
                }
            }
        }

        /// <summary>
        /// The Access Token API is used to get the LoginRadius access token after authentication. It will be valid for the specific duration of time specified in the response.
        /// </summary>
        /// <param name="secret">A unique secret key, which is provided by LoginRadius on your Site manage page</param>
        /// <returns></returns>
        public LoginRadiusAccessToken GetAccessToken(string secret)
        {
            Guid guidsecret;

            if (Guid.TryParse(secret, out guidsecret))
            {
                if (IsCallback)
                {
                    string url = string.Format(Constants.ApiRootDomain + accesstokenendpoint, RequestToken, secret);
                    var response = _client.Request(url, null, HttpMethod.GET);
                    return response.Deserialize<LoginRadiusAccessToken>();
                }
                else
                {
                    throw new LoginRadiusException("Request token not exists or Loginradius not calling back, please check IsCallback before calling this method");
                }
            }
            else
            {
                throw new ArgumentException("Secret is not valid format (Guid) or null", "secret");
            }
        }
    }
}
