using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
#if !NETSTANDARD1_3
using System.Web;
#endif

using LoginRadiusSDK.V2.Exception;
using Microsoft.Win32;

namespace LoginRadiusSDK.V2.Util
{
    /// <summary>
    /// Helper methods for this SDK.
    /// </summary>
    internal class SDKUtil
    {
        /// <summary>
        /// Formats the URI path for REST calls.
        /// </summary>
        /// <param name="pattern">URI path with placeholders that can be replaced with string's Format method</param>
        /// <param name="parameters">Parameters holding actual values for placeholders; They can be wrapper objects for specific query strings like QueryParameters, CreateFromAuthorizationCodeParameters, CreateFromRefreshTokenParameters, UserinfoParameters parameters or a simple Dictionary</param>
        /// <returns>Processed URI path, or null if pattern or parameters is null</returns>
        public static string FormatURIPath(string pattern, object[] parameters)
        {
            string formatString = pattern;
            if (pattern != null && parameters != null)
            {
                //Perform a simple message formatting
                formatString = string.Format(pattern, parameters);

                //Process the resultant string for removing nulls
                formatString = RemoveNullsFromQueryString(formatString);
            }
            return formatString;
        }

        /// <summary>
        /// Overload to above method to support LoginRadius path object class.
        /// </summary>
        /// <param name="pattern"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        

        /// <summary>
        /// Formats the URI path for REST calls. Replaces any occurrences of the form
        /// {name} in pattern with the corresponding value of key name in the passed
        /// Dictionary
        /// </summary>
        /// <param name="pattern">URI pattern with named place holders</param>
        /// <param name="pathParameters">Dictionary</param>
        /// <returns>Processed URI path</returns>
        public static string FormatURIPath(string pattern, Dictionary<string, string> pathParameters)
        {
            return FormatURIPath(pattern, pathParameters, null);
        }

        /// <summary>
        /// Formats the URI path for REST calls. Replaces any occurrences of the form
        /// {name} in pattern with the corresponding value of key name in the passed
        /// Dictionary. Query parameters are appended to the end of the URI path
        /// </summary>
        /// <param name="pattern">URI pattern with named place holders</param>
        /// <param name="pathParameters">Dictionary of Path parameters</param>
        /// <param name="queryParameters">Dictionary for Query parameters</param>
        /// <returns>Processed URI path</returns>
        public static string FormatURIPath(string pattern, Dictionary<string, string> pathParameters,
            Dictionary<string, string> queryParameters)
        {
            if (!String.IsNullOrEmpty(pattern) && pathParameters != null && pathParameters.Count > 0)
            {
                foreach (KeyValuePair<string, string> entry in pathParameters)
                {
                    // do something with entry.Value or entry.Key
                    string placeHolderName = "{" + entry.Key.Trim() + "}";
                    if (pattern.Contains(placeHolderName))
                    {
                        pattern = pattern.Replace(placeHolderName, entry.Value.Trim());
                    }
                }
            }
            var formattedUriPath = pattern;
            if (queryParameters != null && queryParameters.Count > 0)
            {
                StringBuilder stringBuilder = new StringBuilder(formattedUriPath);
                if (stringBuilder.ToString().Contains("?"))
                {
                    if (!(stringBuilder.ToString().EndsWith("?") || stringBuilder.ToString().EndsWith("&")))
                    {
                        stringBuilder.Append("&");
                    }
                }
                else
                {
                    stringBuilder.Append("?");
                }

                #if !NETSTANDARD1_3
                foreach (KeyValuePair<string, string> entry in queryParameters)
                {
                    stringBuilder.Append(HttpUtility.UrlEncode(entry.Key, Encoding.UTF8)).Append("=")
                        .Append(HttpUtility.UrlEncode(entry.Value, Encoding.UTF8)).Append("&");
                }
                #endif

                formattedUriPath = stringBuilder.ToString();
            }
            if (formattedUriPath != null && (formattedUriPath.Contains("{") || formattedUriPath.Contains("}")))
            {
                throw new LoginRadiusException("Unable to formatURI Path : "
                                               + formattedUriPath
                                               + ", unable to replace placeholders with the map : "
                                               + pathParameters);
            }
            return formattedUriPath;
        }

