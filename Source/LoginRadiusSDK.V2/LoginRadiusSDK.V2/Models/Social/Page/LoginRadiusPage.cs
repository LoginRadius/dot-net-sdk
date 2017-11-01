using System.Collections.Generic;

namespace LoginRadiusSDK.V2.Models.Page
{
    public class LoginRadiusPage
    {
        public string ID { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public string Category { get; set; }

        public string Likes { get; set; }
        public string Phone { get; set; }

        public string Image { get; set; }

        public string Website { get; set; }
        public string About { get; set; }
        public string Description { get; set; }
        public string Awards { get; set; }
        public string CheckinCount { get; set; }
        public string Founded { get; set; }
        public string Mission { get; set; }
        public string Products { get; set; }
        public string ReleaseDate { get; set; }
        public string TalkingAboutCount { get; set; }

        public bool ?Published { get; set; }

        public string UserName { get; set; }

        public List<LoginRadiusPageLocations> Locations { get; set; }
        public List<LoginRadiusPageCategoryList> CategoryList { get; set; }
        public LoginRadiusPageCover CoverImage { get; set; }
        public LoginRadiusPageCodeName EmployeeCountRange { get; set; }
        public List<LoginRadiusPageCodeName> Industries { get; set; }
        public Specility Specialties { get; set; }
        public LoginRadiusPageCodeName Status { get; set; }
        public LoginRadiusPageCodeName StockExchange { get; set; }
    }

    public class Specility
    {
        public int ?Total { get; set; }
        public List<string>SpecialityNames { get; set; }
    }
}