using LoginRadiusSDK.Utility.Http;

namespace LoginRadiusSDK.Entity
{
    public abstract class LoginRadiusV2EntityBase:LoginRadiusEntity
    {
        /// <summary>
        /// LoginRadius Api and Secret key. 
        /// </summary>
        protected LoginRadiusV2EntityBase()
            : this( AppCredentials.AppKey,
                AppCredentials.AppSecret)
        {
        }

        protected LoginRadiusV2EntityBase(string apikey, string apisecret)
        {
            CommHttpRequestParameter = new HttpRequestParameter()
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
