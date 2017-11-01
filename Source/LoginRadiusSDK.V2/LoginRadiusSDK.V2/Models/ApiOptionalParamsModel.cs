using System.Collections.Generic;

namespace LoginRadiusSDK.V2.Models
{
    public class LoginRadiusApiOptionalParams : Dictionary<string, string>
    {
        /// <summary>
        /// 
        /// </summary>
        public string VerificationUrl { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string EmailTemplate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string SmsTemplate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string LoginUrl { get; set; }

        public string DeleteUrl { get; set; }

        public string SmsTemplate2Fa { get; set; }
        public string ResetPasswordUrl { get; set; }
    }
}