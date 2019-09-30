using System.Collections.Generic;


namespace LoginRadiusSDK.V2.Common
{
    public class ApiExceptionResponse
    {
        /// <summary>
        /// Detailed error description. 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// LoginRadius API error code.
        /// </summary>
        public int? ErrorCode { get; set; }
        
        /// <summary>
        /// Error message
        /// </summary>
        public string Message { get; set; }
        
        /// <summary>
        /// Determines whether the error is of social provider. 
        /// </summary>
        public bool? IsProviderError { get; set; }
        
        /// <summary>
        /// Determines social provider error response.
        /// </summary>
        public string ProviderErrorResponse { get; set; }
        

        /// <summary>
        /// Represents errors that occurred during the server validation of request payload. 
        /// </summary>
        public List<ValidationErrors> Errors { get; set; }
        public object Data { get; set; }
        
    }

}
