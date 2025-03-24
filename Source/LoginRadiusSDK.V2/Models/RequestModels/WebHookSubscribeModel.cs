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
using LoginRadiusSDK.V2.Models.RequestModels;
namespace LoginRadiusSDK.V2.Models.RequestModels

    {
	
	/// <summary>
	///	Model Class containing Definition of payload for Webhook Subscribe API
	/// </summary>
    public class WebHookSubscribeModel
    {
		/// <summary>
		///	Allowed events: Login, Register, UpdateProfile, ResetPassword, ChangePassword, emailVerification, AddEmail, RemoveEmail, BlockAccount, DeleteAccount, SetUsername, AssignRoles, UnassignRoles, SetPassword, LinkAccount, UnlinkAccount, UpdatePhoneId, VerifyPhoneNumber, CreateCustomObject, UpdateCustomobject, DeleteCustomObject
		/// </summary>
		[JsonProperty(PropertyName = "Event")]
        public  string Event {get;set;}

		/// <summary>
		///	URL where trigger will send data when it invoke
		/// </summary>
		[JsonProperty(PropertyName = "TargetUrl")]
        public  string TargetUrl {get;set;}

		/// <summary>
		///	Name of the customer
		/// </summary>
		[JsonProperty(PropertyName = "Name")]
        public  string Name {get;set;}

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
        public  WebhookAuthenticationModel Authentication {get;set;}

    }
}