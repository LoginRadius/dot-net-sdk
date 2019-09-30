//-----------------------------------------------------------------------
// <copyright file="ModelClass" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2019 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Newtonsoft.Json;
namespace LoginRadiusSDK.V2.Models.ResponseModels

{

    /// <summary>
    ///	Response containing consent version information
    /// </summary>
    public class ConsentVersions
    {
		/// <summary>
		///	Allowed events: Login, Register, UpdateProfile, ResetPassword, ChangePassword, emailVerification, AddEmail, RemoveEmail, BlockAccount, DeleteAccount, SetUsername, AssignRoles, UnassignRoles, SetPassword, LinkAccount, UnlinkAccount, UpdatePhoneId, VerifyPhoneNumber, CreateCustomObject, UpdateCustomobject, DeleteCustomObject
		/// </summary>
		[JsonProperty(PropertyName = "Event")]
        public  string Event {get;set;}

		/// <summary>
		///	true/false
		/// </summary>
		[JsonProperty(PropertyName = "IsCustom")]
        public  bool? IsCustom {get;set;}

		/// <summary>
		///	privacy policy version
		/// </summary>
		[JsonProperty(PropertyName = "Version")]
        public  int? Version {get;set;}

    }
}