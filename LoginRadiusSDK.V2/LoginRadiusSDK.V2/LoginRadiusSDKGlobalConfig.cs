namespace LoginRadiusSDK.V2
{
    public static class LoginRadiusSdkGlobalConfig
    {
        public static string ProxyAddress { get; set; }
        public static string ProxyCredentials { get; set; }
        public static int ConnectionTimeout { get; set; }
        public static int RequestRetries { get; set; }
        public static string ApiKey { get; set; }
        public static string ApiSecret { get; set; }
        public static string AppName { get; set; }
    }
}