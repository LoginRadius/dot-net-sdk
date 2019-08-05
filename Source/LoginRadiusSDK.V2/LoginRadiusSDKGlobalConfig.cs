using LoginRadiusSDK.V2.Common;

namespace LoginRadiusSDK.V2
{
    public static class LoginRadiusSdkGlobalConfig
    {
        public static string ProxyAddress { get; set; }
        public static string ProxyCredentials { get; set; }
        public static int ConnectionTimeout { get; set; }
        public static int RequestRetries { get; set; }
        public static string ApiRegion { get; set; }

        private static string _apiKey;

        public static string ApiKey
        {
            get
            {

                return string.IsNullOrWhiteSpace(_apiKey) && LoginRadiusResource.ConfigDictionary != null
                    ? LoginRadiusResource.ConfigDictionary[LRConfigConstants.LoginRadiusApiKey]
                    : _apiKey;
            }
            set { _apiKey = value; }
        }

        public static string ApiSecret { get; set; }
        public static string ApiRequestSigning { get; set; }

        private static string _appName;

        public static string AppName
        {
            get
            {
                return string.IsNullOrWhiteSpace(_appName) && LoginRadiusResource.ConfigDictionary != null
                    ? LoginRadiusResource.ConfigDictionary[LRConfigConstants.LoginRadiusAppName]
                    : _appName;
            }
            set { _appName = value; }
        }

        private static string _domainName;

        public static string DomainName
        {
            get
            {
                return string.IsNullOrWhiteSpace(_domainName) && LoginRadiusResource.ConfigDictionary != null
                    ? LoginRadiusResource.ConfigDictionary[LRConfigConstants.DomainName]
                    : _domainName;
            }
            set { _domainName = value; }
        }
    }
}