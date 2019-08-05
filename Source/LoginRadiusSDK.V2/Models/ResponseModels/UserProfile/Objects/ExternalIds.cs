//-----------------------------------------------------------------------
// <copyright file="ModelClass" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2019 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Newtonsoft.Json;
namespace LoginRadiusSDK.V2.Models.ResponseModels.UserProfile.Objects

{

    /// <summary>
    ///	Response containing Definition for Complete Externalids data
    /// </summary>
    public class ExternalIds
    {
		/// <summary>
		///	ExternalId source
		/// </summary>
		[JsonProperty(PropertyName = "Source")]
        public  string Source {get;set;}

		/// <summary>
		///	External source id
		/// </summary>
		[JsonProperty(PropertyName = "SourceId")]
        public  string SourceId {get;set;}

    }
}