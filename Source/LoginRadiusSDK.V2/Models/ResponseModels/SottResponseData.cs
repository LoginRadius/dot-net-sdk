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
    ///	Response containing Definition for Complete Sott data
    /// </summary>
    public class SottResponseData
    {
		/// <summary>
		///	Sott expiry time
		/// </summary>
		[JsonProperty(PropertyName = "ExpiryTime")]
        public  DateTime ExpiryTime {get;set;}

		/// <summary>
		///	SOTT is a secure one time token
		/// </summary>
		[JsonProperty(PropertyName = "Sott")]
        public  string Sott {get;set;}

    }
}