//-----------------------------------------------------------------------
// <copyright file="ModelClass" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2019 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace LoginRadiusSDK.V2.Models.ResponseModels

{

    /// <summary>
    ///	Response containing Definition for Complete MultiToken
    /// </summary>
    public class MultiToken
    {
		/// <summary>
		///	
		/// </summary>
		[JsonProperty(PropertyName = "ExpiresIn")]
        public  DateTime ExpiresIn {get;set;}

		/// <summary>
		///	Identity providers
		/// </summary>
		[JsonProperty(PropertyName = "IdentityProviders")]
        public  List<string> IdentityProviders {get;set;}

		/// <summary>
		///	Token
		/// </summary>
		[JsonProperty(PropertyName = "Token")]
        public string Token {get;set;}

    }
}