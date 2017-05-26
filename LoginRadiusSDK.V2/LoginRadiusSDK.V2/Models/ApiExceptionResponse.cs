using System.Collections.Generic;

namespace LoginRadiusSDK.V2.Models
{
    public class ApiExceptionResponse
    {
        public string Description { get; set; }
        public int? ErrorCode { get; set; }
        public string Message { get; set; }
        public bool? IsProviderError { get; set; }
        public string ProviderErrorResponse { get; set; }
    }
}