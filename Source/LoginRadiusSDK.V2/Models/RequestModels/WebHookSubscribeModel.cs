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

    }
}