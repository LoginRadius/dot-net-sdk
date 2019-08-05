//-----------------------------------------------------------------------
// <copyright file="ModelClass" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2019 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Newtonsoft.Json;
namespace LoginRadiusSDK.V2.Models.ResponseModels.OtherObjects

{

    /// <summary>
    ///	Complete verified response data
    /// </summary>
    public class VerifiedResponse
    {
		/// <summary>
		///	check data is posted
		/// </summary>
		[JsonProperty(PropertyName = "IsPosted")]
        public  bool IsPosted {get;set;}

		/// <summary>
		///	is verified or not
		/// </summary>
		[JsonProperty(PropertyName = "IsVerified")]
        public  bool IsVerified {get;set;}

    }
}