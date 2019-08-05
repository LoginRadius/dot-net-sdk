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
    ///	Response containing Definition of Complete Country Code data
    /// </summary>
    public class CountryCodeName
    {
		/// <summary>
		///	Country code
		/// </summary>
		[JsonProperty(PropertyName = "Code")]
        public  string Code {get;set;}

		/// <summary>
		///	Country name
		/// </summary>
		[JsonProperty(PropertyName = "Name")]
        public  string Name {get;set;}

    }
}