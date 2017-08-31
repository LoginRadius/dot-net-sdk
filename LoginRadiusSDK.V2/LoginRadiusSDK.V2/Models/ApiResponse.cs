using LoginRadiusSDK.V2.Util.Serialization;

namespace LoginRadiusSDK.V2.Models
{
    public class ApiResponse<T> : LoginRadiusSerializableObject
    {
        public ApiExceptionResponse _ApiExceptionResponse { get; set; }
        public T Response { get; set; }
    }
}