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
    ///	Model Class containing Definition for PermissionsModel Property
    /// </summary>
    public class PermissionsModel
    {
		/// <summary>
		///	Any Permission name for the role
		/// </summary>
		[JsonProperty(PropertyName = "Permissions")]
        public  List<string> Permissions {get;set;}

    }
}