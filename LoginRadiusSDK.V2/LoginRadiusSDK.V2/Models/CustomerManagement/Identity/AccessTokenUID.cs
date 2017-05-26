using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginRadiusSDK.V2.Models.CustomerManagement.Identity
{
    public class AccessTokenResponse
    {
        public string access_token { get; set; }
        public string expires_in { get; set; }
    }
}