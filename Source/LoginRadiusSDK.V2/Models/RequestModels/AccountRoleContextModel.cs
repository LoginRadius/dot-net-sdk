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
    ///	Model Class containing Definition of RoleContext payload
    /// </summary>
    public class AccountRoleContextModel
    {
		/// <summary>
		///	Array of RoleContext object, see body tab for structure
		/// </summary>
		[JsonProperty(PropertyName = "RoleContext")]
        public  List<RoleContextRoleModel> RoleContext {get;set;}

    }
}