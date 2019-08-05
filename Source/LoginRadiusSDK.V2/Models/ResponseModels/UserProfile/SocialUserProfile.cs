//-----------------------------------------------------------------------
// <copyright file="ModelClass" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2019 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using LoginRadiusSDK.V2.Models.ResponseModels.UserProfile.Objects;
namespace LoginRadiusSDK.V2.Models.ResponseModels.UserProfile

{

    /// <summary>
    ///	Response containing Definition for Complete SocialUserProfile data
    /// </summary>
    public class SocialUserProfile
    {
		/// <summary>
		///	About value that need to be inserted
		/// </summary>
		[JsonProperty(PropertyName = "About")]
        public  string About {get;set;}

		/// <summary>
		///	Array of objects,String represents address of user
		/// </summary>
		[JsonProperty(PropertyName = "Addresses")]
        public  List<Address> Addresses {get;set;}

		/// <summary>
		///	User's Age
		/// </summary>
		[JsonProperty(PropertyName = "Age")]
        public  string Age {get;set;}

		/// <summary>
		///	user's age range.
		/// </summary>
		[JsonProperty(PropertyName = "AgeRange")]
        public  AgeRange AgeRange {get;set;}

		/// <summary>
		///	Organization a person is assosciated with
		/// </summary>
		[JsonProperty(PropertyName = "Associations")]
        public  string Associations {get;set;}

		/// <summary>
		///	Array of Objects,String represents Id, Name and  Issuer
		/// </summary>
		[JsonProperty(PropertyName = "Awards")]
        public  List<Awards> Awards {get;set;}

		/// <summary>
		///	User's Badges.
		/// </summary>
		[JsonProperty(PropertyName = "Badges")]
        public  List<Badges> Badges {get;set;}

		/// <summary>
		///	user's birthdate
		/// </summary>
		[JsonProperty(PropertyName = "BirthDate")]
        public  string BirthDate {get;set;}

		/// <summary>
		///	boards count
		/// </summary>
		[JsonProperty(PropertyName = "BoardsCount")]
        public  int? BoardsCount {get;set;}

		/// <summary>
		///	Array of Objects,String represents Id,Name,Category,CreatedDate
		/// </summary>
		[JsonProperty(PropertyName = "Books")]
        public  List<Books> Books {get;set;}

		/// <summary>
		///	Array of Objects,string represents Id,Name,Authority Number,StartDate,EndDate
		/// </summary>
		[JsonProperty(PropertyName = "Certifications")]
        public  List<Certifications> Certifications {get;set;}

		/// <summary>
		///	user's city
		/// </summary>
		[JsonProperty(PropertyName = "City")]
        public  string City {get;set;}

		/// <summary>
		///	users company name
		/// </summary>
		[JsonProperty(PropertyName = "Company")]
        public  string Company {get;set;}

		/// <summary>
		///	Country of the user
		/// </summary>
		[JsonProperty(PropertyName = "Country")]
        public  Country Country {get;set;}

		/// <summary>
		///	users course information
		/// </summary>
		[JsonProperty(PropertyName = "Courses")]
        public  List<Courses> Courses {get;set;}

		/// <summary>
		///	URL of the photo that need to be inserted
		/// </summary>
		[JsonProperty(PropertyName = "CoverPhoto")]
        public  string CoverPhoto {get;set;}

		/// <summary>
		///	created
		/// </summary>
		[JsonProperty(PropertyName = "Created")]
        public  string Created {get;set;}

		/// <summary>
		///	Date of Creation of Profile
		/// </summary>
		[JsonProperty(PropertyName = "CreatedDate")]
        public  DateTime? CreatedDate {get;set;}

		/// <summary>
		///	Currency
		/// </summary>
		[JsonProperty(PropertyName = "Currency")]
        public  string Currency {get;set;}

		/// <summary>
		///	Array of Objects,String represents  id ,Text ,Source  and CreatedDate
		/// </summary>
		[JsonProperty(PropertyName = "CurrentStatus")]
        public  List<CurrentStatus> CurrentStatus {get;set;}

		/// <summary>
		///	Array of Objects,which represents the educations record
		/// </summary>
		[JsonProperty(PropertyName = "Educations")]
        public  List<Education> Educations {get;set;}

		/// <summary>
		///	user's email
		/// </summary>
		[JsonProperty(PropertyName = "Email")]
        public  List<Email> Email {get;set;}

