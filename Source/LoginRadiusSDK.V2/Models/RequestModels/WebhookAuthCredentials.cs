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
namespace LoginRadiusSDK.V2.Models.RequestModels

    {
	
	/// <summary>
	///	Model Class containing Definition for WebhookAuthCredentials Property
	/// </summary>
    public class WebhookAuthCredentials
    {
		/// <summary>
		///	Username of the user
		/// </summary>
		[JsonProperty(PropertyName = "Username")]
        public  string Username {get;set;}

		/// <summary>
		///	Password for the email
		/// </summary>
		[JsonProperty(PropertyName = "Password")]
        public  string Password {get;set;}

    }
}