//-----------------------------------------------------------------------
// <copyright file="ModelClass" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2019 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Newtonsoft.Json;
namespace LoginRadiusSDK.V2.Models.ResponseModels

{

    /// <summary>
    ///	Response containing Definition for Complete status data
    /// </summary>
    public class StatusUpdateResponse
    {
		/// <summary>
		///	Status id
		/// </summary>
		[JsonProperty(PropertyName = "Id")]
        public  string Id {get;set;}

		/// <summary>
		///	String represents website url
		/// </summary>
		[JsonProperty(PropertyName = "Url")]
        public  ShortUrlResponse Url {get;set;}

    }
}