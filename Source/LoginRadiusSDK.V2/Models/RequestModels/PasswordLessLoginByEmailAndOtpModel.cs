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
    ///	
    /// </summary>
    public class PasswordLessLoginByEmailAndOtpModel
    {
		/// <summary>
		///	
		/// </summary>
		[JsonProperty(PropertyName = "Email")]
        public  string Email {get;set;}

		/// <summary>
		///	
		/// </summary>
		[JsonProperty(PropertyName = "Otp")]
        public  string Otp {get;set;}

		/// <summary>
		///	
		/// </summary>
		[JsonProperty(PropertyName = "welcomeEmailTemplate")]
        public  string WelcomeEmailTemplate {get;set;}

    }
}