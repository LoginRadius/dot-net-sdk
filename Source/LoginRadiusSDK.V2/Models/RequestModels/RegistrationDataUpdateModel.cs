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
    ///	Model Class containing Definition of payload for Registration Data update API
    /// </summary>
    public class RegistrationDataUpdateModel
    {
		/// <summary>
		///	Validation Code/Secret Code,Code Parameter, given when Login Dialog is performed
		/// </summary>
		[JsonProperty(PropertyName = "Code")]
        public  string Code {get;set;}

		/// <summary>
		///	ID of the User
		/// </summary>
		[JsonProperty(PropertyName = "Id")]
        public  string Id {get;set;}

		/// <summary>
		///	boolean type value, default is true
		/// </summary>
		[JsonProperty(PropertyName = "IsActive")]
        public  bool? IsActive {get;set;}

		/// <summary>
		///	Text to display for the dropdown member
		/// </summary>
		[JsonProperty(PropertyName = "Key")]
        public  string Key {get;set;}

		/// <summary>
		///	Id of parent dropdown member
		/// </summary>
		[JsonProperty(PropertyName = "ParentId")]
        public  string ParentId {get;set;}

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