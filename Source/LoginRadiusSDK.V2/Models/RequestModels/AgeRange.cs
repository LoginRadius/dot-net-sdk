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
    ///	Model Class containing Definition for Age Range Property
    /// </summary>
    public class AgeRange
    {
		/// <summary>
		///	Maximum Value Range
		/// </summary>
		[JsonProperty(PropertyName = "Max")]
        public  int? Max {get;set;}

		/// <summary>
		///	Minimum Value Range
		/// </summary>
		[JsonProperty(PropertyName = "Min")]
        public  int? Min {get;set;}

    }
}