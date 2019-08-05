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
    ///	Response containing Definition of Complete Validation data
    /// </summary>
    public class PostResponse
    {
		/// <summary>
		///	check data is posted
		/// </summary>
		[JsonProperty(PropertyName = "IsPosted")]
        public  bool IsPosted {get;set;}

    }
}