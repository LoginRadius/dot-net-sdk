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
    ///	Response containing Definition of Complete CheckIn data
    /// </summary>
    public class CheckIn
    {
		/// <summary>
		///	Array of objects,String represents address of user
		/// </summary>
		[JsonProperty(PropertyName = "Address")]
        public  string Address {get;set;}

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
		///	Date of Creation of Profile
		/// </summary>
		[JsonProperty(PropertyName = "CreatedDate")]
        public  string CreatedDate {get;set;}

		/// <summary>
		///	distance
		/// </summary>
		[JsonProperty(PropertyName = "Distance")]
        public  string Distance {get;set;}

		/// <summary>
		///	ID of the User
		/// </summary>
		[JsonProperty(PropertyName = "ID")]
        public  string ID {get;set;}

		/// <summary>
		///	image URL should be absolute and has HTTPS domain
		/// </summary>
		[JsonProperty(PropertyName = "ImageUrl")]
        public  string ImageUrl {get;set;}

		/// <summary>
		///	The Latitude
		/// </summary>
		[JsonProperty(PropertyName = "Latitude")]
        public  string Latitude {get;set;}

		/// <summary>
		///	The Longitude
		/// </summary>
		[JsonProperty(PropertyName = "Longitude")]
        public  string Longitude {get;set;}

		/// <summary>
		///	message
		/// </summary>
		[JsonProperty(PropertyName = "Message")]
        public  string Message {get;set;}

		/// <summary>
		///	ID of account owner
		/// </summary>
		[JsonProperty(PropertyName = "OwnerId")]
        public  string OwnerId {get;set;}

		/// <summary>
		///	Name of account owner
		/// </summary>
		[JsonProperty(PropertyName = "OwnerName")]
        public  string OwnerName {get;set;}

		/// <summary>
		///	The place title
		/// </summary>
		[JsonProperty(PropertyName = "PlaceTitle")]
        public  string PlaceTitle {get;set;}

		/// <summary>
		///	String to identify the type of parameter
		/// </summary>
		[JsonProperty(PropertyName = "Type")]
        public  string Type {get;set;}

    }
}