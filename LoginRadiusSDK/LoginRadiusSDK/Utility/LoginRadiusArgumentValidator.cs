using System;
using System.Collections;

namespace LoginRadiusSDK.Utility
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
        /// <param name="name">Name of the function to be Validate</param>
        public void Validate(object argument, string name)
        {
            foreach (var arg in (IEnumerable) argument)
            {
                if (arg is string)
                {
                    if (string.IsNullOrEmpty(arg as string))
                    {
                        throw new ArgumentNullException(name + "method's value(s) cannot be null or empty.");
                    }
                }
                else if (arg is int)
                {
                    if (argument == null)
                    {
                        throw new ArgumentNullException(name + "method's value(s) cannot be null.");
                    }
                }
            }
        }
    }
}
