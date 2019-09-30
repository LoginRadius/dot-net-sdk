//-----------------------------------------------------------------------
// <copyright file="ModelClass" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2019 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using Newtonsoft.Json;
namespace LoginRadiusSDK.V2.Models.ResponseModels

{

    /// <summary>
    ///	Response containing consent profile
    /// </summary>
    public class ConsentProfile
    {
		/// <summary>
		///	List of consent version
		/// </summary>
		[JsonProperty(PropertyName = "AcceptedConsentVersions")]
        public  List<ConsentVersions> AcceptedConsentVersions {get;set;}

		/// <summary>
		///	List of Consents
		/// </summary>
		[JsonProperty(PropertyName = "Consents")]
        public  List<ConsentOption> Consents {get;set;}

    }
}