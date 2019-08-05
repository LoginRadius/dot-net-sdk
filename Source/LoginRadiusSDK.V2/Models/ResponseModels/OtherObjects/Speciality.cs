//-----------------------------------------------------------------------
// <copyright file="ModelClass" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2019 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using Newtonsoft.Json;
namespace LoginRadiusSDK.V2.Models.ResponseModels.OtherObjects

{

    /// <summary>
    ///	Response containing Definition of Complete Speciality data
    /// </summary>
    public class Speciality
    {
		/// <summary>
		///	User's speciality names
		/// </summary>
		[JsonProperty(PropertyName = "SpecialityNames")]
        public  List<string> SpecialityNames {get;set;}

		/// <summary>
		///	Total User's speciality
		/// </summary>
		[JsonProperty(PropertyName = "Total")]
        public  int Total {get;set;}

    }
}