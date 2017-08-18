using System.Web.Configuration;

namespace LoginRadiusSDK.Entity
{
    public static class AppCredentials
    {
        private static string _appKey;
        private static string _appSecret;
        private static string _appName;
        private static string _httpProxyAddress;
        private static string _httpProxyCredential;

        public static void AppSettingInitialization(string appKey, string appSecret, string appName)
        {
            _appKey = appKey;
            _appSecret = appSecret;
            _appName = appName;
        }

        public static void AppSettingInitialization(string appKey, string appSecret, string appName,
            string httpProxyAddress, string httpProxyCredential)
        {
            _appKey = appKey;
            _appSecret = appSecret;
            _appName = appName;
            _httpProxyAddress = httpProxyAddress;
            _httpProxyCredential = httpProxyCredential;
        }


        public static string AppKey
        {
            get
            {
                if (string.IsNullOrEmpty(_appKey))
                {
                    _appKey = WebConfigurationManager.AppSettings["loginradius:apikey"];
                    if (string.IsNullOrEmpty(_appKey))
                    {
                        throw new System.Exception("appkey not found");
                    }
                }
                return _appKey;
            }
            set { _appKey = value; }
        }

        public static string AppSecret
        {
            get
            {
                if (string.IsNullOrEmpty(_appSecret))
                {
                    _appSecret = WebConfigurationManager.AppSettings["loginradius:apisecret"];

                    if (string.IsNullOrEmpty(_appSecret))
                    {
                        throw new System.Exception("appsecret not found");
                    }
                }
                return _appSecret;
            }

            set { _appSecret = value; }
        }

        public static string AppName
        {
            get
            {
                if (string.IsNullOrEmpty(_appName))
                {
                    _appName = WebConfigurationManager.AppSettings["loginradius:appname"];
                    if (string.IsNullOrEmpty(_appName))
                    {
                        throw new System.Exception("appname not found");
                    }
                }
                return _appName;
            }

            set { _appName = value; }
        }

        public static string HttpProxyAddress
        {
            get
            {
                if (string.IsNullOrEmpty(_httpProxyAddress))
                {
                    _httpProxyAddress = WebConfigurationManager.AppSettings["loginradius:httpProxyAddress"];
                }
                return _httpProxyAddress;
            }

            set { _httpProxyAddress = value; }
        }

        public static string HttpProxyCredential
        {
            get
            {
                if (string.IsNullOrEmpty(_httpProxyCredential))
                {
                    _httpProxyCredential = WebConfigurationManager.AppSettings["loginradius:httpProxyCredential"];
                }
                return _httpProxyCredential;
            }

            set { _httpProxyCredential = value; }
        }
    }
}