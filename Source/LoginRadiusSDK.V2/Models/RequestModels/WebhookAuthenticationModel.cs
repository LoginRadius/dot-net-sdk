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
	///	Model Class containing Definition for WebhookAuthenticationModel Property
	/// </summary>
    public class WebhookAuthenticationModel
    {
		/// <summary>
		///	Webhook Authentication Type
		/// </summary>
		[JsonProperty(PropertyName = "AuthType")]
        public  string AuthType {get;set;}

		/// <summary>
		///	Webhook Basic Authentication
		/// </summary>
		[JsonProperty(PropertyName = "BasicAuth")]
        public  WebhookAuthCredentials BasicAuth {get;set;}

		/// <summary>
		///	Bearer Token for authentication
		/// </summary>
		[JsonProperty(PropertyName = "BearerToken")]
        public  WebhookBearerToken BearerToken {get;set;}

    }
}