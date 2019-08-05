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
    ///	Model Class containing Definition of payload for PhoneAuthenticationModel API
    /// </summary>
    public class PhoneAuthenticationModel:ReCaptchaModel
    {
		/// <summary>
		///	Password for the email
		/// </summary>
		[JsonProperty(PropertyName = "password")]
        public  string Password {get;set;}

		/// <summary>
		///	New Phone Number
		/// </summary>
		[JsonProperty(PropertyName = "phone")]
        public  string Phone {get;set;}

		/// <summary>
		///	Valid JSON object of Unique Security Question ID and Answer of set Security Question. It is only required for locked accounts when logging in. Details about this feature
		/// </summary>
		[JsonProperty(PropertyName = "SecurityAnswer")]
        public  Dictionary<string,string> SecurityAnswer {get;set;}

    }
}