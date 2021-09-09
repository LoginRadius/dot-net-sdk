using System;
using System.Collections.Generic;
using System.Text;
#if !NETSTANDARD1_3
using System.Web;
#endif
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
            var result = new StringBuilder();
            foreach (KeyValuePair<string, string> pair in this)
            {
                if (!string.IsNullOrEmpty(pair.Value))
                {
                    result.Append(result.Length == 0 ? "?" : "&");
#if NETSTANDARD1_3
                    result.Append($"{pair.Key}={System.Net.WebUtility.UrlEncode(pair.Value)}");
#else
                    result.Append($"{pair.Key}={HttpUtility.UrlEncode(pair.Value)}");
#endif
                }
            }
            return result.ToString();
        }

        public void AddRange<T>(ICollection<T> target, IEnumerable<T> source)
        {
            if (target == null)
                throw new ArgumentNullException(nameof(target));
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            foreach (var element in source)
                target.Add(element);
        }




        public void TryAdd(string key, string value)
        {
            if (!string.IsNullOrWhiteSpace(key)) Add(key, value);
        }
    }

    public class BodyParameters : Dictionary<string, object>
    {
        /// <summary>
        /// Converts this object to a JSON string.
        /// </summary>
        /// <returns>A JSON-formatted string.</returns>
        public string ConvertToJson()
        {
            return JsonFormatter.ConvertToJson(this);
        }
    }
}