//-----------------------------------------------------------------------
// <copyright file="ModelClass" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2019 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Newtonsoft.Json;
namespace LoginRadiusSDK.V2.Models.ResponseModels

{

    /// <summary>
    ///	Response containing Definition for Complete Validation data
    /// </summary>
    public class PostMethodResponse
    {
		/// <summary>
		///	check data is posted
		/// </summary>
		[JsonProperty(PropertyName = "isPosted")]
        public  bool IsPosted {get;set;}

    }
}