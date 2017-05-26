using System.Collections.Generic;

namespace LoginRadiusSDK.V2.Models.UserProfile
{
    public class LoginRadiusSuggestion
    {
        public List<LoginRadiusNameId> CompaniestoFollow { get; set; }
        public List<LoginRadiusNameId> IndustriestoFollow { get; set; }
        public List<LoginRadiusNameId> NewssourcetoFollow { get; set; }
        public List<LoginRadiusNameId> PeopletoFollow { get; set; }
    }
}