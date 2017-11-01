using System.Collections.Generic;
using System.Configuration;
using LoginRadiusSDK.V2.Exception;

namespace LoginRadiusSDK.V2
{
    /// <summary>
    /// ConfigManager loads the configuration file and hands out appropriate parameters to application
    /// </summary>
    public sealed class ConfigManager
    {
        /// <summary>
        /// The configValue is readonly as it should not be changed outside constructor (but the content can)
        /// </summary>
        private readonly Dictionary<string, string> _configValues;

        static SDKConfigHandler _sdkConfigHandler = new SDKConfigHandler();

        private static readonly Dictionary<string, string> DefaultConfig;

        /// <summary>
        /// Explicit static constructor to tell C# compiler not to mark type as beforefieldinit
        /// </summary>
        static ConfigManager()
        {
            // Default connection timeout in milliseconds
            DefaultConfig = new Dictionary<string, string>
            {
                [BaseConstants.HttpConnectionTimeoutConfig] = "30000",
                [BaseConstants.HttpConnectionRetryConfig] = "3"
            };

            try
            {
                _sdkConfigHandler = ConfigurationManager.GetSection("loginradius") as SDKConfigHandler;
            }
            catch (System.Exception ex)
            {
                throw new ConfigException("Unable to load 'loginradius' section from *.config: " + ex.Message);
            }
        }

        /// <summary>
        /// Singleton instance of the ConfigManager
        /// </summary>
        private static volatile ConfigManager _singletonInstance;

        private static readonly object SyncRoot = new object();


        /// <summary>
        /// Gets the Singleton instance of the ConfigManager
        /// </summary>
        public static ConfigManager Instance
        {
            get
            {
                if (_singletonInstance == null)
                {
                    lock (SyncRoot)
                    {
                        if (_singletonInstance == null)
                            _singletonInstance = new ConfigManager();
                    }
                }
                return _singletonInstance;
            }
        }

        /// <summary>
        /// Returns all properties from the config file
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> GetProperties()
        {
            // returns a copy of the configuration properties
            return new Dictionary<string, string>(_configValues);
        }

        /// <summary>
        /// Creates new configuration that combines incoming configuration dictionary
        /// and defaults
        /// </summary>
        /// <returns>Default configuration dictionary</returns>
        public static Dictionary<string, string> GetConfigWithDefaults(Dictionary<string, string> config)
        {
            var ret = config == null ? new Dictionary<string, string>() : new Dictionary<string, string>(config);

            foreach (string key in DefaultConfig.Keys)
            {
                if (!ret.ContainsKey(key))
                {
                    ret.Add(key, DefaultConfig[key]);
                }
            }
            return ret;
        }

        /// <summary>
        /// Gets the default configuration value for the specified key.
        /// </summary>
        /// <param name="configKey">The key to lookup in the default configuration.</param>
        /// <returns>A string containing the default configuration value for the specified key. If the key is not found, returns null.</returns>
        public static string GetDefault(string configKey)
        {
            return DefaultConfig.ContainsKey(configKey) ? DefaultConfig[configKey] : null;
        }

        internal static Dictionary<string, string> GetConfiguration()
        {
            var configDic = new Dictionary<string, string>();

            var valStr = string.IsNullOrWhiteSpace(LoginRadiusSdkGlobalConfig.ApiKey)
                ? _sdkConfigHandler.Setting(BaseConstants.LoginRadiusApiKey)
                : LoginRadiusSdkGlobalConfig.ApiKey;
            configDic.Add(BaseConstants.LoginRadiusApiKey, valStr);

            valStr = string.IsNullOrWhiteSpace(LoginRadiusSdkGlobalConfig.ApiSecret)
                ? _sdkConfigHandler.Setting(BaseConstants.LoginRadiusApiSecret)
                : LoginRadiusSdkGlobalConfig.ApiSecret;
            configDic.Add(BaseConstants.LoginRadiusApiSecret, valStr);

            valStr = string.IsNullOrWhiteSpace(LoginRadiusSdkGlobalConfig.ProxyAddress)
                ? _sdkConfigHandler.Setting(BaseConstants.HttpProxyAddressConfig)
                : LoginRadiusSdkGlobalConfig.ProxyAddress;
            configDic.Add(BaseConstants.HttpProxyAddressConfig, valStr);


            valStr = string.IsNullOrWhiteSpace(LoginRadiusSdkGlobalConfig.ProxyCredentials)
                ? _sdkConfigHandler.Setting(BaseConstants.HttpProxyCredentialConfig)
                : LoginRadiusSdkGlobalConfig.ProxyCredentials;
            configDic.Add(BaseConstants.HttpProxyCredentialConfig, valStr);

            valStr = LoginRadiusSdkGlobalConfig.ConnectionTimeout <= 0
                ? _sdkConfigHandler.Setting(BaseConstants.HttpProxyCredentialConfig)
                : LoginRadiusSdkGlobalConfig.ConnectionTimeout.ToString();
            configDic.Add(BaseConstants.HttpConnectionTimeoutConfig, valStr);

            valStr = LoginRadiusSdkGlobalConfig.RequestRetries <= 0
                ? _sdkConfigHandler.Setting(BaseConstants.HttpConnectionRetryConfig)
                : LoginRadiusSdkGlobalConfig.RequestRetries.ToString();
            configDic.Add(BaseConstants.HttpConnectionRetryConfig, valStr);

            valStr = string.IsNullOrWhiteSpace(LoginRadiusSdkGlobalConfig.AppName)
                ? _sdkConfigHandler.Setting(BaseConstants.LoginRadiusAppName)
                : LoginRadiusSdkGlobalConfig.AppName;
            configDic.Add(BaseConstants.LoginRadiusAppName, valStr);

            return configDic;
        }
    }
}