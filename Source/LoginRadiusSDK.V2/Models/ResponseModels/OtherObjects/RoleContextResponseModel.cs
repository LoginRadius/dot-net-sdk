//-----------------------------------------------------------------------
// <copyright file="ModelClass" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2019 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using LoginRadiusSDK.V2.Models.ResponseModels.UserProfile.Objects;
namespace LoginRadiusSDK.V2.Models.ResponseModels.OtherObjects

{

    /// <summary>
    ///	Response containing Definition of RoleContext Profile
    /// </summary>
    public class RoleContextResponseModel
    {
		/// <summary>
		///	user's email
		/// </summary>
		[JsonProperty(PropertyName = "Email")]
        public  List<Email> Email {get;set;}

		/// <summary>
		///	Users complete name
		/// </summary>
		[JsonProperty(PropertyName = "FullName")]
        public  string FullName {get;set;}

		/// <summary>
		///	image URL should be absolute and has HTTPS domain
		/// </summary>
		[JsonProperty(PropertyName = "ImageUrl")]
        public  string ImageUrl {get;set;}

		/// <summary>
		///	last login date
		/// </summary>
		[JsonProperty(PropertyName = "LastLoginDate")]
        public  DateTime LastLoginDate {get;set;}

		/// <summary>
		///	Array of RoleContext object, see body tab for structure
		/// </summary>
		[JsonProperty(PropertyName = "RoleContext")]
        public  RoleContextResponse RoleContext {get;set;}

		/// <summary>
		///	UID, the unified identifier for each user account
		/// </summary>
		[JsonProperty(PropertyName = "Uid")]
        public  string Uid {get;set;}

    }
}