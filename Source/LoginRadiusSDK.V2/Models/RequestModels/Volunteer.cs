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
    ///	Model Class containing Definition for Volunteer Property
    /// </summary>
    public class Volunteer
    {
		/// <summary>
		///	Cause of volunteer
		/// </summary>
		[JsonProperty(PropertyName = "Cause")]
        public  string Cause {get;set;}

		/// <summary>
		///	Volunteer Id
		/// </summary>
		[JsonProperty(PropertyName = "Id")]
        public  string Id {get;set;}

		/// <summary>
		///	Volunteer organization
		/// </summary>
		[JsonProperty(PropertyName = "Organization")]
        public  string Organization {get;set;}

		/// <summary>
		///	Volunteer role
		/// </summary>
		[JsonProperty(PropertyName = "Role")]
        public  string Role {get;set;}

    }
}