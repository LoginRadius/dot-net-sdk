using System.Configuration;

namespace LoginRadiusSDK.V2
{
    /// <summary>
    /// Custom handler for SDK configuration section as defined in App.Config or Web.Config files
    /// </summary>
    public class SDKConfigHandler : ConfigurationSection
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
}
