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
    ///	Response containing Definition for Complete SMS data
    /// </summary>
    public class SMSResponseData
    {
		/// <summary>
		///	Account Sid
		/// </summary>
		[JsonProperty(PropertyName = "AccountSid")]
        public  string AccountSid {get;set;}

		/// <summary>
		///	Sid
		/// </summary>
		[JsonProperty(PropertyName = "Sid")]
        public  string Sid {get;set;}

    }
}