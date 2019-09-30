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
    ///	Model Class containing Definition for Forgot Pin Link By UserName API
    /// </summary>
    public class ForgotPINLinkByUserNameModel
    {
		/// <summary>
		///	Username of the user
		/// </summary>
		[JsonProperty(PropertyName = "UserName")]
        public  string UserName {get;set;}

    }
}