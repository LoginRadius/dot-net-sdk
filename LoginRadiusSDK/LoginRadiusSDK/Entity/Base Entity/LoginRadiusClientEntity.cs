using LoginRadiusSDK.Utility.Http;

namespace LoginRadiusSDK.Entity
{
    /// <summary>
    /// LoginRadius entity class that is used as common entity to methods, it describes for the hhtp method, headers which is used in the GET and POST methods.
    /// The Hypertext Transfer Protocol (HTTP) is designed to enable communications between clients and servers.
    /// </summary>
    public abstract class LoginRadiusClientEntity : LoginRadiusEntity
    {
        /// <summary>
        /// LoginRadius Api. 
        /// </summary>
        protected LoginRadiusClientEntity()
            : this(AppCredentials.AppKey )
        {
        }

        protected LoginRadiusClientEntity(string apikey)
        {
            CommHttpRequestParameter = new HttpRequestParameter()
            {
                {"apikey", apikey}
            };
        }

        protected override string GetEndpoint(string api)
        {
            return $"https://api.loginradius.com/raas/client/{api}";
        }
    }
}
