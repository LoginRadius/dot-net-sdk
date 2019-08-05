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
    ///	Response containing Definition for Complete MFAuthentication Token
    /// </summary>
    public class MultiFactorAuthenticationToken:MultiFactorAuthenticationSettingsResponse
    {
		/// <summary>
		///	Expiration time of Access Token
		/// </summary>
		[JsonProperty(PropertyName = "ExpireIn")]
        public  DateTime ExpireIn {get;set;}

		/// <summary>
		///	second factor authentication token
		/// </summary>
		[JsonProperty(PropertyName = "SecondFactorAuthenticationToken")]
        public  Guid SecondFactorAuthenticationToken {get;set;}

    }
}