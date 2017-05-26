using System;
using System.Collections.Generic;
using LoginRadiusSDK.V2.Util.Serialization;

namespace LoginRadiusSDK.V2.Models.UserProfile
{
    public class LoginRadiusAccountUpdateModel : LoginRadiusSerializableObject
    {
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
        public List<LoginRadiusEmail> Email { get; set; }
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
        public List<LoginRadiusPosition> Positions { get; set; }
        public List<LoginRadiusEducation> Educations { get; set; }
        public List<LoginRadiusPhoneNumber> PhoneNumbers { get; set; }
        public List<LoginRadiusIMAccount> IMAccounts { get; set; }
        public List<LoginRadiusAddress> Addresses { get; set; }
        public string MainAddress { get; set; }
        public string LocalCity { get; set; }
        public string ProfileCity { get; set; }
        public string LocalCountry { get; set; }
        public string ProfileCountry { get; set; }
        public bool ?IsProtected { get; set; }
        public string RelationshipStatus { get; set; }
        public string Quota { get; set; }
        public List<string> InterestedIn { get; set; }
        public List<LoginRadiusInterest> Interests { get; set; }
        public string Religion { get; set; }
        public string Political { get; set; }
        public List<LoginRadiusSport> Sports { get; set; }
        public List<LoginRadiusInspirationalPeople> InspirationalPeople { get; set; }
        public string HttpsImageUrl { get; set; }
        public int ?FollowersCount { get; set; }
        public int ?FriendsCount { get; set; }
        public string IsGeoEnabled { get; set; }
        public int ?TotalStatusesCount { get; set; }
        public string Associations { get; set; }
        public int ?NumRecommenders { get; set; }
        public string Honors { get; set; }
        public List<LoginRadiusAward> Awards { get; set; }
        public List<LoginRadiusSkill> Skills { get; set; }
        public List<LoginRadiusCurrentStatus> CurrentStatus { get; set; }
        public List<LoginRadiusCertification> Certifications { get; set; }
        public List<LoginRadiusCourse> Courses { get; set; }
        public List<LoginRadiusVolunteer> Volunteer { get; set; }
        public List<LoginRadiusRecommendationReceived> RecommendationsReceived { get; set; }
        public List<LoginRadiusLanguage> Languages { get; set; }
        public List<LoginRadiusProject> Projects { get; set; }
        public List<LoginRadiusGame> Games { get; set; }
        public List<LoginRadiusFamily> Family { get; set; }
        public List<LoginRadiusTelevisionShow> TeleVisionShow { get; set; }
        public List<LoginRadiusMutualFriend> MutualFriends { get; set; }
        public List<LoginRadiusMovie> Movies { get; set; }
        public List<LoginRadiusBook> Books { get; set; }
        public LoginRadiusAgeRange AgeRange { get; set; }
        public string PublicRepository { get; set; }
        public Boolean ?Hireable { get; set; }
        public string RepositoryUrl { get; set; }
        public string Age { get; set; }
        public List<LoginRadiusPatent> Patents { get; set; }
        public List<LoginRadiusFavoriteThing> FavoriteThings { get; set; }
        public string ProfessionalHeadline { get; set; }
        public ProviderAccessCredential ProviderAccessCredential { get; set; }
        public List<LoginRadiusRelatedProfileViews> RelatedProfileViews { get; set; }
        public LoginRadiusKloutProfile KloutScore { get; set; }
        public List<LoginRadiusPlaceLived> PlacesLived { get; set; }
        public List<LoginRadiusPublication> Publications { get; set; }
        public List<LoginRadiusJobBookmark> JobBookmarks { get; set; }
        public LoginRadiusSuggestion Suggestions { get; set; }
        public List<LoginRadiusBadge> Badges { get; set; }
        public List<LoginRadiusMemberUrlResource> MemberUrlResources { get; set; }
        public int ?TotalPrivateRepository { get; set; }
        public string Currency { get; set; }
        public string StarredUrl { get; set; }
        public string GistsUrl { get; set; }
        public int ?PublicGists { get; set; }
        public int ?PrivateGists { get; set; }
        public LoginRadiusUserSubscription Subscription { get; set; }
        public string Company { get; set; }
        public string GravatarImageUrl { get; set; }
        public Dictionary<string, string> ProfileImageUrls { get; set; }
        public Dictionary<string, string> WebProfiles { get; set; }
        public string Password { get; set; }
        public Dictionary<string, string> CustomFields { get; set; }
        public bool ?IsEmailSubscribed { get; set; }
        public string UserName { get; set; }
        public string PhoneId { get; set; }
        public bool ?PhoneIdVerified { get; set; }
        public bool ?EmailVerified { get; set; }
        public bool ?IsDeleted { get; set; }
    }


    public class SecurityQuestion: LoginRadiusSerializableObject
    {

       public  Dictionary<string, string> SecurityQuestionAnswer  { get; set; }
    }
   

    public class SecurityQuestionAnswerPost : LoginRadiusSerializableObject
    {
        public Dictionary<string, string> SecurityQuestionAnswer { get; set; }
    }
    public class SecurityQuestionAnswer: LoginRadiusSerializableObject
    {
        public string  MiddleName { get; set; }
        public string PetName { get; set; }
    }
}