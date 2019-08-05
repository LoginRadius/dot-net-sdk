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
    ///	Response containing Definition of Complete Page data
    /// </summary>
    public class PageLocations
    {
		/// <summary>
		///	user's city
		/// </summary>
		[JsonProperty(PropertyName = "City")]
        public  string City {get;set;}

		/// <summary>
		///	Country of the user
		/// </summary>
		[JsonProperty(PropertyName = "Country")]
        public  CountryCodeName Country {get;set;}

		/// <summary>
		///	The Latitude
		/// </summary>
		[JsonProperty(PropertyName = "Latitude")]
        public  double Latitude {get;set;}

		/// <summary>
		///	The Longitude
		/// </summary>
		[JsonProperty(PropertyName = "Longitude")]
        public  double Longitude {get;set;}

		/// <summary>
		///	New Phone Number
		/// </summary>
		[JsonProperty(PropertyName = "Phone")]
        public  string Phone {get;set;}

		/// <summary>
		///	State of the user
		/// </summary>
		[JsonProperty(PropertyName = "State")]
        public  string State {get;set;}

		/// <summary>
		///	Street of the user
		/// </summary>
		[JsonProperty(PropertyName = "Street")]
        public  string Street {get;set;}

		/// <summary>
		///	ZipCode of the user
		/// </summary>
		[JsonProperty(PropertyName = "Zip")]
        public  string Zip {get;set;}

    }
}