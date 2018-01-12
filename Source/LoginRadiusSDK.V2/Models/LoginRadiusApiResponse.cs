namespace LoginRadiusSDK.V2.Models
{
    public class LoginRadiusApiResponse<T> where T : class
    {
        public T data { get; set; }
        public bool? signin { get; set; }
    }
}