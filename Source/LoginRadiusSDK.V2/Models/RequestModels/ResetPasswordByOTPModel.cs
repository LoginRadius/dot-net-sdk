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
    ///	Model Class containing Definition of payload for ResetPasswordByOTP API
    /// </summary>
    public class ResetPasswordByOTPModel:LockoutModel
    {
		/// <summary>
		///	The Verification Code
		/// </summary>
		[JsonProperty(PropertyName = "otp")]
        public  string Otp {get;set;}

		/// <summary>
		///	Password for the email
		/// </summary>
		[JsonProperty(PropertyName = "password")]
        public  string Password {get;set;}

		/// <summary>
		///	New Phone Number
		/// </summary>
		[JsonProperty(PropertyName = "Phone")]
        public  string Phone {get;set;}

		/// <summary>
		///	If you are sending an sms via the sendsms parameter, this parameter allows you to specify which reset password sms  template you would like to use.
		/// </summary>
		[JsonProperty(PropertyName = "ResetPasswordSmsTemplate")]
        public  string ResetPasswordSmsTemplate {get;set;}

		/// <summary>
		///	SMS template name
		/// </summary>
		[JsonProperty(PropertyName = "smsTemplate")]
        public  string SmsTemplate {get;set;}

    }
}