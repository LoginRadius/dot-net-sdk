namespace LoginRadiusSDK.V2.Models.UserProfile
{
    public class LoginRadiusJobBookmark
    {
        public bool ?IsApplied { get; set; }
        public string ApplyTimestamp { get; set; }
        public bool ?IsSaved { get; set; }
        public string SavedTimestamp { get; set; }
        public LoginRadiusJob Job { get; set; }
    }

    public class LoginRadiusJob
    {
        public bool ?Active { get; set; }
        public string Id { get; set; }
        public string DescriptionSnippet { get; set; }
        public LoginRadiusJobBookmarkCompany Compony { get; set; }
        public LoginRadiusJobBookmarkPosition Position { get; set; }
        public string PostingTimestamp { get; set; }
    }

    public class LoginRadiusJobBookmarkCompany
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class LoginRadiusJobBookmarkPosition
    {
        public string Title { get; set; }
    }
}