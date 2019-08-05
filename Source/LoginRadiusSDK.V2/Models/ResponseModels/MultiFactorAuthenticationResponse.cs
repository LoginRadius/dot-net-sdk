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
    ///	Response containing Definition of Complete Multi-Factor Authentication data
    /// </summary>
    public class MultiFactorAuthenticationResponse<T>
    {
		/// <summary>
		///	Uniquely generated identifier key by LoginRadius that is activated after successful authentication.
		/// </summary>
		[JsonProperty(PropertyName = "access_token")]
        public  Guid Access_Token {get;set;}

		/// <summary>
		///	Expiration time of Access Token
		/// </summary>
		[JsonProperty(PropertyName = "expires_in")]
        public  DateTime Expires_In {get;set;}

		/// <summary>
		///	Complete user profile data
		/// </summary>
		[JsonProperty(PropertyName = "Profile")]
        public  T Profile {get;set;}

		/// <summary>
		///	refresh token to refresh access token
		/// </summary>
		[JsonProperty(PropertyName = "refresh_token")]
        public  Guid? Refresh_Token {get;set;}

		/// <summary>
		///	second factor authentication
		/// </summary>
		[JsonProperty(PropertyName = "SecondFactorAuthentication")]
        public  MultiFactorAuthenticationToken SecondFactorAuthentication {get;set;}

    }
}