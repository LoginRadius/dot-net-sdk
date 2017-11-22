namespace LoginRadiusSDK.V2.Models
{
    public class LoginRadiusCountResponse<T> where T : class
    {
        public int? Count { get; set; }
        public T Data { get; set; }
    }
}