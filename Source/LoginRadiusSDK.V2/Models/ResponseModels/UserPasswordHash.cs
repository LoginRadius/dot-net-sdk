//-----------------------------------------------------------------------
// <copyright file="ModelClass" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2019 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Newtonsoft.Json;
namespace LoginRadiusSDK.V2.Models.ResponseModels

{

    /// <summary>
    ///	Response containing Definition for Complete PasswordHash data
    /// </summary>
    public class UserPasswordHash
    {
		/// <summary>
		///	Password hash
		/// </summary>
		[JsonProperty(PropertyName = "PasswordHash")]
        public  string PasswordHash {get;set;}

    }
}