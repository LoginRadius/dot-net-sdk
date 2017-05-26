using System.Collections.Generic;

namespace LoginRadiusSDK.V2.Manager
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
    }
}