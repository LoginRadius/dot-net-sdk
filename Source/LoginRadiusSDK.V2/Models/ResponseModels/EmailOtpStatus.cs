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
    ///	
    /// </summary>
    public class EmailOtpStatus
    {
		/// <summary>
		///	
		/// </summary>
		[JsonProperty(PropertyName = "Email")]
        public  string Email {get;set;}

    }
}