using System.Collections.Generic;
using LoginRadiusSDK.V2.Models.UserProfile;

namespace LoginRadiusSDK.V2.Models
{
    public class LoginRadiusRestHookUserProfile
    {
        public string ID { get; set; }
        public string Provider { get; set; }
        public string Prefix { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public string FullName { get; set; }
        public string NickName { get; set; }
        public string ProfileName { get; set; }
        public string BirthDate { get; set; }
        public string Gender { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public LoginRadiusCountry Country { get; set; }
        public string ThumbnailImageUrl { get; set; }
        public string ImageUrl { get; set; }
        public string Favicon { get; set; }
        public string ProfileUrl { get; set; }
        public string HomeTown { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Industry { get; set; }
        public string About { get; set; }
        public string TimeZone { get; set; }
        public string LocalLanguage { get; set; }
        public string CoverPhoto { get; set; }
        public string TagLine { get; set; }
        public string Language { get; set; }
        public string Verified { get; set; }
        public string UpdatedTime { get; set; }
        public string Positions { get; set; }
        public string Educations { get; set; }
        public string PhoneNumbers { get; set; }
        public string IMAccounts { get; set; }
        public string Addresses { get; set; }
        public string MainAddress { get; set; }
        public string Created { get; set; }
        public string LocalCity { get; set; }
        public string ProfileCity { get; set; }
        public string LocalCountry { get; set; }
        public string ProfileCountry { get; set; }
        public bool ?IsProtected { get; set; }
        public string RelationshipStatus { get; set; }
        public string Quote { get; set; }
        public string InterestedIn { get; set; }
        public string Interests { get; set; }
        public string Religion { get; set; }
        public string Political { get; set; }
        public string Sports { get; set; }
        public string InspirationalPeople { get; set; }
        public string HttpsImageUrl { get; set; }
        public int ?FollowersCount { get; set; }
        public int ?FriendsCount { get; set; }
        public string IsGeoEnabled { get; set; }
        public int ?TotalStatusesCount { get; set; }
        public string Associations { get; set; }
        public int ?NumRecommenders { get; set; }
        public string Honors { get; set; }
        public string Awards { get; set; }
        public string Skills { get; set; }
        public string CurrentStatus { get; set; }
        public string Certifications { get; set; }
        public string Courses { get; set; }
        public string Volunteer { get; set; }
        public string RecommendationsReceived { get; set; }
        public string Languages { get; set; }
        public string Projects { get; set; }
        public string Games { get; set; }
        public string Family { get; set; }
        public string TeleVisionShow { get; set; }
        public string MutualFriends { get; set; }
        public string Movies { get; set; }
        public string Books { get; set; }
        public LoginRadiusAgeRange AgeRange { get; set; }
        public string PublicRepository { get; set; }
        public bool ?Hireable { get; set; }
        public string RepositoryUrl { get; set; }
        public string Age { get; set; }
        public string Patents { get; set; }
        public string FavoriteThings { get; set; }
        public string ProfessionalHeadline { get; set; }
        public string RelatedProfileViews { get; set; }
        public LoginRadiusKloutProfile KloutScore { get; set; }
        public string LRUserID { get; set; }
        public string PlacesLived { get; set; }
        public string Publications { get; set; }
        public string JobBookmarks { get; set; }
        public string Suggestions { get; set; }
        public string Badges { get; set; }
        public string MemberUrlResources { get; set; }
        public int ?TotalPrivateRepository { get; set; }
        public string Currency { get; set; }
        public string StarredUrl { get; set; }
        public string GistsUrl { get; set; }
        public int ?PublicGists { get; set; }
        public int ?PrivateGists { get; set; }
        public LoginRadiusUserSubscription Subscription { get; set; }
        public string Company { get; set; }
        public bool ?EmailVerified { get; set; }
        public bool ?IsActive { get; set; }
        public bool ?IsDeleted { get; set; }
        public string Uid { get; set; }
        public Dictionary<string, string> CustomFields { get; set; }
        public bool ?IsEmailSubscribed { get; set; }
        public List<string> PreviousUids { get; set; }
        public string PhoneId { get; set; }
        public bool ?PhoneIdVerified { get; set; }
        public Dictionary<string, string> SecurityQuestionAnswer { get; set; }
    }
}