		/// <summary>
		///	user's family
		/// </summary>
		[JsonProperty(PropertyName = "Family")]
        public  List<Family> Family {get;set;}

		/// <summary>
		///	URL of the favicon that need to be inserted
		/// </summary>
		[JsonProperty(PropertyName = "Favicon")]
        public  string Favicon {get;set;}

		/// <summary>
		///	Array of Objects,strings represents	Id ,Name ,Type
		/// </summary>
		[JsonProperty(PropertyName = "FavoriteThings")]
        public  List<FavoriteThings> FavoriteThings {get;set;}

		/// <summary>
		///	first login
		/// </summary>
		[JsonProperty(PropertyName = "FirstLogin")]
        public  bool? FirstLogin {get;set;}

		/// <summary>
		///	user's first name
		/// </summary>
		[JsonProperty(PropertyName = "FirstName")]
        public  string FirstName {get;set;}

		/// <summary>
		///	user's followers count
		/// </summary>
		[JsonProperty(PropertyName = "FollowersCount")]
        public  int? FollowersCount {get;set;}

		/// <summary>
		///	users friends count
		/// </summary>
		[JsonProperty(PropertyName = "FriendsCount")]
        public  int? FriendsCount {get;set;}

		/// <summary>
		///	Users complete name
		/// </summary>
		[JsonProperty(PropertyName = "FullName")]
        public  string FullName {get;set;}

		/// <summary>
		///	Array of Objects,string represents Id,Name,Category,CreatedDate
		/// </summary>
		[JsonProperty(PropertyName = "Games")]
        public  List<Games> Games {get;set;}

		/// <summary>
		///	user's gender
		/// </summary>
		[JsonProperty(PropertyName = "Gender")]
        public  string Gender {get;set;}

		/// <summary>
		///	Git Repository URL
		/// </summary>
		[JsonProperty(PropertyName = "GistsUrl")]
        public  string GistsUrl {get;set;}

		/// <summary>
		///	URL of image that need to be inserted
		/// </summary>
		[JsonProperty(PropertyName = "GravatarImageUrl")]
        public  string GravatarImageUrl {get;set;}

		/// <summary>
		///	boolean type value, default value is true
		/// </summary>
		[JsonProperty(PropertyName = "Hireable")]
        public  bool? Hireable {get;set;}

		/// <summary>
		///	user's home town name
		/// </summary>
		[JsonProperty(PropertyName = "HomeTown")]
        public  string HomeTown {get;set;}

		/// <summary>
		///	Awards lists from the social provider
		/// </summary>
		[JsonProperty(PropertyName = "Honors")]
        public  string Honors {get;set;}

		/// <summary>
		///	URL of the Image that need to be inserted
		/// </summary>
		[JsonProperty(PropertyName = "HttpsImageUrl")]
        public  string HttpsImageUrl {get;set;}

		/// <summary>
		///	ID of the User
		/// </summary>
		[JsonProperty(PropertyName = "ID")]
        public  string ID {get;set;}

		/// <summary>
		///	Array of objects, String represents account type and account name.
		/// </summary>
		[JsonProperty(PropertyName = "IMAccounts")]
        public  List<IMAccount> IMAccounts {get;set;}

		/// <summary>
		///	image URL should be absolute and has HTTPS domain
		/// </summary>
		[JsonProperty(PropertyName = "ImageUrl")]
        public  string ImageUrl {get;set;}

		/// <summary>
		///	Industry name
		/// </summary>
		[JsonProperty(PropertyName = "Industry")]
        public  string Industry {get;set;}

		/// <summary>
		///	Array of Objects,string represents Id and Name
		/// </summary>
		[JsonProperty(PropertyName = "InspirationalPeople")]
        public  List<InspirationalPeople> InspirationalPeople {get;set;}

		/// <summary>
		///	array of string represents interest
		/// </summary>
		[JsonProperty(PropertyName = "InterestedIn")]
        public  List<string> InterestedIn {get;set;}

		/// <summary>
		///	Array of objects, string shows InterestedType and InterestedName
		/// </summary>
		[JsonProperty(PropertyName = "Interests")]
        public  List<Interests> Interests {get;set;}

		/// <summary>
		///	boolean type value, default is true
		/// </summary>
		[JsonProperty(PropertyName = "IsGeoEnabled")]
        public  string IsGeoEnabled {get;set;}

