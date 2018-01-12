using System.Collections.Generic;

namespace LoginRadiusSDK.V2.Models.Album
{
    public class LoginRadiusAlbum
    {
        public string ID { get; set; }
        public string OwnerId { get; set; }
        public string OwnerName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Type { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
        public string CoverImageUrl { get; set; }
        public string ImageCount { get; set; }
        public string DirectoryUrl { get; set; }
    }

    public class ListLoginRadiusAlbum
    {
        public List<LoginRadiusAlbum> Data { get; set; }
    }
}