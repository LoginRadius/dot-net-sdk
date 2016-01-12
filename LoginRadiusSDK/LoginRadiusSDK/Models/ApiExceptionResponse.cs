
namespace LoginRadiusSDK.Models
{
    public class ApiExceptionResponse
    {
        public string description { get; set; }
        public int errorCode { get; set; }
        public string message { get; set; }
        public bool isProviderError { get; set; }
        public string providerErrorResponse { get; set; }
    }
}
