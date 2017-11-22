using System.Collections.Generic;

namespace LoginRadiusSDK.V2.Models
{
    /// <summary>
    /// Provider getter and setter for common proprties for LoginRadius API calls.
    /// </summary>
    public class LoginRadiusApiOptionalParams : Dictionary<string, string>
    {
        /// <summary>
        /// Gets or sets verification URL property for LoginRadius API call.
        /// Default settings are automatically used by API i.e. empty string,
        /// </summary>
        public string VerificationUrl { get; set; }

        /// <summary>
        /// Gets or sets Email Template property for LoginRadius API call.
        /// Default settings are automatically used by API i.e. empty string,
        /// </summary>
        public string EmailTemplate { get; set; }

        /// <summary>
        /// Gets or sets SMS Template property for LoginRadius API call.
        /// Default settings are automatically used by API i.e. empty string,
        /// </summary>
        public string SmsTemplate { get; set; }

        /// <summary>
        /// Gets or sets Login URL property for LoginRadius API call.
        /// Default settings are automatically used by API i.e. empty string.
        /// </summary>
        public string LoginUrl { get; set; }

        /// <summary>
        /// Gets or sets Delete URL property for LoginRadius API call.
        /// Default settings are automatically used by API i.e. empty string.
        /// URL of the site where logic of confirm deletion is handled. 
        /// </summary>
        public string DeleteUrl { get; set; }

        /// <summary>
        /// Gets or sets 2FA SMS Template property for LoginRadius API call.
        /// Default settings are automatically used by API i.e. empty string.
        /// </summary>
        public string SmsTemplate2Fa { get; set; }

        /// <summary>
        /// Gets or sets Reset Password URL property for LoginRadius API call.
        /// Default settings are automatically used by API i.e. empty string.
        /// </summary>
        public string ResetPasswordUrl { get; set; }
    }
}