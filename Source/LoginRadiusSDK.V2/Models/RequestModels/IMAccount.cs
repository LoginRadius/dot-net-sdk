//-----------------------------------------------------------------------
// <copyright file="ModelClass" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2019 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Newtonsoft.Json;
namespace LoginRadiusSDK.V2.Models.RequestModels

{

    /// <summary>
    ///	Model Class containing Definition for IMAccount Property
    /// </summary>
    public class IMAccount
    {
		/// <summary>
		///	Name of account
		/// </summary>
		[JsonProperty(PropertyName = "AccountName")]
        public  string AccountName {get;set;}

		/// <summary>
		///	Type of account
		/// </summary>
		[JsonProperty(PropertyName = "AccountType")]
        public  string AccountType {get;set;}

    }
}