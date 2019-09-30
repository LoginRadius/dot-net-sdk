//-----------------------------------------------------------------------
// <copyright file="ModelClass" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2019 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Newtonsoft.Json;
namespace LoginRadiusSDK.V2.Models.RequestModels

{

    /// <summary>
    ///	Model Class containing Definition of payload for Account Update API
    /// </summary>
    public class AccountUserProfileUpdateModel:UserProfileUpdateModel
    {
		/// <summary>
		///	To disable traditional login for user
		/// </summary>
		[JsonProperty(PropertyName = "DisableLogin")]
        public  bool? DisableLogin {get;set;}

		/// <summary>
		///	boolean type value, default is true
		/// </summary>
		[JsonProperty(PropertyName = "EmailVerified")]
        public  bool? EmailVerified {get;set;}

		/// <summary>
		///	boolean type value, default is true
		/// </summary>
		[JsonProperty(PropertyName = "IsActive")]
        public  bool? IsActive {get;set;}

		/// <summary>
		///	boolean type value, default is true
		/// </summary>
		[JsonProperty(PropertyName = "IsDeleted")]
        public  bool? IsDeleted {get;set;}

		/// <summary>
		///	Pass true if wants to lock the user's Login field else false.
		/// </summary>
		[JsonProperty(PropertyName = "IsLoginLocked")]
        public  bool? IsLoginLocked {get;set;}

		/// <summary>
		///	boolean type value, default is false
		/// </summary>
		[JsonProperty(PropertyName = "PhoneIdVerified")]
        public  bool? PhoneIdVerified {get;set;}

		/// <summary>
		///	Object type by default false, string represents Version, AcceptSource and datetime represents AcceptDateTime
		/// </summary>
		[JsonProperty(PropertyName = "PrivacyPolicy")]
        public  PrivacyPolicy PrivacyPolicy {get;set;}

		/// <summary>
		///	URL of the webproperty from where the user is registered.
		/// </summary>
		[JsonProperty(PropertyName = "RegistrationSource")]
        public  string RegistrationSource {get;set;}

    }
}