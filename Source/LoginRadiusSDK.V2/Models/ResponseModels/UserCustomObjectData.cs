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
    ///	Response containing Definition for Complete user custom object data
    /// </summary>
    public class UserCustomObjectData
    {
		/// <summary>
		///	custom object
		/// </summary>
		[JsonProperty(PropertyName = "CustomObject")]
        public  object CustomObject {get;set;}

		/// <summary>
		///	Custom object created date
		/// </summary>
		[JsonProperty(PropertyName = "DateCreated")]
        public  DateTime DateCreated {get;set;}

		/// <summary>
		///	Custom object modified date
		/// </summary>
		[JsonProperty(PropertyName = "DateModified")]
        public  DateTime DateModified {get;set;}

		/// <summary>
		///	Custom object id
		/// </summary>
		[JsonProperty(PropertyName = "Id")]
        public  string Id {get;set;}

		/// <summary>
		///	boolean type value, default is true
		/// </summary>
		[JsonProperty(PropertyName = "IsActive")]
        public  bool IsActive {get;set;}

		/// <summary>
		///	boolean type value, default is true
		/// </summary>
		[JsonProperty(PropertyName = "IsDeleted")]
        public  bool IsDeleted {get;set;}

		/// <summary>
		///	UID, the unified identifier for each user account
		/// </summary>
		[JsonProperty(PropertyName = "Uid")]
        public  string Uid {get;set;}

    }
}