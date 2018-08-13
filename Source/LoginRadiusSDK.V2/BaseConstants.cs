using LoginRadiusSDK.V2.Util;

namespace LoginRadiusSDK.V2
{
    /// <summary>
    /// Constants that are used by the LoginRadius SDK.
    /// </summary>
    public static class BaseConstants
    {
        /// <summary>
        /// Configuration key for HTTP Proxy Address
        /// </summary>
        public const string HttpProxyAddressConfig = "proxyAddress";

        /// <summary>
        /// Configuration key for HTTP Proxy Credential
        /// </summary>
        public const string HttpProxyCredentialConfig = "proxyCredentials";

        /// <summary>
        /// Configuration key for HTTP Connection Timeout
        /// </summary>
        public const string HttpConnectionTimeoutConfig = "connectionTimeout";

        /// <summary>
        /// Configuration key for HTTP Connection Retry
        /// </summary>
        public const string HttpConnectionRetryConfig = "requestRetries";

        /// <summary>
        /// Configuration LoginRadius API Key
        /// </summary>
        public const string LoginRadiusApiKey = "apiKey";

        /// <summary>
        /// Configuration LoginRadius APP Name
        /// </summary>
        public const string LoginRadiusAppName = "appName";

        /// <summary>
        /// Configuration LoginRadius API Secret
        /// </summary>
        public const string LoginRadiusApiSecret = "apiSecret";

        /// <summary>
        /// Configuration LoginRadius API Secret Header Key
        /// </summary>
        public const string AuthorizationHeader = "X-LoginRadius-ApiSecret";

        /// <summary>
        /// Configuration LoginRadius API SOTT Header Key
        /// </summary>
        public const string SottAuthorizationHeader = "X-LoginRadius-Sott";

        /// <summary>
        /// Configuration LoginRadius API AccessToken Header Key
        /// </summary>
        public const string AccessTokenAuthorizationHeader = "Authorization";

        /// <summary>
        /// Configuration LoginRadius API AccessToken Header Bearer Key
        /// </summary>
        public const string AccessTokenBearerHeader = "Bearer ";

        /// <summary>
        /// Configuration LoginRadius ApiRequestSigning Key
        /// </summary>
        public const string ApiRequestSigning = "ApiRequestSigning";

        /// <summary>
        /// Configuration Section Identifier 
        /// </summary>
        public const string ConfigSection = "loginradius";

        /// <summary>
        /// Content Type HTTP Header
        /// </summary>
        public const string ContentTypeHeader = "Content-Type";

        /// <summary>
        /// Application - Json Content Type
        /// </summary>
        public const string ContentTypeHeaderJson = "application/json";

        /// <summary>
        /// The version of this SDK.
        /// </summary>
        public static string SdkVersion => SDKUtil.GetAssemblyVersionForType(typeof(BaseConstants));

        /// <summary>
        /// The name of this SDK.
        /// </summary>
        public const string SdkName = "LoginRadius-NET-SDK";

        private const string BaseRestApiEndpoint = "https://api.loginradius.com/";
        private const string BaseConfigApiEndpoint = "https://config.lrcontent.com/";
        public const string RestAuthApiEndpoint = BaseRestApiEndpoint + "identity/v2/auth/";
        public const string RestIdentityApiEndpoint = BaseRestApiEndpoint + "identity/v2/manage/account/";
        public const string RestRoleApiEndpoint = BaseRestApiEndpoint + "identity/v2/manage/";
        public const string RestApiEndpoint = BaseRestApiEndpoint + "api/v2/";
        public const string RestHookApiEndpoint = BaseRestApiEndpoint + "api/v2/resthook/";
        public const string RestShareApiEndpoint = BaseRestApiEndpoint + "sharing/v1/shorturl/";
        public const string ServerinfoApiEndpoint = BaseRestApiEndpoint + "identity/v2/serverinfo";
        public const string WebhokApiEndpoint = BaseRestApiEndpoint + "api/v2/webhook";
        public const string RegistrationDataApiEndpoint = BaseRestApiEndpoint + "identity/v2/manage/registrationdata";
        public const string RegistrationDataAuthApiEndpoint = BaseRestApiEndpoint + "identity/v2/auth/registrationdata";
        public const string ConfigurationAuthApiEndpoint = BaseConfigApiEndpoint + "ciam/appinfo";
    }
}