using System;

namespace LoginRadiusSDK.V2.Models.CustomObject
{
    public class CustomObjectResponse
    {
        public string Id { get; set; }
        public bool ?IsActive { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public bool ?IsDeleted { get; set; }

        public string Uid { get; set; }

        public dynamic CustomObject { get; set; }
    }
}