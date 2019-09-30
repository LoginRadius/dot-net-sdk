//-----------------------------------------------------------------------
// <copyright file="ModelClass" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2019 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using Newtonsoft.Json;
namespace LoginRadiusSDK.V2.Models.ResponseModels.OtherObjects

{

    /// <summary>
    ///	Response Model Class containing Definition of PIN Information
    /// </summary>
    public class PINInformation
    {
		/// <summary>
		///	Last PIN Change Date
		/// </summary>
		[JsonProperty(PropertyName = "LastPINChangeDate")]
        public  DateTime? LastPINChangeDate {get;set;}

		/// <summary>
		///	PIN of user
		/// </summary>
		[JsonProperty(PropertyName = "PIN")]
        public  string PIN {get;set;}

		/// <summary>
		///	possible values are true/false/null
		/// </summary>
		[JsonProperty(PropertyName = "Skipped")]
        public  bool? Skipped {get;set;}

		/// <summary>
		///	Skipped Date
		/// </summary>
		[JsonProperty(PropertyName = "SkippedDate")]
        public  DateTime? SkippedDate {get;set;}

    }
}