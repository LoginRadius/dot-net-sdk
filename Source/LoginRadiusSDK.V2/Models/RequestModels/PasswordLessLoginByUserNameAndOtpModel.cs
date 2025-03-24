//-----------------------------------------------------------------------
// <copyright file="ModelClass" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2025 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Newtonsoft.Json;
namespace LoginRadiusSDK.V2.Models.RequestModels

{

    /// <summary>
    ///	
    /// </summary>
    public class PasswordLessLoginByUserNameAndOtpModel
    {
		/// <summary>
		///	
		/// </summary>
		[JsonProperty(PropertyName = "Otp")]
        public  string Otp {get;set;}

		/// <summary>
		///	
		/// </summary>
		[JsonProperty(PropertyName = "UserName")]
        public  string UserName {get;set;}

		/// <summary>
		///	
		/// </summary>
		[JsonProperty(PropertyName = "welcomeEmailTemplate")]
        public  string WelcomeEmailTemplate {get;set;}

    }
}