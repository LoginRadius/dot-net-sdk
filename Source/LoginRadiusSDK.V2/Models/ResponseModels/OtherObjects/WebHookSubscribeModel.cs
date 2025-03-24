//-----------------------------------------------------------------------
// <copyright file="ModelClass" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2025 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using LoginRadiusSDK.V2.Models.ResponseModels.UserProfile.Objects;
namespace LoginRadiusSDK.V2.Models.ResponseModels.OtherObjects

    {
	
	/// <summary>
	///	Response containing Definition for Complete WebHook data
	/// </summary>
    public class WebHookSubscribeModel
    {
		/// <summary>
		///	ID of the User
		/// </summary>
		[JsonProperty(PropertyName = "Id")]
        public  string Id {get;set;}

		/// <summary>
		///	URL where trigger will send data when it invoke
		/// </summary>
		[JsonProperty(PropertyName = "TargetUrl")]
        public  string TargetUrl {get;set;}

		/// <summary>
		///	Allowed events: Login, Register, UpdateProfile, ResetPassword, ChangePassword, emailVerification, AddEmail, RemoveEmail, BlockAccount, DeleteAccount, SetUsername, AssignRoles, UnassignRoles, SetPassword, LinkAccount, UnlinkAccount, UpdatePhoneId, VerifyPhoneNumber, CreateCustomObject, UpdateCustomobject, DeleteCustomObject
		/// </summary>
		[JsonProperty(PropertyName = "Event")]
        public  string Event {get;set;}

		/// <summary>
		///	Date of Creation of Profile
		/// </summary>
		[JsonProperty(PropertyName = "CreatedDate")]
        public  DateTime CreatedDate {get;set;}

		/// <summary>
		///	LastModifiedDate value that need to be inserted
		/// </summary>
		[JsonProperty(PropertyName = "LastModifiedDate")]
        public  DateTime LastModifiedDate {get;set;}

		/// <summary>
		///	The event associated with the consent form
		/// </summary>
		[JsonProperty(PropertyName = "SecretName")]
        public  string SecretName {get;set;}

		/// <summary>
		///	Webhook Name
		/// </summary>
		[JsonProperty(PropertyName = "Name")]
        public  string Name {get;set;}

		/// <summary>
		///	The event associated with the consent form
		/// </summary>
		[JsonProperty(PropertyName = "IsIntegrationWebhook")]
        public  bool IsIntegrationWebhook {get;set;}

		/// <summary>
		///	Custom headers for the webhook
		/// </summary>
		[JsonProperty(PropertyName = "Headers")]
        public  Dictionary<string,string> Headers {get;set;}

		/// <summary>
		///	Query parameters for the webhook
		/// </summary>
		[JsonProperty(PropertyName = "QueryParams")]
        public  Dictionary<string,string> QueryParams {get;set;}

		/// <summary>
		///	Authentication details for the webhook
		/// </summary>
		[JsonProperty(PropertyName = "Authentication")]
        public  WebHookAuthentication Authentication {get;set;}

    }
}