using LoginRadiusSDK.V2.Util.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoginRadiusSDK.V2.Models.RegistrationData
{
   public class UpdateRegistrationDataModel : LoginRadiusSerializableObject
    {

        public string Type { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public object ParentId { get; set; }
        public string Code { get; set; }
        public bool IsActive { get; set; }

    }
}
