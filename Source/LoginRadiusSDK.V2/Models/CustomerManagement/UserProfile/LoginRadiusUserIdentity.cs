using System;
using System.Collections.Generic;

namespace LoginRadiusSDK.V2.Models.UserProfile
{
    public class LoginRadiusUserIdentity : NullUpdate
    {

        public string Password { get; set; }
        public object LastPasswordChangeDate { get; set; }
        public object PasswordExpirationDate { get; set; }
        public object LastPasswordChangeToken { get; set; }
        public bool EmailVerified { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string Uid { get; set; }
        public Dictionary<string, string> CustomFields { get; set; }
        public bool IsEmailSubscribed { get; set; }
        public object UserName { get; set; }
        public int NoOfLogins { get; set; }
        public object PreviousUids { get; set; }
        public object PhoneId { get; set; }
        public bool PhoneIdVerified { get; set; }
        public object ExternalUserLoginId { get; set; }
        public string RegistrationProvider { get; set; }
        public bool IsLoginLocked { get; set; }
        public string LoginLockedType { get; set; }
        public string LastLoginLocation { get; set; }
        public string RegistrationSource { get; set; }
        public bool IsCustomUid { get; set; }
        public List<LoginRadiusEmail> UnverifiedEmail { get; set; }
        public object IsSecurePassword { get; set; }
        public PrivacyPolicy PrivacyPolicy { get; set; }
        public object ExternalIds { get; set; }
        public string ID { get; set; }
        public string Provider { get; set; }
        public string Prefix { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public object Suffix { get; set; }
        public string FullName { get; set; }
        public string NickName { get; set; }
        public string ProfileName { get; set; }
        public string BirthDate { get; set; }
        public string Gender { get; set; }
        public string Website { get; set; }
        public List<LoginRadiusEmail> Email { get; set; }
        public object Country { get; set; }
        public string ThumbnailImageUrl { get; set; }
        public string ImageUrl { get; set; }
        public object Favicon { get; set; }
        public string ProfileUrl { get; set; }
        public string HomeTown { get; set; }
        public object State { get; set; }
        public string City { get; set; }
        public object Industry { get; set; }
        public string About { get; set; }
        public string TimeZone { get; set; }
        public string LocalLanguage { get; set; }
        public string CoverPhoto { get; set; }
        public object TagLine { get; set; }
        public string Language { get; set; }
        public string Verified { get; set; }
        public string UpdatedTime { get; set; }
        public List<LoginRadiusPosition> Positions { get; set; }
        public List<LoginRadiusEducation> Educations { get; set; }
        public object PhoneNumbers { get; set; }
        public object IMAccounts { get; set; }
        public object Addresses { get; set; }
        public object MainAddress { get; set; }
        public object Created { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime ProfileModifiedDate { get; set; }
        public string LocalCity { get; set; }
        public string ProfileCity { get; set; }
        public string LocalCountry { get; set; }
        public object ProfileCountry { get; set; }
        public bool FirstLogin { get; set; }
        public bool IsProtected { get; set; }
        public string RelationshipStatus { get; set; }
        public string Quota { get; set; }
        public string Quote { get; set; }
        public List<string> InterestedIn { get; set; }
        public object Interests { get; set; }
        public string Religion { get; set; }
        public string Political { get; set; }
        public List<LoginRadiusSport> Sports { get; set; }
        public object InspirationalPeople { get; set; }
        public string HttpsImageUrl { get; set; }
        public int FollowersCount { get; set; }
        public int FriendsCount { get; set; }
        public object IsGeoEnabled { get; set; }
        public int TotalStatusesCount { get; set; }
        public object Associations { get; set; }
        public int NumRecommenders { get; set; }
        public object Honors { get; set; }
        public object Awards { get; set; }
        public object Skills { get; set; }
        public object CurrentStatus { get; set; }
        public object Certifications { get; set; }
        public object Courses { get; set; }
        public object Volunteer { get; set; }
        public object RecommendationsReceived { get; set; }
        public List<RemoveLanguage> Languages { get; set; }
        public List<object> Projects { get; set; }
        public List<LoginRadiusGame> Games { get; set; }
        public object Family { get; set; }
        public List<LoginRadiusTelevisionShow> TeleVisionShow { get; set; }
        public object MutualFriends { get; set; }
        public List<LoginRadiusMovie> Movies { get; set; }
        public List<LoginRadiusBook> Books { get; set; }
        public LoginRadiusAgeRange AgeRange { get; set; }
        public object PublicRepository { get; set; }
        public bool Hireable { get; set; }
        public object RepositoryUrl { get; set; }
        public string Age { get; set; }
        public object Patents { get; set; }
        public List<LoginRadiusFavoriteThing> FavoriteThings { get; set; }
        public object ProfessionalHeadline { get; set; }
        public ProviderAccessCredential ProviderAccessCredential { get; set; }
        public object RelatedProfileViews { get; set; }
        public object KloutScore { get; set; }
        public object LRUserID { get; set; }
        public object PlacesLived { get; set; }
        public object Publications { get; set; }
        public object JobBookmarks { get; set; }
        public object Suggestions { get; set; }
        public object Badges { get; set; }
        public object MemberUrlResources { get; set; }
        public int TotalPrivateRepository { get; set; }
        public string Currency { get; set; }
        public object StarredUrl { get; set; }
        public object GistsUrl { get; set; }
        public int PublicGists { get; set; }
        public int PrivateGists { get; set; }
        public object Subscription { get; set; }
        public object Company { get; set; }
        public string GravatarImageUrl { get; set; }
        public Dictionary<string, string> ProfileImageUrls { get; set; }
        public object WebProfiles { get; set; }
        public int PinsCount { get; set; }
        public int BoardsCount { get; set; }
        public int LikesCount { get; set; }
        public DateTime SignupDate { get; set; }
        public DateTime LastLoginDate { get; set; }
        public List<LoginRadiusSocialUserProfile> Identities { get; set; }
    }


    public class NullUpdate : LoginRadiusSocialUserProfile
    {
        public bool NullSupport { get; set; }
    }

    public class PrivacyPolicy
    {
        public string Version { get; set; }
        public string AcceptSource { get; set; }
        public DateTime AcceptDateTime { get; set; }
    }
}