		/// <summary>
		///	boolean type value, default is true
		/// </summary>
		[JsonProperty(PropertyName = "IsProtected")]
        public  bool? IsProtected {get;set;}

		/// <summary>
		///	Array of Objects,Strings,boolean,object represents IsApplied,ApplyTimestamp,IsSaved,SavedTimestamp,Job
		/// </summary>
		[JsonProperty(PropertyName = "JobBookmarks")]
        public  List<JobBookmarks> JobBookmarks {get;set;}

		/// <summary>
		///	Object, string represents KloutId and double represents Score
		/// </summary>
		[JsonProperty(PropertyName = "KloutScore")]
        public  KloutProfile KloutScore {get;set;}

		/// <summary>
		///	language known by user's
		/// </summary>
		[JsonProperty(PropertyName = "Language")]
        public  string Language {get;set;}

		/// <summary>
		///	language known by user's
		/// </summary>
		[JsonProperty(PropertyName = "Languages")]
        public  List<Languages> Languages {get;set;}

		/// <summary>
		///	last login date
		/// </summary>
		[JsonProperty(PropertyName = "LastLoginDate")]
        public  DateTime? LastLoginDate {get;set;}

		/// <summary>
		///	user's last name
		/// </summary>
		[JsonProperty(PropertyName = "LastName")]
        public  string LastName {get;set;}

		/// <summary>
		///	likes count
		/// </summary>
		[JsonProperty(PropertyName = "LikesCount")]
        public  int? LikesCount {get;set;}

		/// <summary>
		///	Local City of the user
		/// </summary>
		[JsonProperty(PropertyName = "LocalCity")]
        public  string LocalCity {get;set;}

		/// <summary>
		///	Local country of the user
		/// </summary>
		[JsonProperty(PropertyName = "LocalCountry")]
        public  string LocalCountry {get;set;}

		/// <summary>
		///	Local language of the user
		/// </summary>
		[JsonProperty(PropertyName = "LocalLanguage")]
        public  string LocalLanguage {get;set;}

		/// <summary>
		///	LR user id
		/// </summary>
		[JsonProperty(PropertyName = "LRUserID")]
        public  string LRUserID {get;set;}

		/// <summary>
		///	Main address of the user
		/// </summary>
		[JsonProperty(PropertyName = "MainAddress")]
        public  string MainAddress {get;set;}

		/// <summary>
		///	Array of Objects,String represents Url,UrlName
		/// </summary>
		[JsonProperty(PropertyName = "MemberUrlResources")]
        public  List<Memberurlresources> MemberUrlResources {get;set;}

		/// <summary>
		///	user's middle name
		/// </summary>
		[JsonProperty(PropertyName = "MiddleName")]
        public  string MiddleName {get;set;}

		/// <summary>
		///	profile updated date
		/// </summary>
		[JsonProperty(PropertyName = "ModifiedDate")]
        public  DateTime? ModifiedDate {get;set;}

		/// <summary>
		///	Array of Objects,strings represents	Id,Name,Category,CreatedDate
		/// </summary>
		[JsonProperty(PropertyName = "Movies")]
        public  List<Movies> Movies {get;set;}

		/// <summary>
		///	Array of Objects, strings represents Id,Name,FirstName,LastName,Birthday,Hometown,Link,Gender
		/// </summary>
		[JsonProperty(PropertyName = "MutualFriends")]
        public  List<MutualFriends> MutualFriends {get;set;}

		/// <summary>
		///	Nick name of the user
		/// </summary>
		[JsonProperty(PropertyName = "NickName")]
        public  string NickName {get;set;}

		/// <summary>
		///	Count for the user profile recommended
		/// </summary>
		[JsonProperty(PropertyName = "NumRecommenders")]
        public  int? NumRecommenders {get;set;}

		/// <summary>
		///	Patents Registered
		/// </summary>
		[JsonProperty(PropertyName = "Patents")]
        public  List<Patents> Patents {get;set;}

		/// <summary>
		///	Users Phone Number
		/// </summary>
		[JsonProperty(PropertyName = "PhoneNumbers")]
        public  List<Phone> PhoneNumbers {get;set;}

		/// <summary>
		///	count of pins
		/// </summary>
		[JsonProperty(PropertyName = "PinsCount")]
        public  int? PinsCount {get;set;}

