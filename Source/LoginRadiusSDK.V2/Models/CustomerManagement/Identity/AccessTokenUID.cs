namespace LoginRadiusSDK.V2.Models.Identity
{
    public class AccessTokenResponse
    {
        public string access_token { get; set; }
        public string refresh_token { get; set; }
        public string expires_in { get; set; }
        public string provider { get; set; }
        public bool isrememberme { get; set; }
    }
}