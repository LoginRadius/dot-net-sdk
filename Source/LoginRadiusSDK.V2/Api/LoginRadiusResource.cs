using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using LoginRadiusSDK.V2.Exception;
using LoginRadiusSDK.V2.Http;
using LoginRadiusSDK.V2.Models;
using LoginRadiusSDK.V2.Util;
using LoginRadiusSDK.V2.Util.Serialization;
using Newtonsoft.Json;


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
            GET,

            /// <summary>
            /// POST HTTP request. This is typically used in API operations that require data in the request body to complete.
            /// </summary>
            POST,

            /// <summary>
            /// PUT HTTP request. This is used in some API operations that update a given resource.
            /// </summary>
            PUT,

            /// <summary>
            /// DELETE HTTP request. This is typcially used in API oeprations that delete a given resource.
            /// </summary>
            DELETE
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

            /// <summary>
            /// 
            /// </summary>
            AccessToken,

            /// <summary>
            /// 
            /// </summary>
            IdentityAuth,

            /// <summary>
            /// 
            /// </summary>
            ServerInfo,

            /// <summary>
            /// 
            /// </summary>
            Webhook,
            /// <summary>
            /// 
            /// </summary>
            RegistrationData,
            /// <summary>
            /// 
            /// </summary>
            RegistrationDataAuth,
            /// <summary>
            /// 
            /// </summary>
            Configuration


        }

        /// <summary>
        /// Gets the last request sent by the SDK in the current thread.
        /// </summary>
        public static ThreadLocal<RequestDetails> LastRequestDetails { get; private set; }

        /// <summary>
        /// Gets the last response received by the SDK in the current thread.
        /// </summary>
        public static ThreadLocal<ResponseDetails> LastResponseDetails { get; private set; }

        private static bool _requestChannel;

        internal static ConcurrentDictionary<string, string> ConfigDictionary;

        /// <summary>
        /// Static constructor initializing any static properties.
        /// </summary>
        static LoginRadiusResource()
        {
            LastRequestDetails = new ThreadLocal<RequestDetails>();
            LastResponseDetails = new ThreadLocal<ResponseDetails>();
            ConfigDictionary = ConfigManager.Instance.GetConfiguration();
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
        internal static object ConfigureAndExecute(RequestType requestType, HttpMethod httpMethod, string resource,
            QueryParameters queryParameters, string payload = "")
        {
            return ConfigureAndExecute<object>(requestType, httpMethod, resource, queryParameters, payload);
        }

        static string CreateHash(string apiSecret, string endPoint, string httpMethod, string expiryTime,
            string payload = null)
        {
            string stringToHash;
            string decodedUrl;
            string encodedUrl;

#if NETSTANDARD1_3
            decodedUrl = System.Net.WebUtility.UrlDecode(endPoint);
            encodedUrl = System.Net.WebUtility.UrlEncode(decodedUrl)?.ToLower();
#else
            decodedUrl = System.Web.HttpUtility.UrlDecode(endPoint);
            encodedUrl = System.Web.HttpUtility.UrlEncode(decodedUrl)?.ToLower();
#endif

            if (!string.IsNullOrEmpty(payload))
            {
                stringToHash = expiryTime + ":" + encodedUrl + ":" + payload;
            }
            else
            {
                stringToHash = expiryTime + ":" + encodedUrl;
            }


            var hmacSha = new HMACSHA256(Encoding.UTF8.GetBytes(apiSecret));
            hmacSha.Initialize();
            byte[] hmac = hmacSha.ComputeHash(Encoding.UTF8.GetBytes(stringToHash));

            var hash = Convert.ToBase64String(hmac);

            return hash;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="requestType"></param>
        /// <param name="httpMethod"></param>
        /// <param name="resource"></param>
        /// <returns></returns>
        protected internal static ApiResponse<T> ConfigureAndExecute<T>(RequestType requestType, HttpMethod httpMethod,
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
        protected internal static ApiResponse<T> ConfigureAndExecute<T>(RequestType requestType, HttpMethod httpMethod,
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
        /// <param name="headers"></param>
        /// <returns>Response object or null otherwise for void API calls</returns>
        /// <exception cref="HttpException">Thrown if there was an error sending the request.</exception>
        protected internal static ApiResponse<T> ConfigureAndExecute<T>(RequestType requestType, HttpMethod httpMethod,
            string resource = "",
            QueryParameters queryParameters = null, string payload = "", Dictionary<string, string> headers = null)
        {
            try
            {
                // Create the URI where the HTTP request will be sent.
                Uri uniformResourceIdentifier;
                var endPoint = GetEndpoint(requestType, resource, out Dictionary<string, string> authHeaders, queryParameters);
                if (ConfigDictionary[BaseConstants.ApiRequestSigning] != null && ConfigDictionary[BaseConstants.ApiRequestSigning] == "true" && _requestChannel)
                {
                    var time = DateTime.UtcNow.AddMinutes(15).ToString("yyyy-M-d h:m:s tt");
                    var hash = CreateHash(ConfigDictionary[BaseConstants.LoginRadiusApiSecret], endPoint, httpMethod.ToString(), time, payload);

                    if (headers == null)
                    {
                        headers = new Dictionary<string, string>();
                    }

                    headers.Add("digest", "SHA-256=" + hash);
                    headers.Add("X-Request-Expires", time);
                }
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

                
                var connMngr = ConnectionManager.Instance;
                var httpRequest = connMngr.GetConnection(ConfigDictionary, uniformResourceIdentifier.ToString(), headers, authHeaders);
                httpRequest.Method = httpMethod.ToString();

                httpRequest.ContentType = BaseConstants.ContentTypeHeaderJson;

                // Execute call
                var connectionHttp = new HttpConnection(ConfigDictionary);

                // Setup the last request & response details.
                LastRequestDetails.Value = connectionHttp.RequestDetails;
                LastResponseDetails.Value = connectionHttp.ResponseDetails;

                payload = payload ?? "";

                var response = connectionHttp.Execute(payload, httpRequest, payload.Length);

                if (typeof(T).Name.Equals("Object"))
                {
                    return default(ApiResponse<T>);
                }
                if (typeof(T).Name.Equals("String"))
                {
                    return (ApiResponse<T>)Convert.ChangeType(response, typeof(T));
                }

                return new ApiResponse<T> { Response = JsonFormatter.ConvertFromJson<T>(response) };
            }
            catch (ConnectionException ex)
            {
                try
                {
                    if (ex.Response == string.Empty)
                    {
                        throw;
                    }
                    var exception = new ApiResponse<T>();
                    exception.RestException = JsonConvert.DeserializeObject<ApiExceptionResponse>(ex.Response);
                    return exception;
                }
                catch
                {
                    throw ex;
                }
            }
            catch (LoginRadiusException e)
            {
                // If get a LoginRadius, just rethrow to preserve the stack trace.
                return new ApiResponse<T> { RestException = e.ErrorResponse };
            }
            catch (System.Exception ex)
            {
                throw new LoginRadiusException(ex.Message, ex);
            }
        }

        private static string GetEndpoint(RequestType type, string apiPath, out Dictionary<string, string> authHeaders, QueryParameters additionalParameters = null)
        {
            QueryParameters requestParameter;
            string baseEndPoint;
            authHeaders = null;

            switch (type)
            {
                case RequestType.Authentication:
                    requestParameter = new QueryParameters { ["apikey"] = ConfigDictionary[BaseConstants.LoginRadiusApiKey] };
                    baseEndPoint = BaseConstants.RestAuthApiEndpoint;
                    break;
                case RequestType.Social:
                    requestParameter = new QueryParameters();
                    baseEndPoint = BaseConstants.RestApiEndpoint;
                    break;
                case RequestType.AccessToken:
                    requestParameter = new QueryParameters
                    {
                        ["secret"] = ConfigDictionary[BaseConstants.LoginRadiusApiSecret]
                    };

                    baseEndPoint = BaseConstants.RestApiEndpoint;
                    break;
                case RequestType.AdvancedSocial:
                    if (ConfigDictionary[BaseConstants.ApiRequestSigning] != null && ConfigDictionary[BaseConstants.ApiRequestSigning] == "true")
                    {
                        _requestChannel = true;
                        requestParameter = new QueryParameters
                        {
                            ["key"] = ConfigDictionary[BaseConstants.LoginRadiusApiKey]
                        };
                    }
                    else
                    {
                        requestParameter = new QueryParameters
                        {
                            ["key"] = ConfigDictionary[BaseConstants.LoginRadiusApiKey],
                            ["secret"] = ConfigDictionary[BaseConstants.LoginRadiusApiSecret]
                        };
                    }
                    baseEndPoint = BaseConstants.RestApiEndpoint;
                    break;
                case RequestType.AdvancedSharing:
                    requestParameter = new QueryParameters
                    {
                        ["key"] = ConfigDictionary[BaseConstants.LoginRadiusApiKey]
                    };
                    baseEndPoint = BaseConstants.RestShareApiEndpoint;
                    break;
                case RequestType.Cloud:
                case RequestType.Sso:
                    baseEndPoint = BaseConstants.RestApiEndpoint;
                    if (ConfigDictionary[BaseConstants.ApiRequestSigning] != null && ConfigDictionary[BaseConstants.ApiRequestSigning] == "true")
                    {
                        _requestChannel = true;
                        requestParameter = new QueryParameters
                        {
                            ["key"] = ConfigDictionary[BaseConstants.LoginRadiusApiKey]
                        };
                    }
                    else
                    {
                        requestParameter = new QueryParameters
                        {
                            ["key"] = ConfigDictionary[BaseConstants.LoginRadiusApiKey],
                            ["secret"] = ConfigDictionary[BaseConstants.LoginRadiusApiSecret]
                        };
                    }
                    break;
                case RequestType.Identity:
                    baseEndPoint = BaseConstants.RestIdentityApiEndpoint;

                    if (ConfigDictionary[BaseConstants.ApiRequestSigning] != null && ConfigDictionary[BaseConstants.ApiRequestSigning] == "true")
                    {
                        _requestChannel = true;
                        requestParameter = new QueryParameters { ["apiKey"] = ConfigDictionary[BaseConstants.LoginRadiusApiKey] };
                    }
                    else
                    {
                        requestParameter = new QueryParameters { ["apiKey"] = ConfigDictionary[BaseConstants.LoginRadiusApiKey] };
                        authHeaders = new Dictionary<string, string>
                        {
                            [BaseConstants.AuthorizationHeader] = ConfigDictionary[BaseConstants.LoginRadiusApiSecret]
                        };
                    }
                    break;
                case RequestType.Role:
                    baseEndPoint = BaseConstants.RestRoleApiEndpoint;
                    requestParameter = new QueryParameters { ["apiKey"] = ConfigDictionary[BaseConstants.LoginRadiusApiKey] };
                    authHeaders = new Dictionary<string, string>
                    {
                        [BaseConstants.AuthorizationHeader] = ConfigDictionary[BaseConstants.LoginRadiusApiSecret]
                    };
                    break;
                case RequestType.RestHook:
                    baseEndPoint = BaseConstants.RestHookApiEndpoint;
                    if (ConfigDictionary[BaseConstants.ApiRequestSigning] != null && ConfigDictionary[BaseConstants.ApiRequestSigning] == "true")
                    {
                        _requestChannel = true;
                        requestParameter = new QueryParameters
                        {
                            ["api_key"] = ConfigDictionary[BaseConstants.LoginRadiusApiKey]
                        };
                    }
                    else
                    {
                        requestParameter = new QueryParameters
                        {
                            ["api_key"] = ConfigDictionary[BaseConstants.LoginRadiusApiKey],
                            ["api_secret"] = ConfigDictionary[BaseConstants.LoginRadiusApiSecret]
                        };
                    }
                    break;

                case RequestType.ServerInfo:
                    baseEndPoint = BaseConstants.ServerinfoApiEndpoint;
                    requestParameter = new QueryParameters
                    {
                        ["apikey"] = ConfigDictionary[BaseConstants.LoginRadiusApiKey],
                    };
                    break;
                case RequestType.Webhook:
                    baseEndPoint = BaseConstants.WebhookApiEndpoint;
                    if (ConfigDictionary[BaseConstants.ApiRequestSigning] != null && ConfigDictionary[BaseConstants.ApiRequestSigning] == "true")
                    {
                        _requestChannel = true;
                        requestParameter = new QueryParameters
                        {
                            ["apikey"] = ConfigDictionary[BaseConstants.LoginRadiusApiKey]
                        };
                    }
                    else
                    {
                        requestParameter = new QueryParameters
                        {
                            ["apikey"] = ConfigDictionary[BaseConstants.LoginRadiusApiKey],
                            ["apisecret"] = ConfigDictionary[BaseConstants.LoginRadiusApiSecret]
                        };
                    }
                    break;

                case RequestType.RegistrationData:
                    baseEndPoint = BaseConstants.RegistrationDataApiEndpoint;
                    if (ConfigDictionary[BaseConstants.ApiRequestSigning] != null && ConfigDictionary[BaseConstants.ApiRequestSigning] == "true")
                    {
                        _requestChannel = true;
                        requestParameter = new QueryParameters
                        {
                            ["apikey"] = ConfigDictionary[BaseConstants.LoginRadiusApiKey]
                        };
                    }
                    else
                    {
                        requestParameter = new QueryParameters
                        {
                            ["apikey"] = ConfigDictionary[BaseConstants.LoginRadiusApiKey],
                            ["apisecret"] = ConfigDictionary[BaseConstants.LoginRadiusApiSecret]
                        };
                    }
                    break;

                case RequestType.RegistrationDataAuth:
                    baseEndPoint = BaseConstants.RegistrationDataAuthApiEndpoint;
                    requestParameter = new QueryParameters
                    {
                        ["apikey"] = ConfigDictionary[BaseConstants.LoginRadiusApiKey]
                    };
                    break;

                case RequestType.Configuration:
                    baseEndPoint = BaseConstants.ConfigurationAuthApiEndpoint;
                    requestParameter = new QueryParameters
                    {
                        ["apikey"] = ConfigDictionary[BaseConstants.LoginRadiusApiKey]
                    };
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }

            if (type != RequestType.Configuration)
            {
                baseEndPoint = ConfigDictionary[BaseConstants.DomainName] + baseEndPoint;
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
    }
}