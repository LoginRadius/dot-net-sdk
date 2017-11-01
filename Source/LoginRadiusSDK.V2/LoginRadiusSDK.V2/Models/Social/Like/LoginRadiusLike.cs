using System.Collections.Generic;

namespace LoginRadiusSDK.V2.Models.Like
{
    public class LoginRadiusLike
    {
        public string Category { get; set; }
        public string Website { get; set; }
        public string Name { get; set; }
        public string CreatedDate { get; set; }
        public string ID { get; set; }
        public string Description { get; set; }
    }

    public class ListLoginRadiusLike
    {
        public List<LoginRadiusLike> Data { get; set; }
    }
}