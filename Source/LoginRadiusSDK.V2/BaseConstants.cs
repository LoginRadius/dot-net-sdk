using LoginRadiusSDK.V2.Util;

namespace LoginRadiusSDK.V2
{
    /// <summary>
    /// Constants that are used by the LoginRadius SDK.
    /// </summary>
    public static class BaseConstants
    {

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
        /// Content Type HTTP Header
        /// </summary>
        public const string ContentTypeHeader = "Content-Type";

        /// <summary>
        /// Application - Json Content Type
        /// </summary>
        public const string ContentTypeHeaderJson = "application/json";


        /// <summary>
        /// Parameter validation
        /// </summary>
        public const string ValidationMessage = "The Method Parameter is not Formated or Null";

        /// <summary>
        /// The version of this SDK.
        /// </summary>
        public static string SdkVersion => SDKUtil.GetAssemblyVersionForType(typeof(BaseConstants));

        public static string ASPNETCORE_ENVIRONMENT = "ASPNETCORE_ENVIRONMENT";
        /// <summary>
        /// The name of this SDK.
        /// </summary>
        public const string SdkName = "LoginRadius-NET-SDK";

        public const string BaseRestApiEndpoint = "https://api.loginradius.com/";
        public const string BaseConfigApiEndpoint = "https://config.lrcontent.com/";

    }
}