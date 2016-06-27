using System.Configuration;
using LoginRadiusSDK.Utility.Http;

namespace LoginRadiusSDK.Entity
{
    /// <summary>
    /// LoginRadius entity class that is used as common entity to methods, it describes for the hhtp method, headers which is used in the GET and POST methods.
    /// The Hypertext Transfer Protocol (HTTP) is designed to enable communications between clients and servers.
    /// </summary>
    public class LoginRadiusEntityBase
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly HttpRequestParameter _commHttpRequestParameter;

        /// <summary>
        /// LoginRadius Api and Secret key. 
        /// </summary>
        protected LoginRadiusEntityBase()
            : this(new UserRegistrationAuthentication()
                {
                    UserRegistrationKey = ConfigurationManager.AppSettings["loginradius:apikey"],
                    UserRegistrationSecret = ConfigurationManager.AppSettings["loginradius:apisecret"] 
                })
        {
        }

        private LoginRadiusEntityBase(UserRegistrationAuthentication authentication)
        {
            Authentication = authentication;

            _commHttpRequestParameter = new HttpRequestParameter()
            {
                {"appkey", Authentication.UserRegistrationKey},
                {"appsecret", Authentication.UserRegistrationSecret}
            };
        }

        private UserRegistrationAuthentication Authentication { get; set; }

        private static string GetEndpoint(string api)
        {
            return string.Format("https://api.loginradius.com/raas/v1/{0}", api);
        }

        /// <summary>
        /// The GET method sends the encoded user information appended to the page request.
        /// </summary>
        /// <param name="@object"></param>
        /// <param name="object"></param>
        /// <returns></returns>
        public string Get(LoginRadiusObject @object)
        {

            var response = _httpClient.HttpGet(GetEndpoint(@object.ObjectName), _commHttpRequestParameter);
            return response.ResponseContent;
        }

        protected string Get(LoginRadiusObject @object, HttpRequestParameter parameter)
        {
            if (parameter == null)
            {
                parameter = _commHttpRequestParameter;
            }
            else
            {
                foreach (var par in _commHttpRequestParameter)
                {
                    parameter.Add(par.Key, par.Value);
                }
            }

            var response = _httpClient.HttpGet(GetEndpoint(@object.ObjectName), parameter);
            return response.ResponseContent;
        }

        /// <summary>
        /// The GET method sends the encoded user information appended to the page request with specified headers.
        /// </summary>
        /// <param name="@object"></param>
        /// <param name="object"></param>
        /// <param name="accept">Headers which is to be send in HTTP GET request.</param>
        /// <returns></returns>
        public string Get(LoginRadiusObject @object, string accept)
        {
            _httpClient.Headers["Accept"] = accept;
            var response = _httpClient.HttpGet(GetEndpoint(@object.ObjectName), _commHttpRequestParameter);
            return response.ResponseContent;
        }

        /// <summary>
        /// The POST method transfers information via HTTP headers. The information is encoded as described in case of GET method and put into a header called QUERY_STRING.
        /// </summary>
        /// <param name="@object"></param>
        /// <param name="object"></param>
        /// <param name="json"></param>
        /// <returns></returns>
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
