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
    ///	Model Class containing Definition for EmailModel Property
    /// </summary>
    public class EmailModel
    {
		/// <summary>
		///	String to identify the type of parameter
		/// </summary>
		[JsonProperty(PropertyName = "Type")]
        public  string Type {get;set;}

		/// <summary>
		///	Value of the dropdown member
		/// </summary>
		[JsonProperty(PropertyName = "Value")]
        public  string Value {get;set;}

    }
}