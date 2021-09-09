#if NetFramework
using System.Configuration;
#endif
#if NETSTANDARD
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Configuration;
#endif

namespace LoginRadiusSDK.V2
{
#if NetFramework
    /// <summary>
    /// Custom handler for SDK configuration section as defined in App.Config or Web.Config files
    /// </summary>
    public class SDKConfigHandler : ConfigurationSection, ISDKConfigHandler
    {

        /// <summary>
        /// Explicit default constructor
        /// </summary>
        public SDKConfigHandler() { }

        /// <summary>
        /// LoginRadius application settings.
        /// </summary>
        [ConfigurationProperty("settings", IsRequired = true)]
        public NameValueConfigurationCollection Settings
        {
            get { return (NameValueConfigurationCollection)this["settings"]; }
        }

        public void GetSection()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Gets the setting with the specified name. If the setting is not found, returns null.
        /// </summary>
        /// <param name="name">The name of the setting to lookup.</param>
        /// <returns>The value associated with the setting name. If the name is not found, returns null.</returns>
        public string Setting(string name)
        {
            NameValueConfigurationElement config = Settings[name];
            return ((config == null) ? null : config.Value);
        }
    }
#endif
#if NETSTANDARD
    public class SDKConfigHandler : ISDKConfigHandler
    {
        private static IConfigurationRoot Configuration { get; set; }
        private Dictionary<string, string> _loginRadiusSettings;

        public SDKConfigHandler()
        {

            var environment = Environment.GetEnvironmentVariable(BaseConstants.ASPNETCORE_ENVIRONMENT);
            if (environment != "" && environment != null)
            {
                var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true)
               .AddEnvironmentVariables();

                Configuration = builder.Build();
            }
            else
            {

                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddEnvironmentVariables();

                Configuration = builder.Build();
            }

        }

        public void GetSection()
        {
            _loginRadiusSettings = new Dictionary<string, string>();
            Configuration.GetSection(LRConfigConstants.ConfigSection).Bind(_loginRadiusSettings);
        }

        public string Setting(string name)
        {
            return _loginRadiusSettings.TryGetValue(name, out string value) ? value : null;
        }
    }
#endif 
    internal interface ISDKConfigHandler
    {
        void GetSection();
        string Setting(string name);
    }
}