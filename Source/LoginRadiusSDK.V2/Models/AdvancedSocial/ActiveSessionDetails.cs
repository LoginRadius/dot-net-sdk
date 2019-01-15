using System.Collections.Generic;

namespace LoginRadiusSDK.V2.Models
{
    public class ActiveSessionDetails
    {
        public List<LoginRadiusQueryDataModel> data { get; set; }
        public int nextcursor { get; set; }
    }
}
