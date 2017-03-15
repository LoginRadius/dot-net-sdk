using System.Configuration;
using LoginRadiusSDK.Utility.Http;

namespace LoginRadiusSDK.Entity
{
    /// <summary>
    /// LoginRadius entity class that is used as common entity to methods, it describes for the hhtp method, headers which is used in the GET and POST methods.
    /// The Hypertext Transfer Protocol (HTTP) is designed to enable communications between clients and servers.
    /// </summary>
    public abstract class LoginRadiusServerEntity : LoginRadiusEntity
    {
        /// <summary>
        /// LoginRadius Api and Secret key. 
        /// </summary>
        protected LoginRadiusServerEntity()
            : this(ConfigurationManager.AppSettings["loginradius:apikey"],
                ConfigurationManager.AppSettings["loginradius:apisecret"])
        {
        }

        protected LoginRadiusServerEntity(string apikey, string apisecret)
        {
            _commHttpRequestParameter = new HttpRequestParameter()
            {
                {"appkey", apikey},
                {"appsecret", apisecret}
            };
        }

        protected override string GetEndpoint(string api)
        {
            return $"https://api.loginradius.com/raas/v1/{api}";
        }
    }
}
