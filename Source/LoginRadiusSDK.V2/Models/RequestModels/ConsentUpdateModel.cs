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
    ///	Model class containg list of multiple consent
    /// </summary>
    public class ConsentUpdateModel
    {
		/// <summary>
		///	List of Consents
		/// </summary>
		[JsonProperty(PropertyName = "Consents")]
        public  List<ConsentDataModel> Consents {get;set;}

    }
}