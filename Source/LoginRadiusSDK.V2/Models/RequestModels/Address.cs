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
    ///	Model Class containing Definition for Address Property
    /// </summary>
    public class Address
    {
		/// <summary>
		///	Address field value that needs to be updated
		/// </summary>
		[JsonProperty(PropertyName = "Address1")]
        public  string Address1 {get;set;}

		/// <summary>
		///	Address field value that needs to be updated
		/// </summary>
		[JsonProperty(PropertyName = "Address2")]
        public  string Address2 {get;set;}

		/// <summary>
		///	user's city
		/// </summary>
		[JsonProperty(PropertyName = "City")]
        public  string City {get;set;}

		/// <summary>
		///	Country of the user
		/// </summary>
		[JsonProperty(PropertyName = "Country")]
        public  string Country {get;set;}

		/// <summary>
		///	operation type
		/// </summary>
		[JsonProperty(PropertyName = "op")]
        public  OperationType? Op {get;set;}

		/// <summary>
		///	Postal code value that need to be updated
		/// </summary>
		[JsonProperty(PropertyName = "PostalCode")]
        public  string PostalCode {get;set;}

		/// <summary>
		///	Region
		/// </summary>
		[JsonProperty(PropertyName = "Region")]
        public  string Region {get;set;}

		/// <summary>
		///	State of the user
		/// </summary>
		[JsonProperty(PropertyName = "State")]
        public  string State {get;set;}

		/// <summary>
		///	String to identify the type of parameter
		/// </summary>
		[JsonProperty(PropertyName = "Type")]
        public  string Type {get;set;}

    }
}