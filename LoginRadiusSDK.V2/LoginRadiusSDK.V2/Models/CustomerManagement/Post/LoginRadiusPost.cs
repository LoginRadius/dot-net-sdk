using System;

namespace LoginRadiusSDK.V2.Models
{
    public class LoginRadiusPost
    {
        public string ID { get; set; }

        public string Name { get; set; }
        public string Title { get; set; }

        public string StartTime { get; set; }
        public string UpdateTime { get; set; }


        public string Message { get; set; }
        public string Place { get; set; }
        public string Picture { get; set; }

        public Int32? Likes { get; set; }
        public Int32? Share { get; set; }

        public string Type { get; set; }
    }
}