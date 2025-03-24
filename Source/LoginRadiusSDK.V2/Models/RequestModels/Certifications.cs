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
    ///	Model Class containing Definition for Certifications Property
    /// </summary>
    public class Certifications
    {
		/// <summary>
		///	Authority of certifications
		/// </summary>
		[JsonProperty(PropertyName = "Authority")]
        public  string Authority {get;set;}

		/// <summary>
		///	Certification end date
		/// </summary>
		[JsonProperty(PropertyName = "EndDate")]
        public  string EndDate {get;set;}

		/// <summary>
		///	Certification id
		/// </summary>
		[JsonProperty(PropertyName = "Id")]
        public  string Id {get;set;}

		/// <summary>
		///	Certification name
		/// </summary>
		[JsonProperty(PropertyName = "Name")]
        public  string Name {get;set;}

		/// <summary>
		///	Certification number
		/// </summary>
		[JsonProperty(PropertyName = "Number")]
        public  string Number {get;set;}

		/// <summary>
		///	Certification start date
		/// </summary>
		[JsonProperty(PropertyName = "StartDate")]
        public  string StartDate {get;set;}

    }
}