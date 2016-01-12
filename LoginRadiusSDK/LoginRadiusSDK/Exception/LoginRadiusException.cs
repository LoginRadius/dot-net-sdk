using LoginRadiusSDK.Models;
using LoginRadiusSDK.Utility.Serialization;
// 
//Loginradius SDK demo
//

namespace LoginRadiusSDK.Exception
{
    /// <summary>
    /// The LoginRadiusException class is used to handle exception while loginradius api is executing.
    /// </summary>
    public class LoginRadiusException : System.Exception
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
                    _errorResponse = Response.Deserialize<ApiExceptionResponse>();
                    return _errorResponse;
                }
                return _errorResponse;
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
        public LoginRadiusException(string message, System.Exception innerException)
            : base(message, innerException)
        {
            string errorMessage = string.IsNullOrEmpty(this.ExceptionMessagePrefix) ? message : string.Format("{0}: {1}", this.ExceptionMessagePrefix, message);
            if (innerException == null)
            {
                Response = errorMessage;
            }
            else
            {
                Response = errorMessage + innerException;
            }
        }
        protected virtual string ExceptionMessagePrefix { get { return string.Empty; } }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        /// <param name="response"></param>
        public LoginRadiusException(string message, System.Exception innerException, string response)
            : base(message, innerException)
        {
            Response = response;
        }
    }
}
