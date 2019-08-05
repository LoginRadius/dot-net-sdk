using LoginRadiusSDK.V2.Util.Serialization;

namespace LoginRadiusSDK.V2.Common
{
    public class ApiResponse<T> : LoginRadiusSerializableObject
    {
        public ApiExceptionResponse RestException { get; set; }
        public T Response { get; set; }
    }
}
