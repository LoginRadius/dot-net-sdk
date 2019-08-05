//-----------------------------------------------------------------------
// <copyright file="ModelClass" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2019 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Newtonsoft.Json;
namespace LoginRadiusSDK.V2.Models.ResponseModels.UserProfile.Objects

{

    /// <summary>
    ///	Response containing Definition for Complete Recommendations Received data
    /// </summary>
    public class RecommendationsReceived
    {
		/// <summary>
		///	Recommendation id
		/// </summary>
		[JsonProperty(PropertyName = "Id")]
        public  string Id {get;set;}

		/// <summary>
		///	Recommendation text
		/// </summary>
		[JsonProperty(PropertyName = "RecommendationText")]
        public  string RecommendationText {get;set;}

		/// <summary>
		///	Recommendation type
		/// </summary>
		[JsonProperty(PropertyName = "RecommendationType")]
        public  string RecommendationType {get;set;}

		/// <summary>
		///	Recommender
		/// </summary>
		[JsonProperty(PropertyName = "Recommender")]
        public  string Recommender {get;set;}

    }
}