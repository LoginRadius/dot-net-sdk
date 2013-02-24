// -----------------------------------------------------------------------
// <copyright file="Utility.cs" company="LoginRadius Inc.">
// Copyright LoginRadius.com 2013
// This file is part of the LoginRadius SDK package.
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
    /// LoginRadius Utility Class for common functions
    /// </summary>
    public class Utility
    {
        /// <summary>
        /// Validate string for GUID format
        /// </summary>
        /// <param name="candidate">String to validate for GUID</param>
        /// <returns>true/false</returns>
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
    /// <summary>
    /// LoginRadius End Point
    /// </summary>
    /// <returns>string</returns>
    public class Requesturl
    {
        public const string url = "https://hub.loginradius.com";
    }
}
