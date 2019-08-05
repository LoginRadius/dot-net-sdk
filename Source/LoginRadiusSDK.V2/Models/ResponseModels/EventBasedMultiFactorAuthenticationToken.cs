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
    ///	Response containing Definition response of MFA reauthentication
    /// </summary>
    public class EventBasedMultiFactorAuthenticationToken
    {
		/// <summary>
		///	Expiration time of Access Token
		/// </summary>
		[JsonProperty(PropertyName = "ExpireIn")]
        public  DateTime ExpireIn {get;set;}

		/// <summary>
		///	second factor validation token
		/// </summary>
		[JsonProperty(PropertyName = "SecondFactorValidationToken")]
        public  Guid SecondFactorValidationToken {get;set;}

    }
}