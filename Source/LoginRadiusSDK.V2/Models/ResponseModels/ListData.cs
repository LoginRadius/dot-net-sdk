//-----------------------------------------------------------------------
// <copyright file="ModelClass" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2019 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using Newtonsoft.Json;
namespace LoginRadiusSDK.V2.Models.ResponseModels

{

    /// <summary>
    ///	Response containing Definition of Complete List data
    /// </summary>
    public class ListData<T>
    {
		/// <summary>
		///	count
		/// </summary>
		[JsonProperty(PropertyName = "Count")]
        public  int Count {get;set;}

		/// <summary>
		///	Data
		/// </summary>
		[JsonProperty(PropertyName = "data")]
        public  List<T> Data {get;set;}

    }
}