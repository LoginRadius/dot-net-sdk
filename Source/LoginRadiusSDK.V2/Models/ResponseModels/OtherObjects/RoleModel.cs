//-----------------------------------------------------------------------
// <copyright file="ModelClass" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2019 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using Newtonsoft.Json;
namespace LoginRadiusSDK.V2.Models.ResponseModels.OtherObjects

{

    /// <summary>
    ///	Response containing Definition of Complete role data
    /// </summary>
    public class RoleModel
    {
		/// <summary>
		///	Array of String, which represents the role name
		/// </summary>
		[JsonProperty(PropertyName = "Name")]
        public  string Name {get;set;}

		/// <summary>
		///	Any Permission name for the role
		/// </summary>
		[JsonProperty(PropertyName = "Permissions")]
        public  Dictionary<string,bool> Permissions {get;set;}

    }
}