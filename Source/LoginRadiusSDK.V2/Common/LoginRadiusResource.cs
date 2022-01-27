using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LoginRadiusSDK.V2.Exception;
using LoginRadiusSDK.V2.Http;
using LoginRadiusSDK.V2.Util;
using LoginRadiusSDK.V2.Util.Serialization;
using Newtonsoft.Json;

namespace LoginRadiusSDK.V2.Common
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

      

        /// <summary>
        /// Gets the last request sent by the SDK in the current thread.
        /// </summary>
        public static ThreadLocal<RequestDetails> LastRequestDetails { get; private set; }

        /// <summary>
        /// Gets the last response received by the SDK in the current thread.
        /// </summary>
        public static ThreadLocal<ResponseDetails> LastResponseDetails { get; private set; }

       

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
        public async Task<object> ConfigureAndExecute(HttpMethod httpMethod, string resource,
            QueryParameters queryParameters, string payload = "")
        {
            return await ConfigureAndExecute<object>(httpMethod, resource, queryParameters, payload);
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
        protected async Task<ApiResponse<T>> ConfigureAndExecute<T>(HttpMethod httpMethod, string resource)
        {
            return await ConfigureAndExecute<T>(httpMethod, resource, null, null);
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
        protected async Task<ApiResponse<T>> ConfigureAndExecute<T>(HttpMethod httpMethod,string resource,string payload)
        {
            return await ConfigureAndExecute<T>(httpMethod, resource, null, payload);
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
        protected async Task<ApiResponse<T>> ConfigureAndExecute<T>(HttpMethod httpMethod,string resource = "" ,
            QueryParameters queryParameters = null, string payload = "", Dictionary<string, string> headers = null)
        {
            try
            {
                // Create the URI where the HTTP request will be sent.
                Uri uniformResourceIdentifier;
                var apiPath = resource;
                var endPoint = GetEndpoint(apiPath,out Dictionary<string, string> authHeaders, queryParameters);
                if (headers == null)
                {
                    headers = new Dictionary<string, string>();
                }
             
                if (ConfigDictionary[LRConfigConstants.ApiRequestSigning] != null && ConfigDictionary[LRConfigConstants.ApiRequestSigning] == "true" && authHeaders!=null && authHeaders.Count>0)
                {
                    var time = DateTime.UtcNow.AddMinutes(15).ToString("yyyy-M-d h:m:s tt");
                    var hash = CreateHash(ConfigDictionary[LRConfigConstants.LoginRadiusApiSecret], endPoint, httpMethod.ToString(), time, payload);
                    authHeaders.Remove("apiSecret");
                    headers.Add("digest", "SHA-256=" + hash);
                    headers.Add("X-Request-Expires", time);
                }
                if (ConfigDictionary.ContainsKey(LRConfigConstants.OriginIp) && !string.IsNullOrWhiteSpace(ConfigDictionary[LRConfigConstants.OriginIp]))
                {
                    headers.Add("X-Origin-IP",  ConfigDictionary[LRConfigConstants.OriginIp]);

                }

                var baseUri = new Uri(endPoint);
                if (apiPath != null)
                {
                    var resourceUri = baseUri;
                    if (!Uri.TryCreate(resourceUri, apiPath, out uniformResourceIdentifier))
                    {
                        throw new LoginRadiusException("Cannot create URL; baseURI=" + baseUri + ", resourcePath=" +
                                                       apiPath);
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

                var response = await connectionHttp.Execute(payload, httpRequest, payload.Length);
                if (response.Contains("errorCode"))
                {
                    var exception = new ApiResponse<T>
                    {
                        RestException = JsonConvert.DeserializeObject<ApiExceptionResponse>(response)
                    };
                    return exception;
                }
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

                    var exception = new ApiResponse<T>
                    {
                        RestException = JsonConvert.DeserializeObject<ApiExceptionResponse>(ex.Response)
                    };
                    return exception;
                }
                catch
                {
                    return new ApiResponse<T> { OtherException = ex.Response };
                }
            }
            catch (LoginRadiusException e)
            {
                // Response will be either in Json String or or only having string value 
                if (!string.IsNullOrEmpty(e.Response) && JsonFormatter.ValidateJSON(e.Response))
                {
                    return new ApiResponse<T> { RestException = e.ErrorResponse };
                }
                else
                {
                    return new ApiResponse<T> { OtherException = e.Response };
                }
            }
            catch (System.Exception ex)
            {
                throw new LoginRadiusException(ex.Message, ex);
            }
        }

        private static string GetEndpoint(string apiPath, out Dictionary<string, string> authHeaders, QueryParameters additionalParameters = null)
        {
           
            string baseEndPoint;
            authHeaders = null;
            if (ConfigDictionary.ContainsKey(LRConfigConstants.ApiRegion) && !string.IsNullOrWhiteSpace(ConfigDictionary[LRConfigConstants.ApiRegion])) {
                additionalParameters.Add("region", ConfigDictionary[LRConfigConstants.ApiRegion]);
            }
            if (apiPath.Contains("identity/v2") && additionalParameters.ContainsKey("apiSecret")){
                additionalParameters.Remove("apiSecret");
                authHeaders = new Dictionary<string, string>
                {
                    [BaseConstants.AuthorizationHeader] = ConfigDictionary[LRConfigConstants.LoginRadiusApiSecret]
                };
            }else if (apiPath.Contains("/auth") && additionalParameters.ContainsKey("access_token")){
                authHeaders = new Dictionary<string, string>
                {
                    [BaseConstants.AccessTokenAuthorizationHeader] = BaseConstants.AccessTokenBearerHeader +additionalParameters["access_token"]
                };
                    additionalParameters.Remove("access_token");

            }else if (apiPath.Contains("identity/v2/auth/register") && additionalParameters.ContainsKey("sott")){
                authHeaders = new Dictionary<string, string>{
                    [BaseConstants.SottAuthorizationHeader] = additionalParameters["sott"]
                };
                additionalParameters.Remove("sott");

            }

            if (apiPath.Contains("ciam/appinfo"))
            {
                baseEndPoint = BaseConstants.BaseConfigApiEndpoint;
            }else
            {
                baseEndPoint = string.IsNullOrWhiteSpace(ConfigDictionary[LRConfigConstants.DomainName])
               ? BaseConstants.BaseRestApiEndpoint : ConfigDictionary[LRConfigConstants.DomainName];

            }

            return string.IsNullOrWhiteSpace(apiPath)
                ? $"{baseEndPoint}{additionalParameters.ToUrlFormattedString()}": $"{baseEndPoint}{apiPath}{additionalParameters.ToUrlFormattedString()}";
        }
    }
}