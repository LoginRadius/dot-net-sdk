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
    ///	Response containing Definition for Complete PlacesLived data
    /// </summary>
    public class PlacesLived
    {
		/// <summary>
		///	place is primary or not
		/// </summary>
		[JsonProperty(PropertyName = "IsPrimary")]
        public  bool? IsPrimary {get;set;}

		/// <summary>
		///	Name of lived place
		/// </summary>
		[JsonProperty(PropertyName = "Name")]
        public  string Name {get;set;}

    }
}