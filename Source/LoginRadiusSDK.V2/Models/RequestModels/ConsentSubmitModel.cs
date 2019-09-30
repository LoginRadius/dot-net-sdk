//-----------------------------------------------------------------------
// <copyright file="ModelClass" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2019 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using Newtonsoft.Json;
namespace LoginRadiusSDK.V2.Models.RequestModels

{

    /// <summary>
    ///	Model class containing list of multiple consent
    /// </summary>
    public class ConsentSubmitModel
    {
		/// <summary>
		///	Data
		/// </summary>
		[JsonProperty(PropertyName = "Data")]
        public  List<ConsentDataModel> Data {get;set;}

		/// <summary>
		///	The event associated with the consent form
		/// </summary>
		[JsonProperty(PropertyName = "Events")]
        public  List<ConsentEventModel> Events {get;set;}

    }
}