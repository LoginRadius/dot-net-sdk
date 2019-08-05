using System.Collections.Generic;
using System.Collections.Concurrent;
#if NetFramework
using System.Configuration;
#endif
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
        private static ConcurrentDictionary<string, string> _configValues;

        private static SDKConfigHandler _sdkConfigHandler = new SDKConfigHandler();

        private static readonly Dictionary<string, string> DefaultConfig;

        /// <summary>
        /// Explicit static constructor to tell C# compiler not to mark type as beforefieldinit
        /// </summary>
        static ConfigManager()
        {
            // Default connection timeout in milliseconds
            DefaultConfig = new Dictionary<string, string>
            {
                [LRConfigConstants.HttpConnectionTimeoutConfig] = "30000",
                [LRConfigConstants.HttpConnectionRetryConfig] = "3"
            };

            try
            {
#if NetFramework
                _sdkConfigHandler = ConfigurationManager.GetSection(LRConfigConstants.ConfigSection) as SDKConfigHandler ?? new SDKConfigHandler();
#else
                _sdkConfigHandler.GetSection();
#endif
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

        internal ConcurrentDictionary<string, string> GetConfiguration()
        {
            _configValues = new ConcurrentDictionary<string, string>();

            var valStr = string.IsNullOrWhiteSpace(LoginRadiusSdkGlobalConfig.ApiKey)
                ? _sdkConfigHandler.Setting(LRConfigConstants.LoginRadiusApiKey)
                : LoginRadiusSdkGlobalConfig.ApiKey;
            _configValues.TryAdd(LRConfigConstants.LoginRadiusApiKey, valStr);

            valStr = string.IsNullOrWhiteSpace(LoginRadiusSdkGlobalConfig.ApiSecret)
                ? _sdkConfigHandler.Setting(LRConfigConstants.LoginRadiusApiSecret)
                : LoginRadiusSdkGlobalConfig.ApiSecret;
            _configValues.TryAdd(LRConfigConstants.LoginRadiusApiSecret, valStr);

            valStr = string.IsNullOrWhiteSpace(LoginRadiusSdkGlobalConfig.ProxyAddress)
                ? _sdkConfigHandler.Setting(LRConfigConstants.HttpProxyAddressConfig)
                : LoginRadiusSdkGlobalConfig.ProxyAddress;
            _configValues.TryAdd(LRConfigConstants.HttpProxyAddressConfig, valStr);


            valStr = string.IsNullOrWhiteSpace(LoginRadiusSdkGlobalConfig.ProxyCredentials)
                ? _sdkConfigHandler.Setting(LRConfigConstants.HttpProxyCredentialConfig)
                : LoginRadiusSdkGlobalConfig.ProxyCredentials;
            _configValues.TryAdd(LRConfigConstants.HttpProxyCredentialConfig, valStr);

            valStr = LoginRadiusSdkGlobalConfig.ConnectionTimeout <= 0
                ? _sdkConfigHandler.Setting(LRConfigConstants.HttpConnectionTimeoutConfig)
                : LoginRadiusSdkGlobalConfig.ConnectionTimeout.ToString();
            _configValues.TryAdd(LRConfigConstants.HttpConnectionTimeoutConfig, valStr);

            valStr = LoginRadiusSdkGlobalConfig.RequestRetries <= 0
                ? _sdkConfigHandler.Setting(LRConfigConstants.HttpConnectionRetryConfig)
                : LoginRadiusSdkGlobalConfig.RequestRetries.ToString();
            _configValues.TryAdd(LRConfigConstants.HttpConnectionRetryConfig, valStr);

            valStr = string.IsNullOrWhiteSpace(LoginRadiusSdkGlobalConfig.AppName)
                ? _sdkConfigHandler.Setting(LRConfigConstants.LoginRadiusAppName)
                : LoginRadiusSdkGlobalConfig.AppName;
            _configValues.TryAdd(LRConfigConstants.LoginRadiusAppName, valStr);

            valStr = string.IsNullOrWhiteSpace(LoginRadiusSdkGlobalConfig.ApiRequestSigning)
               ? _sdkConfigHandler.Setting(LRConfigConstants.ApiRequestSigning)
               : LoginRadiusSdkGlobalConfig.ApiRequestSigning;
            _configValues.TryAdd(LRConfigConstants.ApiRequestSigning, valStr);

            valStr = string.IsNullOrWhiteSpace(LoginRadiusSdkGlobalConfig.DomainName)
               ? _sdkConfigHandler.Setting(LRConfigConstants.DomainName)
               :LoginRadiusSdkGlobalConfig.DomainName;
            _configValues.TryAdd(LRConfigConstants.DomainName, valStr);

            valStr = string.IsNullOrWhiteSpace(LoginRadiusSdkGlobalConfig.ApiRegion)
               ? _sdkConfigHandler.Setting(LRConfigConstants.ApiRegion)
               : LoginRadiusSdkGlobalConfig.ApiRegion;
            _configValues.TryAdd(LRConfigConstants.ApiRegion, valStr);

            return _configValues;
        }
    }
}