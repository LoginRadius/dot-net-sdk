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
using LoginRadiusSDK.V2.Models.ResponseModels.OtherObjects;
namespace LoginRadiusSDK.V2.Models.ResponseModels.UserProfile

{

    /// <summary>
    ///	Response containing Definition for Complete UserProfile data
    /// </summary>
    public class UserProfile:SocialUserProfile
    {
		/// <summary>
		///	Response containing consent profile
		/// </summary>
		[JsonProperty(PropertyName = "ConsentProfile")]
        public  ConsentProfile ConsentProfile {get;set;}

		/// <summary>
		///	Custom fields as user set on LoginRadius Admin Console.
		/// </summary>
		[JsonProperty(PropertyName = "CustomFields")]
        public  Dictionary<string,string> CustomFields {get;set;}

		/// <summary>
		///	boolean type value, default is true
		/// </summary>
		[JsonProperty(PropertyName = "EmailVerified")]
        public  bool? EmailVerified {get;set;}

		/// <summary>
		///	Array of Objects,string represents SourceId,Source
		/// </summary>
		[JsonProperty(PropertyName = "ExternalIds")]
        public  List<ExternalIds> ExternalIds {get;set;}

		/// <summary>
		///	External User Login Id
		/// </summary>
		[JsonProperty(PropertyName = "ExternalUserLoginId")]
        public  string ExternalUserLoginId {get;set;}

		/// <summary>
		///	boolean type value, default is true
		/// </summary>
		[JsonProperty(PropertyName = "IsActive")]
        public  bool? IsActive {get;set;}

		/// <summary>
		///	id is custom of not
		/// </summary>
		[JsonProperty(PropertyName = "IsCustomUid")]
        public  bool? IsCustomUid {get;set;}

		/// <summary>
		///	boolean type value, default is true
		/// </summary>
		[JsonProperty(PropertyName = "IsDeleted")]
        public  bool? IsDeleted {get;set;}

		/// <summary>
		///	boolean type value, default is true
		/// </summary>
		[JsonProperty(PropertyName = "IsEmailSubscribed")]
        public  bool? IsEmailSubscribed {get;set;}

		/// <summary>
		///	Pass true if wants to lock the user's Login field else false.
		/// </summary>
		[JsonProperty(PropertyName = "IsLoginLocked")]
        public  bool? IsLoginLocked {get;set;}

		/// <summary>
		///	Required fields filled once or not
		/// </summary>
		[JsonProperty(PropertyName = "IsRequiredFieldsFilledOnce")]
        public  bool? IsRequiredFieldsFilledOnce {get;set;}

		/// <summary>
		///	Is secure password or not
		/// </summary>
		[JsonProperty(PropertyName = "IsSecurePassword")]
        public  bool? IsSecurePassword {get;set;}

		/// <summary>
		///	Last login location
		/// </summary>
		[JsonProperty(PropertyName = "LastLoginLocation")]
        public  string LastLoginLocation {get;set;}

		/// <summary>
		///	Last password change date
		/// </summary>
		[JsonProperty(PropertyName = "LastPasswordChangeDate")]
        public  DateTime? LastPasswordChangeDate {get;set;}

		/// <summary>
		///	Last password change token
		/// </summary>
		[JsonProperty(PropertyName = "LastPasswordChangeToken")]
        public  string LastPasswordChangeToken {get;set;}

		/// <summary>
		///	Type of Lockout
		/// </summary>
		[JsonProperty(PropertyName = "LoginLockedType")]
        public  string LoginLockedType {get;set;}

		/// <summary>
		///	Number of Logins
		/// </summary>
		[JsonProperty(PropertyName = "NoOfLogins")]
        public  int? NoOfLogins {get;set;}

		/// <summary>
		///	Password for the email
		/// </summary>
		[JsonProperty(PropertyName = "Password")]
        public  string Password {get;set;}

		/// <summary>
		///	Date of password expiration
		/// </summary>
		[JsonProperty(PropertyName = "PasswordExpirationDate")]
        public  DateTime? PasswordExpirationDate {get;set;}

		/// <summary>
		///	Phone ID (Unique Phone Number Identifier of the user)
		/// </summary>
		[JsonProperty(PropertyName = "PhoneId")]
        public  string PhoneId {get;set;}

		/// <summary>
		///	boolean type value, default is false
		/// </summary>
		[JsonProperty(PropertyName = "PhoneIdVerified")]
        public  bool? PhoneIdVerified {get;set;}

		/// <summary>
		///	PIN of user
		/// </summary>
		[JsonProperty(PropertyName = "PIN")]
        public  PINInformation PIN {get;set;}

		/// <summary>
		///	Object type by default false, string represents Version, AcceptSource and datetime represents AcceptDateTime
		/// </summary>
		[JsonProperty(PropertyName = "PrivacyPolicy")]
        public  AcceptedPrivacyPolicy PrivacyPolicy {get;set;}

		/// <summary>
		///	User Registartion Data
		/// </summary>
		[JsonProperty(PropertyName = "RegistrationData")]
        public  RegistrationData RegistrationData {get;set;}

		/// <summary>
		///	Provider with which user registered
		/// </summary>
		[JsonProperty(PropertyName = "RegistrationProvider")]
        public  string RegistrationProvider {get;set;}

		/// <summary>
		///	URL of the webproperty from where the user is registered.
		/// </summary>
		[JsonProperty(PropertyName = "RegistrationSource")]
        public  string RegistrationSource {get;set;}

		/// <summary>
		///	
		/// </summary>
		[JsonProperty(PropertyName = "Roles")]
        public  List<string> Roles {get;set;}

		/// <summary>
		///	UID, the unified identifier for each user account
		/// </summary>
		[JsonProperty(PropertyName = "Uid")]
        public  string Uid {get;set;}

		/// <summary>
		///	Unverified Email Address
		/// </summary>
		[JsonProperty(PropertyName = "UnverifiedEmail")]
        public  List<Email> UnverifiedEmail {get;set;}

		/// <summary>
		///	Username of the user
		/// </summary>
		[JsonProperty(PropertyName = "UserName")]
        public  string UserName {get;set;}

    }
}