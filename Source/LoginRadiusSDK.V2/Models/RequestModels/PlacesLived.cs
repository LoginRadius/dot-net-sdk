//-----------------------------------------------------------------------
// <copyright file="ModelClass" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2019 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Newtonsoft.Json;
using LoginRadiusSDK.V2.Models.Enums;
namespace LoginRadiusSDK.V2.Models.RequestModels

{

    /// <summary>
    ///	Model Class containing Definition for PlacesLived Property
    /// </summary>
    public class PlacesLived
    {
		/// <summary>
		///	place is primary or not
		/// </summary>
		[JsonProperty(PropertyName = "IsPrimary")]
        public  bool? IsPrimary {get;set;}

		/// <summary>
		///	Name of lived place
		/// </summary>
		[JsonProperty(PropertyName = "Name")]
        public  string Name {get;set;}

		/// <summary>
		///	Places Lived Operation type
		/// </summary>
		[JsonProperty(PropertyName = "op")]
        public  OperationType? Op {get;set;}

    }
}