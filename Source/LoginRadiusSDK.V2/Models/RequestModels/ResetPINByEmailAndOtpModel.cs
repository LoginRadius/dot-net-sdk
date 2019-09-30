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
    ///	Model Class containing Definition of payload for Reset Pin By Email and Otp API
    /// </summary>
    public class ResetPINByEmailAndOtpModel:LockoutModel
    {
		/// <summary>
		///	user's email
		/// </summary>
		[JsonProperty(PropertyName = "Email")]
        public  string Email {get;set;}

		/// <summary>
		///	The Verification Code
		/// </summary>
		[JsonProperty(PropertyName = "Otp")]
        public  string Otp {get;set;}

		/// <summary>
		///	PIN of user
		/// </summary>
		[JsonProperty(PropertyName = "PIN")]
        public  string PIN {get;set;}

    }
}