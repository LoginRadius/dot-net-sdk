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
    ///	Model Class containing Definition of payload for ResetPasswordByUserName API
    /// </summary>
    public class ResetPasswordByUserNameModel:LockoutModel
    {
		/// <summary>
		///	The Verification Code
		/// </summary>
		[JsonProperty(PropertyName = "Otp")]
        public  string Otp {get;set;}

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
		///	Username of the user
		/// </summary>
		[JsonProperty(PropertyName = "UserName")]
        public  string UserName {get;set;}

		/// <summary>
		///	If you are sending an email via the sendemail parameter, this parameter allows you to specify which welcome email template you would like to use.
		/// </summary>
		[JsonProperty(PropertyName = "WelcomeEmailTemplate")]
        public  string WelcomeEmailTemplate {get;set;}

    }
}