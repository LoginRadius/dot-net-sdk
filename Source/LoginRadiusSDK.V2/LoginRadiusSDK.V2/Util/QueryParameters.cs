using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using LoginRadiusSDK.V2.Models;
using LoginRadiusSDK.V2.Util.Serialization;

namespace LoginRadiusSDK.V2.Util
{
    /// <summary>
    /// Helper class that can be converted into a URL query string.
    /// </summary>
    public class QueryParameters : Dictionary<string, string>
    {
        /// <summary>
        /// Converts the dictionary of query parameters to a URL-formatted string. Empty values are ommitted from the parameter list.
        /// </summary>
        /// <returns>A URL-formatted string containing the query parameters</returns>
        public string ToUrlFormattedString()
        {
            return this.Aggregate
            (
                "",
                (parameters, item) =>
                    parameters +
                    (string.IsNullOrEmpty(item.Value)
                        ? ""
                        : (string.IsNullOrEmpty(parameters) ? "?" : "&") +
                          $"{item.Key}={HttpUtility.UrlEncode(item.Value)}")
            );
        }

        public void AddRange<T>(ICollection<T> target, IEnumerable<T> source)
        {
            if (target == null)
                throw new ArgumentNullException("target");
            if (source == null)
                throw new ArgumentNullException("source");
            foreach (var element in source)
                target.Add(element);
        }

        public void AddOptionalParamsRange(LoginRadiusApiOptionalParams source)
        {
            if (!string.IsNullOrWhiteSpace(source.SmsTemplate)) Add("SmsTemplate", source.SmsTemplate);
            if (!string.IsNullOrWhiteSpace(source.DeleteUrl)) Add("DeleteUrl", source.DeleteUrl);
            if (!string.IsNullOrWhiteSpace(source.EmailTemplate)) Add("EmailTemplate", source.EmailTemplate);
            if (!string.IsNullOrWhiteSpace(source.LoginUrl)) Add("LoginUrl", source.LoginUrl);
            if (!string.IsNullOrWhiteSpace(source.SmsTemplate2Fa)) Add("LoginUrl", source.SmsTemplate2Fa);
            if (!string.IsNullOrWhiteSpace(source.VerificationUrl)) Add("VerificationUrl", source.VerificationUrl);
        }

        public void AddOptionalParamsRange(TwoFactorAuthModel source)
        {
            if (!string.IsNullOrWhiteSpace(source.GoogleAuthenticatorCode))
                Add("GoogleAuthenticatorCode", source.GoogleAuthenticatorCode);
            if (!string.IsNullOrWhiteSpace(source.Otp)) Add("Otp", source.Otp);
        }

        public void AddOptionalParamsRange(TwoFactorPhoneAuthModel source)
        {
            if (!string.IsNullOrWhiteSpace(source.PhoneNo2Fa)) Add("PhoneNo2Fa", source.PhoneNo2Fa);
        }
    }

    public class BodyParameters : Dictionary<string, string>
    {
        /// <summary>
        /// Converts this object to a JSON string.
        /// </summary>
        /// <returns>A JSON-formatted string.</returns>
        public string ConvertToJson()
        {
            return JsonFormatter.ConvertToJson(this);
        }


        public Dictionary<string, string> ToDictionary()
        {
            return GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .ToDictionary(prop => prop.Name, prop => prop.GetValue(this, null).ToString());
        }
    }
}