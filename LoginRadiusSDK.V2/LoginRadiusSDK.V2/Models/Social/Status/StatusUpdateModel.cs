using LoginRadiusSDK.V2.Util.Serialization;

namespace LoginRadiusSDK.V2.Models
{
    public class StatusUpdateModel : LoginRadiusSerializableObject
    {
        /// <summary>
        /// A title for status message.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// A web link of the status message
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// An image URL of the status message
        /// </summary>
        public string Imageurl { get; set; }

        /// <summary>
        /// The status message text
        /// </summary>
        public string status { get; set; }

        /// <summary>
        /// A caption of the status message
        /// </summary>
        public string Caption { get; set; }

        /// <summary>
        /// A description of the status message
        /// </summary>
        public string Description { get; set; }
    }


    public class PostStatus
    {
        /// <summary>
        /// A title for status message.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// A web link of the status message
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// An image URL of the status message
        /// </summary>
        public string Imageurl { get; set; }

        /// <summary>
        /// The status message text
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// A caption of the status message
        /// </summary>
        public string Caption { get; set; }

        /// <summary>
        /// A description of the status message
        /// </summary>
        public string Description { get; set; }
    }
}