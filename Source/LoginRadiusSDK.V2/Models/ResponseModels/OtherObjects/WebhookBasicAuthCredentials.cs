//-----------------------------------------------------------------------
// <copyright file="ModelClass" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2025 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using LoginRadiusSDK.V2.Models.ResponseModels.UserProfile.Objects;
namespace LoginRadiusSDK.V2.Models.ResponseModels.OtherObjects

    {
	
	/// <summary>
	///	Credentials for basic authentication
	/// </summary>
    public class WebhookBasicAuthCredentials
    {
		/// <summary>
		///	Username for basic authentication
		/// </summary>
		[JsonProperty(PropertyName = "Username")]
        public  string Username {get;set;}

		/// <summary>
		///	Password for basic authentication
		/// </summary>
		[JsonProperty(PropertyName = "Password")]
        public  string Password {get;set;}

    }
}