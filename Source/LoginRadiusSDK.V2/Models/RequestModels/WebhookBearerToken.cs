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
	///	Model Class containing Definition for WebhookBearerToken Property
	/// </summary>
    public class WebhookBearerToken
    {
		/// <summary>
		///	Webhook Bearer Token
		/// </summary>
		[JsonProperty(PropertyName = "Token")]
        public  string Token {get;set;}

    }
}