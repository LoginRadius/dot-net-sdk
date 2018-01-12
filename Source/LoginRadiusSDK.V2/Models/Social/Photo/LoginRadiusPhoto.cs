using System.Collections.Generic;

namespace LoginRadiusSDK.V2.Models.Photo
{
    public class LoginRadiusPhoto
    {
        public string ID { get; set; }
        public string AlbumId { get; set; }
        public string OwnerId { get; set; }
        public string OwnerName { get; set; }

        public string Name { get; set; }

        public string DirectUrl { get; set; }

        public string ImageUrl { get; set; }

        public string Location { get; set; }

        public string Link { get; set; }

        public string Description { get; set; }

        public string Height { get; set; }
        public string Width { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
        public List<FacebookAlbumImages> Images { get; set; }
    }
}