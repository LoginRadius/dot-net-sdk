// -----------------------------------------------------------------------
// <copyright file="Utility.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace LoginRadiusSDK
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Utility
    {
        /// <summary>
        /// validate GIUD
        /// </summary>
        /// <param name="candidate">string to validate</param>
        /// <returns>boolean</returns>
        public static bool IsGuid(string candidate)
        {
            Regex guid = new Regex(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", RegexOptions.Compiled);
            if (candidate != null)
            {
                if (guid.IsMatch(candidate))
                {
                    return true;
                }
            }
            return false;
        }
    }
    public class Requesturl
    {
        public const string url = "https://hub.loginradius.com";
    }
}
