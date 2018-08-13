using System;
using System.Collections.Generic;
using System.Text;

namespace LoginRadiusSDK.V2.Models.Configuration
{
    public class SocialSchema
    {
        public List<Provider> Providers { get; set; }
    }
    public class Provider
    {
        public string Name { get; set; }
        public string Endpoint { get; set; }
    }
}
