using System;
using System.Collections.Generic;

namespace LoginRadiusSDK.V2.Models.Object
{
    public class CustomObjectprop
    {
        public string Id { get; set; }
        public bool ?IsActive { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public bool ?IsDeleted { get; set; }
        public string Uid { get; set; }
        public object CustomObject { get; set; }
    }

    public class CustomObjectResponse
    {
        public List<CustomObjectprop> data { get; set; }
        public string count { get; set; }
    }




}