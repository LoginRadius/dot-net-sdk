//-----------------------------------------------------------------------
// <copyright file="ModelClass" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2025 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Newtonsoft.Json;
namespace LoginRadiusSDK.V2.Models.RequestModels

{

    /// <summary>
    ///	Model Class containing Definition for FavoriteThings Property
    /// </summary>
    public class FavoriteThings
    {
		/// <summary>
		///	Id of favorite things
		/// </summary>
		[JsonProperty(PropertyName = "Id")]
        public  string Id {get;set;}

		/// <summary>
		///	Name of favorite things
		/// </summary>
		[JsonProperty(PropertyName = "Name")]
        public  string Name {get;set;}

		/// <summary>
		///	Type of favorite things
		/// </summary>
		[JsonProperty(PropertyName = "Type")]
        public  string Type {get;set;}

    }
}