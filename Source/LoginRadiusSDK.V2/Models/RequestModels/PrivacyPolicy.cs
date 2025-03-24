//-----------------------------------------------------------------------
// <copyright file="ModelClass" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2025 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Newtonsoft.Json;
namespace LoginRadiusSDK.V2.Models.RequestModels

{

    /// <summary>
    ///	Model Class containing Definition for PrivacyPolicy Property
    /// </summary>
    public class PrivacyPolicy
    {
		/// <summary>
		///	Privacy policy version
		/// </summary>
		[JsonProperty(PropertyName = "Version")]
        public  string Version {get;set;}

    }
}