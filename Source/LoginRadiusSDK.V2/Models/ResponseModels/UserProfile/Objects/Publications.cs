//-----------------------------------------------------------------------
// <copyright file="ModelClass" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2019 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using Newtonsoft.Json;
namespace LoginRadiusSDK.V2.Models.ResponseModels.UserProfile.Objects

{

    /// <summary>
    ///	Response containing Definition for Complete Publications data
    /// </summary>
    public class Publications
    {
		/// <summary>
		///	Author of the publication
		/// </summary>
		[JsonProperty(PropertyName = "Authors")]
        public  List<PublicationsAuthors> Authors {get;set;}

		/// <summary>
		///	Date of the publication
		/// </summary>
		[JsonProperty(PropertyName = "Date")]
        public  string Date {get;set;}

		/// <summary>
		///	Id of the Publication
		/// </summary>
		[JsonProperty(PropertyName = "Id")]
        public  string Id {get;set;}

		/// <summary>
		///	Publisher of the Publication
		/// </summary>
		[JsonProperty(PropertyName = "Publisher")]
        public  string Publisher {get;set;}

		/// <summary>
		///	Summary of the publication
		/// </summary>
		[JsonProperty(PropertyName = "Summary")]
        public  string Summary {get;set;}

		/// <summary>
		///	Title of the publication
		/// </summary>
		[JsonProperty(PropertyName = "Title")]
        public  string Title {get;set;}

		/// <summary>
		///	Publication url
		/// </summary>
		[JsonProperty(PropertyName = "Url")]
        public  string Url {get;set;}

    }
}