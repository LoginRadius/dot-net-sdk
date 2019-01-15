using System;
using System.Collections.Generic;
using System.Text;

namespace LoginRadiusSDK.V2.Models.CustomerAuthentication._2FA
{
   public class ValidateMultifactorResponse
    {
        public string SecondFactorValidationToken { get; set; }
        public bool Status { get; set; }
        public DateTime ExpireIn { get; set; }
    }
}
