using System;
// 
//Loginradius SDK demo
//
using System.Web.Script.Serialization;
using LoginRadius.SDK.Models;

namespace LoginRadius.SDK
{
    /// <summary>
    /// The LoginRadiusException class is used to handle exeception while loginradius api is executing.
    /// </summary>
    public class LoginRadiusException : Exception
    {
        /// <summary>
        /// 
        /// </summary>
        public string Response { get; set; }

        private ApiExceptionResponse _errorResponse;

        public ApiExceptionResponse ErrorResponse
        {
            get
            {
                if (_errorResponse == null)
                {
                    var jsserializer = new JavaScriptSerializer();
                    _errorResponse = jsserializer.Deserialize<ApiExceptionResponse>(Response);
                    return _errorResponse;
                }
                else
                {
                    return _errorResponse;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public LoginRadiusException()
            : base()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public LoginRadiusException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public LoginRadiusException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        /// <param name="response"></param>
        public LoginRadiusException(string message, Exception innerException, string response)
            : base(message, innerException)
        {
            Response = response;
        }
    }
}
