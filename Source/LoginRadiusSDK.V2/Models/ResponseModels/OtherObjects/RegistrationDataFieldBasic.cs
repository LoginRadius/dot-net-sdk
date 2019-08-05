//-----------------------------------------------------------------------
// <copyright file="ModelClass" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2019 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using Newtonsoft.Json;
namespace LoginRadiusSDK.V2.Models.ResponseModels.OtherObjects

{

    /// <summary>
    ///	Response containing Definition of Complete Registration Data Basic Field
    /// </summary>
    public class RegistrationDataFieldBasic
    {
		/// <summary>
		///	Creation data
		/// </summary>
		[JsonProperty(PropertyName = "DateCreated")]
        public  DateTime DateCreated {get;set;}

		/// <summary>
		///	Any modification date
		/// </summary>
		[JsonProperty(PropertyName = "DateModified")]
        public  DateTime DateModified {get;set;}

		/// <summary>
		///	ID of the User
		/// </summary>
		[JsonProperty(PropertyName = "Id")]
        public  string Id {get;set;}

		/// <summary>
		///	boolean type value, default is true
		/// </summary>
		[JsonProperty(PropertyName = "IsActive")]
        public  bool IsActive {get;set;}

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
		///	Parent type
		/// </summary>
		[JsonProperty(PropertyName = "ParentType")]
        public  string ParentType {get;set;}

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