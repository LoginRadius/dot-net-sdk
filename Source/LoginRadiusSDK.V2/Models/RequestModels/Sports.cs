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
    ///	Model Class containing Definition of payload for Sports Property
    /// </summary>
    public class Sports
    {
		/// <summary>
		///	Id of sport
		/// </summary>
		[JsonProperty(PropertyName = "Id")]
        public  string Id {get;set;}

		/// <summary>
		///	Name of sport
		/// </summary>
		[JsonProperty(PropertyName = "Name")]
        public  string Name {get;set;}

    }
}