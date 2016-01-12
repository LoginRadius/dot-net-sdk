using System.Collections.Generic;

namespace LoginRadiusSDK.Models
{
    public class LoginRadiusCursorResponse<T>
    {
        public List<T> Data { get; set; }
        public string NextCursor { get; set; }
    }
}
