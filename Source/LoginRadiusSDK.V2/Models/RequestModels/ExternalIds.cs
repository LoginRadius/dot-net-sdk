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
    ///	Model Class containing Definition for Externallds Property
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