using System;
using System.Collections.Generic;
using System.Text;

namespace LoginRadiusSDK.V2.Models.RegistrationData
{
    public class Data
    {
        public string Code { get; set; }
        public string Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public bool IsActive { get; set; }
        public string Type { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public object ParentId { get; set; }
        public object ParentType { get; set; }
    }

    public class UpdateRegistrationDataResponse
    {
        public bool IsPosted { get; set; }
        public Data Data { get; set; }
    }
}
