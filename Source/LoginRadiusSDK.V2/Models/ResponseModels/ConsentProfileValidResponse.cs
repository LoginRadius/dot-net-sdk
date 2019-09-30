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
    ///	Response containing consent profile
    /// </summary>
    public class ConsentProfileValidResponse
    {
		/// <summary>
		///	Consent Profile
		/// </summary>
		[JsonProperty(PropertyName = "ConsentProfile")]
        public  ConsentProfile ConsentProfile {get;set;}

		/// <summary>
		///	check data is validate
		/// </summary>
		[JsonProperty(PropertyName = "IsValid")]
        public  bool IsValid {get;set;}

    }
}