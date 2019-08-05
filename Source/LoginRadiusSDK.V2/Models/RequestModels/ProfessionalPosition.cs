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
    ///	Model Class containing Definition for ProfessionalPosition Property
    /// </summary>
    public class ProfessionalPosition
    {
		/// <summary>
		///	Company of the professional position
		/// </summary>
		[JsonProperty(PropertyName = "Company")]
        public  PositionCompany Company {get;set;}

		/// <summary>
		///	End date of the professional position
		/// </summary>
		[JsonProperty(PropertyName = "EndDate")]
        public  string EndDate {get;set;}

		/// <summary>
		///	Is current or not
		/// </summary>
		[JsonProperty(PropertyName = "IsCurrent")]
        public  string IsCurrent {get;set;}

		/// <summary>
		///	Location of the professional position
		/// </summary>
		[JsonProperty(PropertyName = "Location")]
        public  string Location {get;set;}

		/// <summary>
		///	Position
		/// </summary>
		[JsonProperty(PropertyName = "Position")]
        public  string Position {get;set;}

		/// <summary>
		///	Start date of the professional position
		/// </summary>
		[JsonProperty(PropertyName = "StartDate")]
        public  string StartDate {get;set;}

		/// <summary>
		///	Summary of the professional position
		/// </summary>
		[JsonProperty(PropertyName = "Summary")]
        public  string Summary {get;set;}

    }
}