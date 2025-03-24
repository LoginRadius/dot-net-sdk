//-----------------------------------------------------------------------
// <copyright file="ModelClass" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2025 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Newtonsoft.Json;
namespace LoginRadiusSDK.V2.Models.RequestModels

{

    /// <summary>
    ///	Model Class containing Definition for Forgot Pin Link By Email API
    /// </summary>
    public class ForgotPINLinkByEmailModel
    {
		/// <summary>
		///	user's email
		/// </summary>
		[JsonProperty(PropertyName = "Email")]
        public  string Email {get;set;}

    }
}