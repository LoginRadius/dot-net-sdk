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
    ///	Model Class containing Definition for KloutProfile Property
    /// </summary>
    public class KloutProfile
    {
		/// <summary>
		///	Id of klout
		/// </summary>
		[JsonProperty(PropertyName = "KloutId")]
        public  string KloutId {get;set;}

		/// <summary>
		///	Object, string represents KloutId and double represents Score
		/// </summary>
		[JsonProperty(PropertyName = "Score")]
        public  double? Score {get;set;}

    }
}