		/// <summary>
		///	Array of Objects,strings Name and boolean IsPrimary
		/// </summary>
		[JsonProperty(PropertyName = "PlacesLived")]
        public  List<PlacesLived> PlacesLived {get;set;}

		/// <summary>
		///	List of Political interest
		/// </summary>
		[JsonProperty(PropertyName = "Political")]
        public  string Political {get;set;}

		/// <summary>
		///	Array of Objects,which represents the PositionSummary,StartDate,EndDate,IsCurrent,Company,Location
		/// </summary>
		[JsonProperty(PropertyName = "Positions")]
        public  List<ProfessionalPosition> Positions {get;set;}

		/// <summary>
		///	Prefix for FirstName
		/// </summary>
		[JsonProperty(PropertyName = "Prefix")]
        public  string Prefix {get;set;}

		/// <summary>
		///	previous ids
		/// </summary>
		[JsonProperty(PropertyName = "PreviousUids")]
        public  List<string> PreviousUids {get;set;}

		/// <summary>
		///	user private Repository Urls
		/// </summary>
		[JsonProperty(PropertyName = "PrivateGists")]
        public  int? PrivateGists {get;set;}

		/// <summary>
		///	This field provide by linkedin.contain our linkedin profile headline
		/// </summary>
		[JsonProperty(PropertyName = "ProfessionalHeadline")]
        public  string ProfessionalHeadline {get;set;}

		/// <summary>
		///	ProfileCity value that need to be inserted
		/// </summary>
		[JsonProperty(PropertyName = "ProfileCity")]
        public  string ProfileCity {get;set;}

		/// <summary>
		///	ProfileCountry value that need to be inserted
		/// </summary>
		[JsonProperty(PropertyName = "ProfileCountry")]
        public  string ProfileCountry {get;set;}

		/// <summary>
		///	ProfileImageUrls that need to be inserted
		/// </summary>
		[JsonProperty(PropertyName = "ProfileImageUrls")]
        public  Dictionary<string,string> ProfileImageUrls {get;set;}

		/// <summary>
		///	profile updated date
		/// </summary>
		[JsonProperty(PropertyName = "ProfileModifiedDate")]
        public  DateTime? ProfileModifiedDate {get;set;}

		/// <summary>
		///	ProfileName value field that need to be inserted
		/// </summary>
		[JsonProperty(PropertyName = "ProfileName")]
        public  string ProfileName {get;set;}

		/// <summary>
		///	User profile url like facebook profile Url
		/// </summary>
		[JsonProperty(PropertyName = "ProfileUrl")]
        public  string ProfileUrl {get;set;}

		/// <summary>
		///	Array of Objects,string represents  Id,Name,Summary With StartDate,EndDate,IsCurrent
		/// </summary>
		[JsonProperty(PropertyName = "Projects")]
        public  List<Projects> Projects {get;set;}

		/// <summary>
		///	Name of the provider
		/// </summary>
		[JsonProperty(PropertyName = "Provider")]
        public  string Provider {get;set;}

		/// <summary>
		///	Object,string represents AccessToken,TokenSecret
		/// </summary>
		[JsonProperty(PropertyName = "ProviderAccessCredential")]
        public  ProviderAccessCredential ProviderAccessCredential {get;set;}

		/// <summary>
		///	Array of Objects,string represents Id,Title,Publisher,Authors,Date,Url,Summary
		/// </summary>
		[JsonProperty(PropertyName = "Publications")]
        public  List<Publications> Publications {get;set;}

		/// <summary>
		///	gist is a Git repository, which means that it can be forked and cloned.
		/// </summary>
		[JsonProperty(PropertyName = "PublicGists")]
        public  int? PublicGists {get;set;}

		/// <summary>
		///	user public Repository Urls
		/// </summary>
		[JsonProperty(PropertyName = "PublicRepository")]
        public  string PublicRepository {get;set;}

		/// <summary>
		///	Quota
		/// </summary>
		[JsonProperty(PropertyName = "Quota")]
        public  string Quota {get;set;}

		/// <summary>
		///	quote
		/// </summary>
		[JsonProperty(PropertyName = "Quote")]
        public  string Quote {get;set;}

		/// <summary>
		///	Array of Objects,string represents Id,RecommendationType,RecommendationText,Recommender
		/// </summary>
		[JsonProperty(PropertyName = "RecommendationsReceived")]
        public  List<RecommendationsReceived> RecommendationsReceived {get;set;}

