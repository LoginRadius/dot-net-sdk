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
	///	WebhookBearerToken for authentication
	/// </summary>
    public class WebhookBearerToken
    {
		/// <summary>
		///	Bearer Token for Webhook authentication
		/// </summary>
		[JsonProperty(PropertyName = "Token")]
        public  string Token {get;set;}

    }
}