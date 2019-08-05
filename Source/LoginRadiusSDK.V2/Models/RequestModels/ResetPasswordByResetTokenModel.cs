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
    ///	Model Class containing Definition of payload for ResetToken API
    /// </summary>
    public class ResetPasswordByResetTokenModel:LockoutModel
    {
		/// <summary>
		///	Password for the email
		/// </summary>
		[JsonProperty(PropertyName = "Password")]
        public  string Password {get;set;}

		/// <summary>
		///	If you are sending an email via the sendemail parameter, this parameter allows you to specify which reset Password email template you would like to use.
		/// </summary>
		[JsonProperty(PropertyName = "ResetPasswordEmailTemplate")]
        public  string ResetPasswordEmailTemplate {get;set;}

		/// <summary>
		///	reset token received in the email
		/// </summary>
		[JsonProperty(PropertyName = "ResetToken")]
        public  string ResetToken {get;set;}

		/// <summary>
		///	If you are sending an email via the sendemail parameter, this parameter allows you to specify which welcome email template you would like to use.
		/// </summary>
		[JsonProperty(PropertyName = "WelcomeEmailTemplate")]
        public  string WelcomeEmailTemplate {get;set;}

    }
}