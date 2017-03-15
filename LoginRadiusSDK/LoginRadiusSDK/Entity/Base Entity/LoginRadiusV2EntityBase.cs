using System.Configuration;
using LoginRadiusSDK.Utility.Http;

namespace LoginRadiusSDK.Entity
{
    public abstract class LoginRadiusV2EntityBase:LoginRadiusEntity
    {
        /// <summary>
        /// LoginRadius Api and Secret key. 
        /// </summary>
        protected LoginRadiusV2EntityBase()
            : this(ConfigurationManager.AppSettings["loginradius:apikey"],
                ConfigurationManager.AppSettings["loginradius:apisecret"])
        {
        }

        protected LoginRadiusV2EntityBase(string apikey, string apisecret)
        {
            _commHttpRequestParameter = new HttpRequestParameter()
            {
                {"key", apikey},
                {"secret", apisecret}
            };
        }

        protected override string GetEndpoint(string api)
        {
            return $"https://api.loginradius.com/api/v2/{api}";
        }
    }
}
