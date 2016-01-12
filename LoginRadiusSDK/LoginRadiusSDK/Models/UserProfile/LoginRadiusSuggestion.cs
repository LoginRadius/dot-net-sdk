using System.Collections.Generic;

namespace LoginRadiusSDK.Models.UserProfile
{
    public class LoginRadiusSuggestion //: ILoginRadiusSuggestions
    {
        

        public List<LoginRadiusNameId> CompaniestoFollow { get; set; }


        public List<LoginRadiusNameId> IndustriestoFollow { get; set; }

        public List<LoginRadiusNameId> NewssourcetoFollow { get; set; }


        public List<LoginRadiusNameId> PeopletoFollow { get; set; }

    }

   
}
