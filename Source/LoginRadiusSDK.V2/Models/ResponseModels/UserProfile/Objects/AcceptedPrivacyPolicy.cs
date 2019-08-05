//-----------------------------------------------------------------------
// <copyright file="ModelClass" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2019 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using Newtonsoft.Json;
namespace LoginRadiusSDK.V2.Models.ResponseModels.UserProfile.Objects

{

    /// <summary>
    ///	Response containing Definition for Complete privacy policy data
    /// </summary>
    public class AcceptedPrivacyPolicy
    {
		/// <summary>
		///	Privacy policy accept date time
		/// </summary>
		[JsonProperty(PropertyName = "AcceptDateTime")]
        public  DateTime? AcceptDateTime {get;set;}

		/// <summary>
		///	Privacy policy accept source
		/// </summary>
		[JsonProperty(PropertyName = "AcceptSource")]
        public  string AcceptSource {get;set;}

		/// <summary>
		///	Privacy policy version
		/// </summary>
		[JsonProperty(PropertyName = "Version")]
        public  string Version {get;set;}

    }
}