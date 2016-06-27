using System.Configuration;
using LoginRadiusSDK.Utility.Http;

namespace LoginRadiusSDK.Entity
{
    public class LoginRadiusV2EntityBase
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly HttpRequestParameter _commHttpRequestParameter;

        /// <summary>
        /// LoginRadius Api and Secret key. 
        /// </summary>
        protected LoginRadiusV2EntityBase()
            : this(new UserRegistrationAuthentication()
            {
                UserRegistrationKey = ConfigurationManager.AppSettings["loginradius:apikey"],
                UserRegistrationSecret = ConfigurationManager.AppSettings["loginradius:apisecret"]
            })
        {
        }

        private LoginRadiusV2EntityBase(UserRegistrationAuthentication authentication)
        {
            Authentication = authentication;
            _commHttpRequestParameter = new HttpRequestParameter()
            {
                {"key", Authentication.UserRegistrationKey},
                {"secret", Authentication.UserRegistrationSecret}
            };
        }

        private UserRegistrationAuthentication Authentication { get; set; }

        private static string GetEndpoint(string api)
        {
            return string.Format("https://api.loginradius.com/api/v2/{0}", api);
        }

        public string Post(LoginRadiusObject @object, string json)
        {
            var response = _httpClient.HttpPostJson(GetEndpoint(@object.ObjectName), _commHttpRequestParameter, json);
            return response.ResponseContent;
        }

        protected string Post(LoginRadiusObject @object, HttpRequestParameter @params)
        {
            var response = _httpClient.HttpPost(GetEndpoint(@object.ObjectName), _commHttpRequestParameter, @params);
            return response.ResponseContent;
        }

        protected string Post(LoginRadiusObject @object, HttpRequestParameter getParams, HttpRequestParameter postParams)
        {
            if (getParams == null)
            {
                getParams = _commHttpRequestParameter;
            }
            else
            {
                foreach (var par in _commHttpRequestParameter)
                {
                    getParams.Add(par.Key, par.Value);
                }
            }

            var response = _httpClient.HttpPost(GetEndpoint(@object.ObjectName), getParams, postParams);
            return response.ResponseContent;
        }

        protected string Post(LoginRadiusObject @object, HttpRequestParameter getParams, string postParams)
        {
            if (getParams == null)
            {
                getParams = _commHttpRequestParameter;
            }
            else
            {
                foreach (var par in _commHttpRequestParameter)
                {
                    getParams.Add(par.Key, par.Value);
                }
            }

            var response = _httpClient.HttpPostJson(GetEndpoint(@object.ObjectName), getParams, postParams);
            return response.ResponseContent;
        }
    }
}
