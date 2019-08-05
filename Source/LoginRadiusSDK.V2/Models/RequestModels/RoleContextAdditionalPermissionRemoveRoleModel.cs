//-----------------------------------------------------------------------
// <copyright file="ModelClass" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2019 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using Newtonsoft.Json;
namespace LoginRadiusSDK.V2.Models.RequestModels

{

    /// <summary>
    ///	Model Class containing Definition of payload for RoleContextAdditionalPermissionRemoveRole API
    /// </summary>
    public class RoleContextAdditionalPermissionRemoveRoleModel
    {
		/// <summary>
		///	Array of String, which represents the additional permissions
		/// </summary>
		[JsonProperty(PropertyName = "AdditionalPermissions")]
        public  List<string> AdditionalPermissions {get;set;}

    }
}