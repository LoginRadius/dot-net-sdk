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
using LoginRadiusSDK.V2.Models.RequestModels;
namespace LoginRadiusSDK.V2.Models.RequestModels

    {
	
	/// <summary>
	///	Model Class containing Definition for WebHookSubscriptionUpdateModel Property
	/// </summary>
    public class WebHookSubscriptionUpdateModel
    {
		/// <summary>
		///	Custom headers for the webhook
		/// </summary>
		[JsonProperty(PropertyName = "Headers")]
        public  Dictionary<string,string> Headers {get;set;}

		/// <summary>
		///	Query parameters for the webhook
		/// </summary>
		[JsonProperty(PropertyName = "QueryParams")]
        public  Dictionary<string,string> QueryParams {get;set;}

		/// <summary>
		///	Authentication details for the webhook
		/// </summary>
		[JsonProperty(PropertyName = "Authentication")]
        public  WebhookAuthenticationModel Authentication {get;set;}

    }
}