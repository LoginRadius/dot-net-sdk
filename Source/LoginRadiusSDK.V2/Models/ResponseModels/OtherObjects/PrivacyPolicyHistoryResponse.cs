//-----------------------------------------------------------------------
// <copyright file="ModelClass" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2019 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using Newtonsoft.Json;
using LoginRadiusSDK.V2.Models.ResponseModels.UserProfile.Objects;
namespace LoginRadiusSDK.V2.Models.ResponseModels.OtherObjects

{

    /// <summary>
    ///	Response containing Definition of Complete PrivacyPolicyHistory
    /// </summary>
    public class PrivacyPolicyHistoryResponse
    {
		/// <summary>
		///	Current privacy policy
		/// </summary>
		[JsonProperty(PropertyName = "Current")]
        public  AcceptedPrivacyPolicy Current {get;set;}

		/// <summary>
		///	Privacy policy history
		/// </summary>
		[JsonProperty(PropertyName = "History")]
        public  List<AcceptedPrivacyPolicy> History {get;set;}

		/// <summary>
		///	UID, the unified identifier for each user account
		/// </summary>
		[JsonProperty(PropertyName = "Uid")]
        public  string Uid {get;set;}

    }
}