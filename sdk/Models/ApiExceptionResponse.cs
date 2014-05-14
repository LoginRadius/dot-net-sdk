using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoginRadius.SDK.Models
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