		/// <summary>
		///	Array of Objects,String represents Id,FirstName,LastName
		/// </summary>
		[JsonProperty(PropertyName = "RelatedProfileViews")]
        public  List<RelatedProfileViews> RelatedProfileViews {get;set;}

		/// <summary>
		///	user's relationship status
		/// </summary>
		[JsonProperty(PropertyName = "RelationshipStatus")]
        public  string RelationshipStatus {get;set;}

		/// <summary>
		///	String shows users religion
		/// </summary>
		[JsonProperty(PropertyName = "Religion")]
        public  string Religion {get;set;}

		/// <summary>
		///	Repository URL
		/// </summary>
		[JsonProperty(PropertyName = "RepositoryUrl")]
        public  string RepositoryUrl {get;set;}

		/// <summary>
		///	Signup date
		/// </summary>
		[JsonProperty(PropertyName = "SignupDate")]
        public  DateTime? SignupDate {get;set;}

		/// <summary>
		///	Array of objects, String represents ID and Name
		/// </summary>
		[JsonProperty(PropertyName = "Skills")]
        public  List<Skills> Skills {get;set;}

		/// <summary>
		///	Array of objects, String represents ID and Name
		/// </summary>
		[JsonProperty(PropertyName = "Sports")]
        public  List<Sports> Sports {get;set;}

		/// <summary>
		///	Git users bookmark repositories
		/// </summary>
		[JsonProperty(PropertyName = "StarredUrl")]
        public  string StarredUrl {get;set;}

		/// <summary>
		///	State of the user
		/// </summary>
		[JsonProperty(PropertyName = "State")]
        public  string State {get;set;}

		/// <summary>
		///	Object,string represents Name,Space,PrivateRepos,Collaborators
		/// </summary>
		[JsonProperty(PropertyName = "Subscription")]
        public  GitHubPlan Subscription {get;set;}

		/// <summary>
		///	Suffix for the User.
		/// </summary>
		[JsonProperty(PropertyName = "Suffix")]
        public  string Suffix {get;set;}

		/// <summary>
		///	Object,array of objects represents	CompaniestoFollow,IndustriestoFollow,NewssourcetoFollow,PeopletoFollow
		/// </summary>
		[JsonProperty(PropertyName = "Suggestions")]
        public  Suggestions Suggestions {get;set;}

		/// <summary>
		///	Tagline that need to be inserted
		/// </summary>
		[JsonProperty(PropertyName = "TagLine")]
        public  string TagLine {get;set;}

		/// <summary>
		///	Array of Objects,string represents Id,Name,Category,CreatedDate
		/// </summary>
		[JsonProperty(PropertyName = "TeleVisionShow")]
        public  List<Television> TeleVisionShow {get;set;}

		/// <summary>
		///	URL for the Thumbnail
		/// </summary>
		[JsonProperty(PropertyName = "ThumbnailImageUrl")]
        public  string ThumbnailImageUrl {get;set;}

		/// <summary>
		///	The Current Time Zone.
		/// </summary>
		[JsonProperty(PropertyName = "TimeZone")]
        public  string TimeZone {get;set;}

		/// <summary>
		///	Total Private repository
		/// </summary>
		[JsonProperty(PropertyName = "TotalPrivateRepository")]
        public  int? TotalPrivateRepository {get;set;}

		/// <summary>
		///	Count of Total status
		/// </summary>
		[JsonProperty(PropertyName = "TotalStatusesCount")]
        public  int? TotalStatusesCount {get;set;}

		/// <summary>
		///	updated date
		/// </summary>
		[JsonProperty(PropertyName = "UpdatedTime")]
        public  string UpdatedTime {get;set;}

		/// <summary>
		///	verified
		/// </summary>
		[JsonProperty(PropertyName = "Verified")]
        public  string Verified {get;set;}

		/// <summary>
		///	Array of Objects,string represents Id,Role,Organization,Cause
		/// </summary>
		[JsonProperty(PropertyName = "Volunteer")]
        public  List<Volunteer> Volunteer {get;set;}

		/// <summary>
		///	Twitter, Facebook ProfileUrls
		/// </summary>
		[JsonProperty(PropertyName = "WebProfiles")]
        public  Dictionary<string,string> WebProfiles {get;set;}

		/// <summary>
		///	Personal Website a User has
		/// </summary>
		[JsonProperty(PropertyName = "Website")]
        public  string Website {get;set;}

    }
}