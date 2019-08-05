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
    ///	Response containing Definition for Complete Phone data
    /// </summary>
    public class Phone
    {
		/// <summary>
		///	Phone number
		/// </summary>
		[JsonProperty(PropertyName = "PhoneNumber")]
        public  string PhoneNumber {get;set;}

		/// <summary>
		///	Phone type
		/// </summary>
		[JsonProperty(PropertyName = "PhoneType")]
        public  string PhoneType {get;set;}

    }
}