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
    ///	Response containing Definition for Complete Interests data
    /// </summary>
    public class Interests
    {
		/// <summary>
		///	Name of interested
		/// </summary>
		[JsonProperty(PropertyName = "InterestedName")]
        public  string InterestedName {get;set;}

		/// <summary>
		///	Type of interested
		/// </summary>
		[JsonProperty(PropertyName = "InterestedType")]
        public  string InterestedType {get;set;}

    }
}