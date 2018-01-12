using LoginRadiusSDK.V2.Models.UserProfile;

namespace LoginRadiusSDK.V2.Models
{
    public class LoginResponse
    {
        public string access_token { get; set; }
        public string expires_in { get; set; }
        public LoginRadiusUserIdentity Profile { get; set; }
    }

    public class LoginResponse<T>
    {
        public string access_token { get; set; }
        public string expires_in { get; set; }
        public T Profile { get; set; }
    }
}