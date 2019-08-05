//-----------------------------------------------------------------------
// <copyright file="ModelClass" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2019 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using Newtonsoft.Json;
namespace LoginRadiusSDK.V2.Models.ResponseModels

{

    /// <summary>
    ///	Response containing Definition of Complete ActiveSession data
    /// </summary>
    public class ActiveSessionDetail
    {
		/// <summary>
		///	Uniquely generated identifier key by LoginRadius that is activated after successful authentication.
		/// </summary>
		[JsonProperty(PropertyName = "AccessToken")]
        public  string AccessToken {get;set;}

		/// <summary>
		///	Browser details of user
		/// </summary>
		[JsonProperty(PropertyName = "Browser")]
        public  string Browser {get;set;}

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
		///	Device of user
		/// </summary>
		[JsonProperty(PropertyName = "Device")]
        public  string Device {get;set;}

		/// <summary>
		///	type of device
		/// </summary>
		[JsonProperty(PropertyName = "DeviceType")]
        public  string DeviceType {get;set;}

		/// <summary>
		///	IP of user
		/// </summary>
		[JsonProperty(PropertyName = "Ip")]
        public  string Ip {get;set;}

		/// <summary>
		///	last login date
		/// </summary>
		[JsonProperty(PropertyName = "LoginDate")]
        public  DateTime LoginDate {get;set;}

		/// <summary>
		///	Os Details of user
		/// </summary>
		[JsonProperty(PropertyName = "Os")]
        public  string Os {get;set;}

    }
}