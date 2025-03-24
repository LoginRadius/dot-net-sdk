//-----------------------------------------------------------------------
// <copyright file="ModelClass" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2025 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Newtonsoft.Json;
namespace LoginRadiusSDK.V2.Models.ResponseModels.UserProfile.Objects

{

    /// <summary>
    ///	Response containing Definition for Complete Country data
    /// </summary>
    public class Country
    {
		/// <summary>
		///	Country code
		/// </summary>
		[JsonProperty(PropertyName = "Code")]
        public  string Code {get;set;}

		/// <summary>
		///	Country name
		/// </summary>
		[JsonProperty(PropertyName = "Name")]
        public  string Name {get;set;}

    }
}