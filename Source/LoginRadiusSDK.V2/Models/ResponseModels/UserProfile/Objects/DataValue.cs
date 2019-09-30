//-----------------------------------------------------------------------
// <copyright file="ModelClass" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2019 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Newtonsoft.Json;
namespace LoginRadiusSDK.V2.Models.ResponseModels.UserProfile.Objects

{

    /// <summary>
    ///	Response Model Class containing Definition of Registration Data
    /// </summary>
    public class DataValue
    {
		/// <summary>
		///	Registration Data Source
		/// </summary>
		[JsonProperty(PropertyName = "DataSource")]
        public  string DataSource {get;set;}

		/// <summary>
		///	Value of the dropdown member
		/// </summary>
		[JsonProperty(PropertyName = "Value")]
        public  RegistrationDataValueObject Value {get;set;}

    }
}