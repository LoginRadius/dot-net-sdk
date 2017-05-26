namespace LoginRadiusSDK.V2
{
    public class LoginRadiusSdkGlobalConfig
    {
        public string ProxyAddress { get; set; }
        public string ProxyCredentials { get; set; }
        public int ConnectionTimeout { get; set; }
        public int RequestRetries { get; set; }
    }
}