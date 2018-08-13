using System;
using System.Collections.Generic;
using System.Text;

namespace LoginRadiusSDK.V2.Models.Configuration
{
   public class LoginLockedConfiguration
    {
        public string LoginLockedType { get; set; }
        public int MaximumFailedLoginAttempts { get; set; }
        public SuspendConfiguration SuspendConfiguration { get; set; }
    }
}
