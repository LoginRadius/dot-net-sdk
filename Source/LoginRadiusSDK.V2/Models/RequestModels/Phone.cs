//-----------------------------------------------------------------------
// <copyright file="ModelClass" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2019 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Newtonsoft.Json;
using LoginRadiusSDK.V2.Models.Enums;
namespace LoginRadiusSDK.V2.Models.RequestModels

{

    /// <summary>
    ///	Model Class containing Definition for Phone Property
    /// </summary>
    public class Phone
    {
		/// <summary>
		///	operation type
		/// </summary>
		[JsonProperty(PropertyName = "op")]
        public  OperationType? Op {get;set;}

		/// <summary>
		///	Phone number
		/// </summary>
		[JsonProperty(PropertyName = "PhoneNumber")]
        public  string PhoneNumber {get;set;}

		/// <summary>
		///	Phone type
		/// </summary>
		[JsonProperty(PropertyName = "PhoneType")]
        public  string PhoneType {get;set;}

    }
}