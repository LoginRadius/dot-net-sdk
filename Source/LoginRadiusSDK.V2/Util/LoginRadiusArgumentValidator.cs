using System;
using System.Collections;

namespace LoginRadiusSDK.V2.Util
{
    /// <summary>
    /// Class that validates arguments.
    /// </summary>
    public class LoginRadiusArgumentValidator
    {
        /// <summary>
        /// Helper method for validating an argument that will be used by API in any requests.
        /// </summary>
        /// <param name="argument">The object to be validated.</param>
        public static void Validate(object argument)
        {
            foreach (var arg in (IEnumerable) argument)
            {
                if (arg is string)
                {
                    if (string.IsNullOrEmpty(arg as string))
                    {
                        throw new ArgumentNullException("Value(s) cannot be null or empty.");
                    }
                }
                else if (arg is int)
                {
                    if (argument == null)
                    {
                        throw new ArgumentNullException("Value(s) cannot be null.");
                    }
                }
                else if (arg is IList)
                {
                    var list = arg as IList;
                    if (list.Count <= 0)
                    {
                        throw new ArgumentNullException("List cannot be empty.");
                    }
                }
            }
        }
    }
}