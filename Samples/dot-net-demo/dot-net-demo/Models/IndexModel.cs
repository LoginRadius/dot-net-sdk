using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dot_net_demo.Models
{
    public class ForgotPasswordModel
    {
        public string Email { get; set; }
    }
    public class SetPasswordModel
    {
        public string Password { get; set; }
    }
    public class GoogleAuthenticatorModel
    {
        public string googleauthenticatorcode { get; set; }
    }
}
