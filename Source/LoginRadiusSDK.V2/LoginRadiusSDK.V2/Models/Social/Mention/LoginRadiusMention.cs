// -----------------------------------------------------------------------
// <copyright file="LoginRadiusContact.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace LoginRadiusSDK.V2.Models.Mention
{
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class LoginRadiusMention
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public object ImageUrl { get; set; }
        public string DateTime { get; set; }
        public string Source { get; set; }
        public string Place { get; set; }
        public int ?Likes { get; set; }
        public object LinkUrl { get; set; }
        public string Id { get; set; }
    }
}