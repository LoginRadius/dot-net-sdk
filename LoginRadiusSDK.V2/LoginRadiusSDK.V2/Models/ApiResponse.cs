using LoginRadiusSDK.V2.Util.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginRadiusSDK.V2.Models
{
    public class ApiResponse<T> : LoginRadiusSerializableObject
    {
        public ApiExceptionResponse _ApiExceptionResponse { get; set; }
        public T Response { get; set; }
    }
}