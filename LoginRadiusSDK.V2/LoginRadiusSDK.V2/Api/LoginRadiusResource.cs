using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
using LoginRadiusSDK.V2.Exception;
using LoginRadiusSDK.V2.Http;
using LoginRadiusSDK.V2.Manager;
using LoginRadiusSDK.V2.Models;
using LoginRadiusSDK.V2.Util;
using LoginRadiusSDK.V2.Util.Serialization;
using Newtonsoft.Json;
using LoginRadiusSDK.V2.Entity;
using LoginradiusSdk.Entity.AppSettings;

namespace LoginRadiusSDK.V2.Api
{
    /// <summary>
    /// Abstract class that handles configuring an HTTP request prior to making an API call.
    /// </summary>
    public abstract class LoginRadiusResource : LoginRadiusSerializableObject
    {
        /// <summary>
        /// List of supported HTTP methods when making HTTP requests to the LoginRadius REST API.
        /// </summary>
        public enum HttpMethod
        {
            /// <summary>
            /// GET HTTP request. This is typically used in API operations to retrieve a static resource.
            /// </summary>
            Get,

            /// <summary>
            /// POST HTTP request. This is typically used in API operations that require data in the request body to complete.
            /// </summary>
            Post,

            /// <summary>
            /// PUT HTTP request. This is used in some API operations that update a given resource.
            /// </summary>
            Put,

            /// <summary>
            /// DELETE HTTP request. This is typcially used in API oeprations that delete a given resource.
            /// </summary>
            Delete
        }

        public enum RequestType
        {
            /// <summary>
            /// 
            /// </summary>
            Authentication,

            /// <summary>
            /// 
            /// </summary>
            Social,

            /// <summary>
            /// 
            /// </summary>
            AdvancedSocial,

            /// <summary>
            /// 
            /// </summary>
            Identity,

            /// <summary>
            /// 
            /// </summary>
            Role,

            /// <summary>
            /// 
            /// </summary>
            Sso,

            /// <summary>
            /// 
            /// </summary>
            Cloud,

            /// <summary>
            /// 
            /// </summary>
            RestHook,

            /// <summary>
            /// 
            /// </summary>
            AdvancedSharing,

            AccessToken,

            /// <summary>
            /// 
            /// </summary>
            IdentityAuth,

            ServerInfo,
            Webhook
        }

        /// <summary>
        /// Gets the last request sent by the SDK in the current thread.
        /// </summary>
        public static ThreadLocal<RequestDetails> LastRequestDetails { get; private set; }

