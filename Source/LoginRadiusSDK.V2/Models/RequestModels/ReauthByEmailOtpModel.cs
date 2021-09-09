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
    public class ReauthByEmailOtpModel:LockoutModel
    {
		/// <summary>
		///	
		/// </summary>
		[JsonProperty(PropertyName = "EmailId")]
        public  string EmailId {get;set;}

		/// <summary>
		///	
		/// </summary>
		[JsonProperty(PropertyName = "Otp")]
        public  string Otp {get;set;}

    }
}