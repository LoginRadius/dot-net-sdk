using System;
using System.Web;
using LoginRadiusSDK.Exception;
<<<<<<< HEAD
=======
using LoginRadiusSDK.Models;
>>>>>>> master
using LoginRadiusSDK.Utility.Http;
using LoginRadiusSDK.Utility.Serialization;

//LoginRadius SDK demo
namespace LoginRadiusSDK.Entity
{
    /// <summary>
    /// The LoginRadius callback is used to request loginradius api when user  has successfully logged in the preferred provider.
    /// </summary>
<<<<<<< HEAD
    public class LoginRadiusCallback
    {
        readonly HttpClient _client = new HttpClient();
        string accesstokenendpoint = "api/v2/access_token?token={0}&secret={1}";
=======
    public class LoginRadiusCallback : LoginRadiusV2EntityBase
    {  
        private readonly LoginRadiusObject _object = new LoginRadiusObject("access_token");
        private string _token;
        public LoginRadiusCallback(string token = null)
        {
            _token = token;
        }

        public LoginRadiusCallback(string apikey, string apisecret, string token = null)
            : base(apikey,apisecret)
        {
            _token = token;
        }
>>>>>>> master

        /// <summary>
        /// To get LoginRadius callback for loginradius api.
        /// </summary>
        public bool IsCallback
        {
            get
            {
<<<<<<< HEAD
                return !string.IsNullOrEmpty(HttpContext.Current.Request.Form["token"]);
=======
                if (_token != null)
                {
                    return true;
                }
                _token = HttpContext.Current.Request.Form["token"];
                return _token != null;
>>>>>>> master
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
<<<<<<< HEAD
                    return HttpContext.Current.Request.Form["token"];
=======
                    return _token;
>>>>>>> master
                }
                else
                {
                    throw new LoginRadiusException("Request token not exists or Loginradius not calling back, please check IsCallback before accessing this property");
                }
            }
        }
<<<<<<< HEAD
=======
        
>>>>>>> master

        /// <summary>
        /// The Access Token API is used to get the LoginRadius access token after authentication. It will be valid for the specific duration of time specified in the response.
        /// </summary>
<<<<<<< HEAD
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
=======
        /// <returns></returns>
        public LoginRadiusAccessToken GetAccessToken()
        {
            if (IsCallback)
            {
                var getParams = new HttpRequestParameter
                {
                    {"token", RequestToken}
                };
                var response = Get(_object, getParams);
                return response.Deserialize<LoginRadiusAccessToken>();
            }
            throw new LoginRadiusException("Request token is not valid or does not exist.");
        }

        /// <summary>
        /// API is used to validate access_token, check it is valid, expired or active.
        /// </summary>
        /// <returns></returns>
        public LoginRadiusAccessToken ValidateAccessToken(string accessToken)
        {
            var getParams = new HttpRequestParameter
            {
                {"access_token", accessToken}
            };
            var response = Get(_object.ChildObject("Validate"), getParams);
            return response.Deserialize<LoginRadiusAccessToken>();
        }
        public LoginRadiusAccessToken ValidateAccessToken(Guid accessToken)
        {
            return ValidateAccessToken(accessToken.ToString());
        }

        /// <summary>
        ///  API is used to invalidate access token, means expiring token. After this API call passed access_token no longer be active and will not accepted by LoginRadius APIs.
        /// </summary>
        /// <returns></returns>
        public LoginRadiusPostResponse InValidateAccessToken(string accessToken)
        {
            var getParams = new HttpRequestParameter
            {
                {"access_token", accessToken}
            };
            var response = Get(_object.ChildObject("invalidate"), getParams);
            return response.Deserialize<LoginRadiusPostResponse>();
        }
        public LoginRadiusPostResponse InValidateAccessToken(Guid accessToken)
        {
            return InValidateAccessToken(accessToken.ToString());
>>>>>>> master
        }
    }
}
