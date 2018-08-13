using LoginRadiusSDK.V2.Api;

namespace LoginRadiusSDK.V2
{
    public static class LoginRadiusSdkGlobalConfig
    {
        public static string ProxyAddress { get; set; }
        public static string ProxyCredentials { get; set; }
        public static int ConnectionTimeout { get; set; }
        public static int RequestRetries { get; set; }

        private static string _apiKey;

        public static string ApiKey
        {
            get
            {

                return string.IsNullOrWhiteSpace(_apiKey) && LoginRadiusResource.ConfigDictionary != null
                    ? LoginRadiusResource.ConfigDictionary[BaseConstants.LoginRadiusApiKey]
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
                    ? LoginRadiusResource.ConfigDictionary[BaseConstants.LoginRadiusAppName]
                    : _appName;
            }
            set { _appName = value; }
        }
    }
}