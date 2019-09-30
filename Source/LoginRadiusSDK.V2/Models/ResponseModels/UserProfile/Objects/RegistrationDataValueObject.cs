//-----------------------------------------------------------------------
// <copyright file="ModelClass" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2019 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Newtonsoft.Json;
namespace LoginRadiusSDK.V2.Models.ResponseModels.UserProfile.Objects

{

    /// <summary>
    ///	Response containing Definition for Registration Data value
    /// </summary>
    public class RegistrationDataValueObject
    {
		/// <summary>
		///	ID of the User
		/// </summary>
		[JsonProperty(PropertyName = "Id")]
        public  string Id {get;set;}

    }
}