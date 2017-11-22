namespace LoginRadiusSDK.V2.Models.CheckIn
{
    public class LoginRadiusCheckIn
    {
        public string ID { get; set; }

        public string CreatedDate { get; set; }

        public string OwnerId { get; set; }
        public string OwnerName { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Message { get; set; }
        public string PlaceTitle { get; set; }
        public string Address { get; set; }
        public string Distance { get; set; }
        public string Type { get; set; }

        public string ImageUrl { get; set; }
    }
}