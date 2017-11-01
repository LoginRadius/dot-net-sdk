using System;

namespace LoginRadiusSDK.V2.Models
{
    public class SottDetails
    {
        public string ServerLocation { get; set; }
        public string ServerName { get; set; }
        public string CurrentTime { get; set; }
        public Sott Sott { get; set; }
    }

    public class Sott
    {
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string TimeDifference { get; set; }
    }

    public class SottResponseData
    {
        public string Sott { get; set; }
        public DateTime ExpiryTime { get; set; }
    }
}