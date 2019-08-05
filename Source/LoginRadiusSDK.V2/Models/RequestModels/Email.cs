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
    ///	Model Class containing Definition for Email Property
    /// </summary>
    public class Email
    {
		/// <summary>
		///	type of email id
		/// </summary>
		[JsonProperty(PropertyName = "Type")]
        public  string Type {get;set;}

		/// <summary>
		///	Email address
		/// </summary>
		[JsonProperty(PropertyName = "Value")]
        public  string Value {get;set;}

    }
}