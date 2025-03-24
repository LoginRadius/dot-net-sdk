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
    ///	Model Class containing Definition of payload for PasswordLessLoginOtpModel API
    /// </summary>
    public class PasswordLessLoginOtpModel:LockoutModel
    {
		/// <summary>
		///	The Verification Code
		/// </summary>
		[JsonProperty(PropertyName = "Otp")]
        public  string Otp {get;set;}

		/// <summary>
		///	New Phone Number
		/// </summary>
		[JsonProperty(PropertyName = "Phone")]
        public  string Phone {get;set;}

    }
}