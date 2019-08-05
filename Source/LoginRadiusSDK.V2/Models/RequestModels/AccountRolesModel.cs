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
    ///	Model Class containing Definition of payload for Create Role API
    /// </summary>
    public class AccountRolesModel
    {
		/// <summary>
		///	Array of String, which represents the role name
		/// </summary>
		[JsonProperty(PropertyName = "Roles")]
        public  List<string> Roles {get;set;}

    }
}