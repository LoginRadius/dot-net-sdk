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
    ///	Response containing Definition for Complete Books data
    /// </summary>
    public class Books
    {
		/// <summary>
		///	Book category
		/// </summary>
		[JsonProperty(PropertyName = "Category")]
        public  string Category {get;set;}

		/// <summary>
		///	Date of Creation of Profile
		/// </summary>
		[JsonProperty(PropertyName = "CreatedDate")]
        public  string CreatedDate {get;set;}

		/// <summary>
		///	Id of book
		/// </summary>
		[JsonProperty(PropertyName = "Id")]
        public  string Id {get;set;}

		/// <summary>
		///	book name
		/// </summary>
		[JsonProperty(PropertyName = "Name")]
        public  string Name {get;set;}

    }
}