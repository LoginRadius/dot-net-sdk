//-----------------------------------------------------------------------
// <copyright file="ModelClass" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2019 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using Newtonsoft.Json;
namespace LoginRadiusSDK.V2.Models.RequestModels

{

    /// <summary>
    ///	Model Class containing Definition of payload for ResetPasswordBySecurityAnswerAndEmail API
    /// </summary>
    public class ResetPasswordBySecurityAnswerAndEmailModel
    {
		/// <summary>
		///	LoginRadius user identifier (if phone no login then phone no and if email login then email id)
		/// </summary>
		[JsonProperty(PropertyName = "Email")]
        public  string Email {get;set;}

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

    }
}