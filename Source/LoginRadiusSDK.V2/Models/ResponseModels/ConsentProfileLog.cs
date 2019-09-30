//-----------------------------------------------------------------------
// <copyright file="ModelClass" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2019 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Newtonsoft.Json;
using LoginRadiusSDK.V2.Models.Enums;
namespace LoginRadiusSDK.V2.Models.ResponseModels

{

    /// <summary>
    ///	Response containing consent profile logs
    /// </summary>
    public class ConsentProfileLog
    {
		/// <summary>
		///	Consent ID
		/// </summary>
		[JsonProperty(PropertyName = "ConsentId")]
        public  string ConsentId {get;set;}

		/// <summary>
		///	ConsentProfileActions
		/// </summary>
		[JsonProperty(PropertyName = "Event")]
        public  ConsentProfileActions Event {get;set;}

    }
}