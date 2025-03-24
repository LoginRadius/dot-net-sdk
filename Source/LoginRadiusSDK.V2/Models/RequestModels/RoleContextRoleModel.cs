//-----------------------------------------------------------------------
// <copyright file="ModelClass" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2025 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using Newtonsoft.Json;
namespace LoginRadiusSDK.V2.Models.RequestModels

{

    /// <summary>
    ///	Model Class containing Definition of payload for RoleContextRole API
    /// </summary>
    public class RoleContextRoleModel
    {
		/// <summary>
		///	Array of String, which represents the additional permissions
		/// </summary>
		[JsonProperty(PropertyName = "AdditionalPermissions")]
        public  List<string> AdditionalPermissions {get;set;}

		/// <summary>
		///	Array of RoleContext object, see body tab for structure
		/// </summary>
		[JsonProperty(PropertyName = "Context")]
        public  string Context {get;set;}

		/// <summary>
		///	Role expiration date
		/// </summary>
		[JsonProperty(PropertyName = "Expiration")]
        public  string Expiration {get;set;}

		/// <summary>
		///	Array of String, which represents the role name
		/// </summary>
		[JsonProperty(PropertyName = "Roles")]
        public  List<string> Roles {get;set;}

    }
}