        /// <summary>
        /// Gets the last response received by the SDK in the current thread.
        /// </summary>
        public static ThreadLocal<ResponseDetails> LastResponseDetails { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        private static QueryParameters _commHttpRequestParameter;

        /// <summary>
        /// 
        /// </summary>
        private CustomerRegistrationAuthentication Authentication { get; set; }

        /// <summary>
        /// LoginRadius Api and Secret key. 
        /// </summary>
        protected LoginRadiusResource()
            : this(new CustomerRegistrationAuthentication
            {
                UserRegistrationKey = LoginRadiusAppSettings.AppKey,
                UserRegistrationSecret = LoginRadiusAppSettings.AppSecret
            })
        {
        }

        private LoginRadiusResource(CustomerRegistrationAuthentication authentication)
        {
            Authentication = authentication;
            _commHttpRequestParameter = new QueryParameters
            {
                {"apikey", Authentication.UserRegistrationKey},
                {"apisecret", Authentication.UserRegistrationSecret}
            };
        }

        /// <summary>
        /// Static constructor initializing any static properties.
        /// </summary>
        static LoginRadiusResource()
        {
            LastRequestDetails = new ThreadLocal<RequestDetails>();
            LastResponseDetails = new ThreadLocal<ResponseDetails>();
        }

        /// <summary>
        /// Configures and executes REST call: Supports JSON
        /// </summary>
        /// <param name="requestType"></param>
        /// <param name="httpMethod">HttpMethod type</param>
        /// <param name="resource">URI path of the resource</param>
        /// <param name="payload">JSON request payload</param>
        /// <param name="queryParameters"></param>
        /// <returns>Response object or null otherwise for void API calls</returns>    
        public static object ConfigureAndExecute(RequestType requestType, HttpMethod httpMethod, string resource,
            QueryParameters queryParameters, string payload = "")
        {
            return ConfigureAndExecute<object>(requestType, httpMethod, resource, queryParameters, payload);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="requestType"></param>
        /// <param name="httpMethod"></param>
        /// <param name="resource"></param>
        /// <returns></returns>
        protected static ApiResponse<T> ConfigureAndExecute<T>(RequestType requestType, HttpMethod httpMethod,
            string resource)
        {
            return ConfigureAndExecute<T>(requestType, httpMethod, resource, null, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="requestType"></param>
        /// <param name="httpMethod"></param>
        /// <param name="resource"></param>
        /// <param name="payload"></param>
        /// <returns></returns>
        protected static ApiResponse<T> ConfigureAndExecute<T>(RequestType requestType, HttpMethod httpMethod,
            string resource,
            string payload)
        {
            return ConfigureAndExecute<T>(requestType, httpMethod, resource, null, payload);
        }

        /// <summary>
        /// Configures and executes REST call: Supports JSON
        /// </summary>
        /// <typeparam name="T">Generic Type parameter for response object</typeparam>
        /// <param name="requestType"></param>
        /// <param name="httpMethod">HttpMethod type</param>
        /// <param name="resource">URI path of the resource</param>
        /// <param name="payload">JSON request payload</param>
        /// <param name="queryParameters"></param>
        /// <returns>Response object or null otherwise for void API calls</returns>
        /// <exception cref="HttpException">Thrown if there was an error sending the request.</exception>
        protected static ApiResponse<T> ConfigureAndExecute<T>(RequestType requestType, HttpMethod httpMethod,
            string resource = "",
            QueryParameters queryParameters = null, string payload = "")
        {
            try
            {
                // Create the URI where the HTTP request will be sent.
                Uri uniformResourceIdentifier;
                var endPoint = GetEndpoint(requestType, resource, queryParameters);
                var baseUri = new Uri(endPoint);
                if (resource != null)
                {
                    var resourceUri = baseUri;
                    if (!Uri.TryCreate(resourceUri, resource, out uniformResourceIdentifier))
                    {
                        throw new LoginRadiusException("Cannot create URL; baseURI=" + baseUri + ", resourcePath=" +
                                                       resource);
                    }
                    uniformResourceIdentifier = resourceUri;
                }
                else
                {
                    uniformResourceIdentifier = baseUri;
                }

                var config = GetConfiguration();

                // Create the HttpRequest object that will be used to send the HTTP request.
                var connMngr = ConnectionManager.Instance;
                var httpRequest = ConnectionManager.GetConnection(config, uniformResourceIdentifier.ToString());
                httpRequest.Method = httpMethod.ToString();

                httpRequest.ContentType = BaseConstants.ContentTypeHeaderJson;

                // Execute call
                var connectionHttp = new HttpConnection(config);

                // Setup the last request & response details.
                LastRequestDetails.Value = connectionHttp.RequestDetails;
                LastResponseDetails.Value = connectionHttp.ResponseDetails;

                payload = payload == null ? "" : payload;

                var response = connectionHttp.Execute(payload, httpRequest, payload.Length);

                if (typeof(T).Name.Equals("Object"))
                {
                    return default(ApiResponse<T>);
                }
                if (typeof(T).Name.Equals("String"))
                {
                    return (ApiResponse<T>) Convert.ChangeType(response, typeof(T));
                }

                return new ApiResponse<T> {Response = JsonFormatter.ConvertFromJson<T>(response)};
            }
            catch (ConnectionException ex)
            {
                try
                {
                    return new ApiResponse<T>
                    {
                        _ApiExceptionResponse =
                            JsonConvert.DeserializeObject<ApiExceptionResponse>(((ConnectionException) ex).Response)
                    };
                }
                catch
                {
                    throw ex;
                }
            }
            catch (LoginRadiusException e)
            {
                // If get a LoginRadius, just rethrow to preserve the stack trace.
                return new ApiResponse<T> {_ApiExceptionResponse = e.ErrorResponse};
            }
            catch (System.Exception ex)
            {
                throw new LoginRadiusException(ex.Message, ex);
            }
        }

        private static string GetEndpoint(RequestType type, string apiPath, QueryParameters additionalParameters = null)
        {
            QueryParameters requestParameter;
            string baseEndPoint;
            var q = new QueryParameters
            {
                ["apikey"] = LoginRadiusAppSettings.AppKey,
                ["apisecret"] = LoginRadiusAppSettings.AppSecret
            };
            _commHttpRequestParameter = q;

            switch (type)
            {
                case RequestType.Authentication:
                    requestParameter = new QueryParameters {["apikey"] = _commHttpRequestParameter["apikey"]};
                    baseEndPoint = BaseConstants.RestAuthApiEndpoint;
                    break;
                case RequestType.Social:
                    //requestParameter = _commHttpRequestParameter;
                    requestParameter = new QueryParameters { };
                    baseEndPoint = BaseConstants.RestApiEndpoint;
                    break;
                case RequestType.AccessToken:
                    requestParameter = new QueryParameters
                    {
                        ["secret"] = _commHttpRequestParameter["apisecret"]
                    };
                    baseEndPoint = BaseConstants.RestApiEndpoint;
                    break;
                case RequestType.AdvancedSocial:
                    requestParameter = new QueryParameters
                    {
                        ["key"] = _commHttpRequestParameter["apikey"],
                        ["secret"] = _commHttpRequestParameter["apisecret"]
                    };
                    baseEndPoint = BaseConstants.RestApiEndpoint;
                    break;
                case RequestType.AdvancedSharing:
                    requestParameter = new QueryParameters
                    {
                        ["key"] = _commHttpRequestParameter["apikey"]
                    };
                    baseEndPoint = BaseConstants.RestShareApiEndpoint;
                    break;
                case RequestType.Cloud:
                case RequestType.Sso:
                    baseEndPoint = BaseConstants.RestApiEndpoint;
                    requestParameter = new QueryParameters
                    {
                        ["key"] = _commHttpRequestParameter["apikey"],
                        ["secret"] = _commHttpRequestParameter["apisecret"]
                    };
                    break;
                case RequestType.Identity:
                    baseEndPoint = BaseConstants.RestIdentityApiEndpoint;
                    requestParameter = _commHttpRequestParameter;
                    break;
                case RequestType.Role:
                    baseEndPoint = BaseConstants.RestRoleApiEndpoint;
                    requestParameter = _commHttpRequestParameter;
                    break;
                case RequestType.RestHook:
                    baseEndPoint = BaseConstants.RestHookApiEndpoint;
                    requestParameter = new QueryParameters
                    {
                        ["api_key"] = _commHttpRequestParameter["apikey"],
                        ["api_secret"] = _commHttpRequestParameter["apisecret"]
                    };
                    break;

                case RequestType.ServerInfo:
                    baseEndPoint = BaseConstants.ServerinfoApiEndpoint;
                    requestParameter = new QueryParameters
                    {
                        ["apikey"] = _commHttpRequestParameter["apikey"],
                    };
                    break;
                case RequestType.Webhook:
                    baseEndPoint = BaseConstants.WebhokApiEndpoint;
                    requestParameter = new QueryParameters
                    {
                        ["apikey"] = _commHttpRequestParameter["apikey"],
                        ["apisecret"] = _commHttpRequestParameter["apisecret"],
                    };
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
            if (additionalParameters != null && additionalParameters.Count > 0)
            {
                foreach (var par in requestParameter)
                {
                    additionalParameters.Add(par.Key, par.Value);
                }
            }
            else
            {
                additionalParameters = requestParameter;
            }
            return string.IsNullOrWhiteSpace(apiPath)
                ? $"{baseEndPoint}{additionalParameters.ToUrlFormattedString()}"
                : $"{baseEndPoint}{apiPath}{additionalParameters.ToUrlFormattedString()}";
        }

        private static Dictionary<string, string> GetConfiguration()
        {
            var config = typeof(LoginRadiusSdkGlobalConfig) as IDictionary<string, string>;
            var dictionary = new Dictionary<string, string>();
            if (config != null)
            {
                foreach (var prop in config.Where(prop => !string.IsNullOrWhiteSpace(prop.Value)))
                {
                    dictionary.Add(prop.Key, prop.Value);
                }
            }
            return dictionary;
        }
    }
}