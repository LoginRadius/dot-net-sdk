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
    ///	Response containing Definition for Complete Movies data
    /// </summary>
    public class Movies
    {
		/// <summary>
		///	Category of movie
		/// </summary>
		[JsonProperty(PropertyName = "Category")]
        public  string Category {get;set;}

		/// <summary>
		///	Movie created date
		/// </summary>
		[JsonProperty(PropertyName = "CreatedDate")]
        public  string CreatedDate {get;set;}

		/// <summary>
		///	Id of movie
		/// </summary>
		[JsonProperty(PropertyName = "Id")]
        public  string Id {get;set;}

		/// <summary>
		///	Name of movie
		/// </summary>
		[JsonProperty(PropertyName = "Name")]
        public  string Name {get;set;}

    }
}