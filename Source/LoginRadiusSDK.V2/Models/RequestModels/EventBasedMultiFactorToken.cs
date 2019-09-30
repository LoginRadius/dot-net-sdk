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
    ///	Model Class containing Definition for SecondFactorValidationToken
    /// </summary>
    public class EventBasedMultiFactorToken
    {
		/// <summary>
		///	second factor validation token
		/// </summary>
		[JsonProperty(PropertyName = "SecondFactorValidationToken")]
        public  string SecondFactorValidationToken {get;set;}

    }
}