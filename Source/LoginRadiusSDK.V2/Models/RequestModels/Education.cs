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
    ///	Model Class containing Definition for Education Property
    /// </summary>
    public class Education
    {
		/// <summary>
		///	Activities
		/// </summary>
		[JsonProperty(PropertyName = "activities")]
        public  string Activities {get;set;}

		/// <summary>
		///	Degree
		/// </summary>
		[JsonProperty(PropertyName = "degree")]
        public  string Degree {get;set;}

		/// <summary>
		///	Education End Date
		/// </summary>
		[JsonProperty(PropertyName = "EndDate")]
        public  string EndDate {get;set;}

		/// <summary>
		///	Fields of study
		/// </summary>
		[JsonProperty(PropertyName = "fieldofstudy")]
        public  string Fieldofstudy {get;set;}

		/// <summary>
		///	Notes
		/// </summary>
		[JsonProperty(PropertyName = "notes")]
        public  string Notes {get;set;}

		/// <summary>
		///	School of the user
		/// </summary>
		[JsonProperty(PropertyName = "School")]
        public  string School {get;set;}

		/// <summary>
		///	Start date of Education of user
		/// </summary>
		[JsonProperty(PropertyName = "StartDate")]
        public  string StartDate {get;set;}

		/// <summary>
		///	Type
		/// </summary>
		[JsonProperty(PropertyName = "type")]
        public  string Type {get;set;}

		/// <summary>
		///	Year of Education
		/// </summary>
		[JsonProperty(PropertyName = "year")]
        public  string Year {get;set;}

    }
}