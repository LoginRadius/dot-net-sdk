using System;
using System.IO;
using System.Net;
using LoginRadiusSDK.API;
using LoginRadiusSDK.Exception;
using LoginRadiusSDK.Utility.Serialization;

//LoginRadius SDK demo
namespace LoginRadiusSDK.Entity
{
    /// <summary>
    /// The LoginRadius Client class is used to create loginradius client object to request and get LoginRadius response.
    /// </summary>
    public class LoginRadiusClient
    {
        readonly LoginRadiusAccessToken _token;

        /// <summary>
        /// The constructor is used to initialize LoginRadius client's token
        /// </summary>
        /// <param name="token">Token for current user as LoginRadius AccessToken format</param>
        public LoginRadiusClient(LoginRadiusAccessToken token)
        {
            if (token == null)
            {
                throw new ArgumentNullException("token");
            }
            _token = token;
        }

        /// <summary>
        /// The constructor is used to initialize LoginRadius client's token
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
        /// The GetResponse method is used to get response of the requested LoginRadius api 
        /// </summary>
        /// <typeparam name="T">T refers as LoginRadius model classes</typeparam>
        /// <param name="api">Requested LoginRadius api</param>
        /// <returns></returns>
        public T GetResponse<T>(ILoginRadiusApi api) where T : class, new()
        {
            if (api == null)
            {
                throw new ArgumentNullException("api");
            }
            try
            {
                var response = GetResponse(api);
                return response.Deserialize<T>();
            }
            catch (WebException e)
            {
                using (var re = e.Response)
                {
                    if (re != null)
                    {
                        using (var data = re.GetResponseStream())
                        {
                            if (data != null)
                            {
                                var text = new StreamReader(data).ReadToEnd();
                                throw new LoginRadiusException("LoginRadius API Exception", e, text);
                            }
                        }
                    }
                    else
                    {
                        throw new LoginRadiusException("Unable to connect through the Internet", e);
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// The GetResponse method is used to get response of the requested LoginRadius api 
        /// </summary>
        /// <param name="api">Requested LoginRadius api</param>
        /// <returns></returns>
        public string GetResponse(ILoginRadiusApi api)
        {
            return api.ExecuteApi(_token.access_token);
        }


        /// <summary>
        /// The GetResponse method is used to get provider response of the requested LoginRadius api 
        /// </summary>
        /// <param name="api">Requested LoginRadius api</param>
        /// <returns></returns>
        public string GetRawResponse(ILoginRadiusApi api)
        {
            return api.ExecuteRawApi(_token.access_token);
        }
    }
}
