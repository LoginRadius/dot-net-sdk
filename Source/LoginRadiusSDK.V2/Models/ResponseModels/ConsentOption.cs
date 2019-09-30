//-----------------------------------------------------------------------
// <copyright file="ModelClass" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2019 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using Newtonsoft.Json;
namespace LoginRadiusSDK.V2.Models.ResponseModels

{

    /// <summary>
    ///	Response containing consent information
    /// </summary>
    public class ConsentOption
    {
		/// <summary>
		///	Consent Accept on Date
		/// </summary>
		[JsonProperty(PropertyName = "AcceptOnDate")]
        public  DateTime? AcceptOnDate {get;set;}

		/// <summary>
		///	Consent Option Id
		/// </summary>
		[JsonProperty(PropertyName = "ConsentOptionId")]
        public  string ConsentOptionId {get;set;}

    }
}