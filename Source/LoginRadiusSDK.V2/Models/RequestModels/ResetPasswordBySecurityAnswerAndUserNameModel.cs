//-----------------------------------------------------------------------
// <copyright file="ModelClass" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2025 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using Newtonsoft.Json;
namespace LoginRadiusSDK.V2.Models.RequestModels

{

    /// <summary>
    ///	Model Class containing Definition of payload for ResetPasswordBySecurityAnswerAndUserName API
    /// </summary>
    public class ResetPasswordBySecurityAnswerAndUserNameModel
    {
		/// <summary>
		///	Password for the email
		/// </summary>
		[JsonProperty(PropertyName = "password")]
        public  string Password {get;set;}

		/// <summary>
		///	If you are sending an email via the sendemail parameter, this parameter allows you to specify which reset Password email template you would like to use.
		/// </summary>
		[JsonProperty(PropertyName = "ResetPasswordEmailTemplate")]
        public  string ResetPasswordEmailTemplate {get;set;}

		/// <summary>
		///	Valid JSON object of Unique Security Question ID and Answer of set Security Question. It is only required for locked accounts when logging in. Details about this feature
		/// </summary>
		[JsonProperty(PropertyName = "SecurityAnswer")]
        public  Dictionary<string,string> SecurityAnswer {get;set;}

		/// <summary>
		///	Username of the user
		/// </summary>
		[JsonProperty(PropertyName = "UserName")]
        public  string UserName {get;set;}

    }
}