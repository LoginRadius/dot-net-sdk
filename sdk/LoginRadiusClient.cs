using System;
using System.Web.Script.Serialization;
using LoginRadius.SDK.API;
using LoginRadius.SDK.Models;
//Loginradius SDK demo
namespace LoginRadius.SDK
{
    /// <summary>
    /// The LoginRadiusClient class is used to create loginradius client object to request and get loginradius response.
    /// </summary>
    public class LoginRadiusClient
    {
        JavaScriptSerializer jsserializer = new JavaScriptSerializer();

        LoginRadiusAccessToken _token;

        /// <summary>
        /// The constructor is used to initialize loginradius client's token
        /// </summary>
        /// <param name="token">Token for current user as LoginRadisuAccessToken format</param>
        public LoginRadiusClient(LoginRadiusAccessToken token)
        {
            if (token == null)
            {
                throw new ArgumentNullException("token");
            }
            else
            {
                _token = token;
            }
        }

        /// <summary>
        /// The constructor is used to initialize loginradius client's token
        /// </summary>
        /// <param name="token">Token for current user as string format</param>
        public LoginRadiusClient(string token)
        {
            if (!string.IsNullOrEmpty(token))
            {
                _token = new LoginRadiusAccessToken(token);
            }
        }

        /// <summary>
        /// The GetResponse method is used to get response of the requested loginradius api 
        /// </summary>
        /// <typeparam name="T">T refers as loginradius model classes</typeparam>
        /// <param name="api">Requested loginradius api</param>
        /// <returns></returns>
        public T GetResponse<T>(ILoginRadiusAPI api) where T : class, new()
        {
            if (api == null)
            {
                throw new ArgumentNullException("api");
            }
            else
            {
                try
                {
                    var response = GetResponse(api);
                    var deserializedobject = jsserializer.Deserialize<T>(response);
                    return deserializedobject;
                }
                catch { }

                return null;
            }
        }

        /// <summary>
        /// The GetResponse method is used to get response of the requested loginradius api 
        /// </summary>
        /// <param name="api">Requested loginradius api</param>
        /// <returns></returns>
        public string GetResponse(ILoginRadiusAPI api)
        {
            return api.ExecuteAPI(_token.access_token);
        }


        /// <summary>
        /// The GetResponse method is used to get provider response of the requested loginradius api 
        /// </summary>
        /// <param name="api">Requested loginradius api</param>
        /// <returns></returns>
        public string GetRawResponse(ILoginRadiusAPI api)
        {
            return api.ExecuteRawAPI(_token.access_token);
        }
    }
}