        /// <summary>
        /// Removes null entries from a given query string.
        /// </summary>
        /// <param name="formatString">A query string.</param>
        /// <returns>A query string with null entries removed.</returns>
        private static string RemoveNullsFromQueryString(string formatString)
        {
            if (!string.IsNullOrEmpty(formatString))
            {
                string[] parts = formatString.Split('?');

                //Process the query string part
                if (parts.Length == 2)
                {
                    string queryString = parts[1];
                    string[] queryStringSplit = queryString.Split('&');
                    if (queryStringSplit.Length > 0)
                    {
                        StringBuilder builder = new StringBuilder();
                        foreach (string query in queryStringSplit)
                        {
                            string[] valueSplit = query.Split('=');
                            if (valueSplit.Length == 2)
                            {
                                if (valueSplit[1].Trim().ToLower().Equals("null") || valueSplit[1].Trim().Length == 0)
                                    continue;

                                builder.Append(query).Append("&");
                            }
                        }
                        formatString = (!builder.ToString().EndsWith("&"))
                            ? builder.ToString()
                            : builder.ToString().Substring(0, builder.ToString().Length - 1);
                    }

                    //Append the query string delimiter
                    formatString = (parts[0].Trim() + "?") + formatString;
                }
            }
            return formatString;
        }

        /// <summary>
        /// Split the URI and form a Object array using the query string and values
        /// in the provided map. The return object array is populated only if the map
        /// contains valid value for the query name. The object array contains null
        /// values if there is no value found in the map
        /// </summary>
        /// <param name="pattern"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private static Object[] SplitParameters(string pattern, Dictionary<string, string> parameters)
        {
            List<Object> objectList = new List<Object>();
#if !NETSTANDARD1_3
            string[] query = pattern.Split('?');
            if (query.Length == 2 && query[1].Contains("={"))
            {
                NameValueCollection queryParts = HttpUtility.ParseQueryString(query[1]);

                foreach (string k in queryParts.AllKeys)
                {
                    string val;
                    objectList.Add(parameters.TryGetValue(k.Trim(), out val) ? val : null);
                }
            }
#endif
            return objectList.ToArray();
        }

        /// <summary>
        /// Gets the version number of the parent assembly for the specified object type.
        /// </summary>
        /// <param name="type">The object type to use in determining which assembly version should be returned.</param>
        /// <returns>A 3-digit version of the parent assembly.</returns>
        public static string GetAssemblyVersionForType(Type type)
        {
            #if !NETSTANDARD1_3
            return type.Assembly.GetName().Version.ToString(3);
            #else
            return null;
            #endif
        }

        /// <summary>
        /// Checks if .NET 4.5 or later is detected on the system.
        /// </summary>
        /// <returns>True if .NET 4.5 or later is detected; false otherwise.</returns>
        public static bool IsNet45OrLaterDetected()
        {
            var highestNetVersion = GetHighestInstalledNetVersion();
            return highestNetVersion != null && highestNetVersion >= new Version(4, 5, 0, 0);
        }

        /// <summary>
        /// Gets the highest installed version of the .NET framework found on the system.
        /// </summary>
        /// <returns>A string containing the highest installed version of the .NET framework found on the system.</returns>
        private static Version GetHighestInstalledNetVersion()
        {
#if NetFramework
            Version highestNetVersion = null;
            try
            {
                // Opens the registry key for the .NET Framework entry.
                using (var ndpKey = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, "")
                    .OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP\"))
                {
                    // As an alternative, if you know the computers you will query are running .NET Framework 4.5
                    // or later, you can use:
                    // using (RegistryKey ndpKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine,
                    // RegistryView.Registry32).OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP\"))
                    foreach (string versionKeyName in ndpKey.GetSubKeyNames())
                    {
                        if (versionKeyName.StartsWith("v"))
                        {
                            var versionKey = ndpKey.OpenSubKey(versionKeyName);
                            var versionString = versionKey.GetValue("Version", "").ToString();

                            if (string.IsNullOrEmpty(versionString))
                            {
                                foreach (string subKeyName in versionKey.GetSubKeyNames())
                                {
                                    var subKey = versionKey.OpenSubKey(subKeyName);
                                    versionString = subKey.GetValue("Version", "").ToString();

                                    if (!string.IsNullOrEmpty(versionString))
                                    {
                                        var version = new Version(versionString);
                                        if (highestNetVersion == null || highestNetVersion < version)
                                        {
                                            highestNetVersion = version;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                var version = new Version(versionString);
                                if (highestNetVersion == null || highestNetVersion < version)
                                {
                                    highestNetVersion = version;
                                }
                            }
                        }
                    }
                }
            }
            catch (System.Exception)
            {
                // ignored
            }
#endif

            return null;
        }
    }
}