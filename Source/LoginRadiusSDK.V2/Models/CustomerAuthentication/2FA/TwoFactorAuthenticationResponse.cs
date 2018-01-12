using System;

namespace LoginRadiusSDK.V2.Models
{
    public class TwoFactorAuthenticationResponse<T>
    {
        public TwoFactorAuthenticationSettings SecondFactorAuthentication { get; set; }
        public T Profile { get; set; }
        public Guid access_token { get; set; }
        public DateTime ExpiresIn { get; set; }
    }
}   