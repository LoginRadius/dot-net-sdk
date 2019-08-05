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

    public class EmailLoginModel
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }

    public class ResetPasswordModel
    {
        public string password { get; set; }

        public string resettoken { get; set; }
    }

    public class ChangePasswordModel
    {
        public string newPassword { get; set; }

        public string oldPassword { get; set; }
    }
}
