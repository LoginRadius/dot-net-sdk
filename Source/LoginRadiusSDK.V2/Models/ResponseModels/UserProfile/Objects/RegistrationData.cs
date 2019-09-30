//-----------------------------------------------------------------------
// <copyright file="ModelClass" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2019 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using Newtonsoft.Json;
namespace LoginRadiusSDK.V2.Models.ResponseModels.UserProfile.Objects

{

    /// <summary>
    ///	Response containing Definition for Registration Data
    /// </summary>
    public class RegistrationData
    {
		/// <summary>
		///	Data
		/// </summary>
		[JsonProperty(PropertyName = "Data")]
        public  List<DataValue> Data {get;set;}

    }
}