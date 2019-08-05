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
    ///	Model Class containing Definition for Job Property
    /// </summary>
    public class Job
    {
		/// <summary>
		///	Is active or not
		/// </summary>
		[JsonProperty(PropertyName = "Active")]
        public  bool? Active {get;set;}

		/// <summary>
		///	Job company
		/// </summary>
		[JsonProperty(PropertyName = "Company")]
        public  JobBookmarkCompany Company {get;set;}

		/// <summary>
		///	Job description
		/// </summary>
		[JsonProperty(PropertyName = "DescriptionSnippet")]
        public  string DescriptionSnippet {get;set;}

		/// <summary>
		///	Job id
		/// </summary>
		[JsonProperty(PropertyName = "Id")]
        public  string Id {get;set;}

		/// <summary>
		///	Position of job
		/// </summary>
		[JsonProperty(PropertyName = "Position")]
        public  JobBookmarkPosition Position {get;set;}

		/// <summary>
		///	Job posting timestamp
		/// </summary>
		[JsonProperty(PropertyName = "PostingTimestamp")]
        public  string PostingTimestamp {get;set;}

    }
}