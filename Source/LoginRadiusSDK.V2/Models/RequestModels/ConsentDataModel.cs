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
    ///	Model class containing defination of consent data
    /// </summary>
    public class ConsentDataModel
    {
		/// <summary>
		///	Consent Option Id
		/// </summary>
		[JsonProperty(PropertyName = "ConsentOptionId")]
        public  string ConsentOptionId {get;set;}

		/// <summary>
		///	Is Accepted
		/// </summary>
		[JsonProperty(PropertyName = "IsAccepted")]
        public  bool? IsAccepted {get;set;}

    }
}