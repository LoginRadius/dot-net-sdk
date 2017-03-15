using LoginRadiusSDK.Utility.Http;

namespace LoginRadiusSDK.Entity
{
    public abstract class LoginRadiusEntity
    {
        private readonly HttpClient _httpClient = new HttpClient();
        protected HttpRequestParameter _commHttpRequestParameter;

        protected abstract string GetEndpoint(string api);
        
        /// <summary>
        /// The GET method sends the encoded user information appended to the page request.
        /// </summary>
        /// <param name="object"></param>
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
        /// <param name="object"></param>
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
        /// <param name="object"></param>
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