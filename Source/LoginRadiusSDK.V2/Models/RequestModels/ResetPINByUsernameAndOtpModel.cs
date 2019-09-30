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
    ///	Model Class containing Definition of payload for Reset Pin By Username and Otp API
    /// </summary>
    public class ResetPINByUsernameAndOtpModel:LockoutModel
    {
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

		/// <summary>
		///	Username of the user
		/// </summary>
		[JsonProperty(PropertyName = "Username")]
        public  string Username {get;set;}

    }
}