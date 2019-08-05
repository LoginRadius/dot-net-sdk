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
    ///	Response containing Definition of Token Information
    /// </summary>
    public class TokenInfoResponseModel
    {
		/// <summary>
		///	Uniquely generated identifier key by LoginRadius that is activated after successful authentication.
		/// </summary>
		[JsonProperty(PropertyName = "access_token")]
        public  Guid Access_Token {get;set;}

		/// <summary>
		///	is remember login or not
		/// </summary>
		[JsonProperty(PropertyName = "isrememberme")]
        public  bool IsRememberMe {get;set;}

		/// <summary>
		///	Name of the provider
		/// </summary>
		[JsonProperty(PropertyName = "provider")]
        public  string Provider {get;set;}

    }
}