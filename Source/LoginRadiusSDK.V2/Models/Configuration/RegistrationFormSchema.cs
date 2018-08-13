using System;
using System.Collections.Generic;
using System.Text;

namespace LoginRadiusSDK.V2.Models.Configuration
{
   public class RegistrationFormSchema
    {
        public bool Checked { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public string display { get; set; }
        public string rules { get; set; }
        public List<Options> options { get; set; }
        public string permission { get; set; }
        public object DataSource { get; set; }
        public string Parent { get; set; }
        public object ParentDataSource { get; set; }
       
    }

    public class Options
    {
        public string value { get; set; }
        public string text { get; set; }
    }
}
