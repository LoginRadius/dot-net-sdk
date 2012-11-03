// -----------------------------------------------------------------------
// <copyright file="Extensions.cs" company="LoginRadius">
// Copyright Loginradius 2011-2012
// </copyright>
// -----------------------------------------------------------------------

namespace LoginRadiusSDK
{
    using System;
 
    using System.Text.RegularExpressions;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public static class Extensions
    {
        public static bool IsGuid( string candidate)
        {
            Regex Guid = new Regex(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", RegexOptions.Compiled);
            if (candidate != null)
            {
                if (Guid.IsMatch(candidate))
                {
                    return true;
                }
            }
            return false;
        }
    }
}