//-----------------------------------------------------------------------
// <copyright file="ModelClass" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2019 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using Newtonsoft.Json;
namespace LoginRadiusSDK.V2.Models.RequestModels

{

    /// <summary>
    ///	Model Class containing Definition for Projects Property
    /// </summary>
    public class Projects
    {
		/// <summary>
		///	End date of the project
		/// </summary>
		[JsonProperty(PropertyName = "EndDate")]
        public  string EndDate {get;set;}

		/// <summary>
		///	Id of the project
		/// </summary>
		[JsonProperty(PropertyName = "Id")]
        public  string Id {get;set;}

		/// <summary>
		///	is current or not
		/// </summary>
		[JsonProperty(PropertyName = "IsCurrent")]
        public  string IsCurrent {get;set;}

		/// <summary>
		///	Name of the project
		/// </summary>
		[JsonProperty(PropertyName = "Name")]
        public  string Name {get;set;}

		/// <summary>
		///	Start date of the project
		/// </summary>
		[JsonProperty(PropertyName = "StartDate")]
        public  string StartDate {get;set;}

		/// <summary>
		///	Summary of the project
		/// </summary>
		[JsonProperty(PropertyName = "Summary")]
        public  string Summary {get;set;}

		/// <summary>
		///	Projects done with
		/// </summary>
		[JsonProperty(PropertyName = "With")]
        public  List<NameId> With {get;set;}

    }
}