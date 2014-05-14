using System.Collections.Generic;

namespace LoginRadius.SDK.Models
{
    public class LoginRadiusCursorResponse<T>
    {
        public List<T> Data { get; set; }
        public string NextCursor { get; set; }
    }
}
