//-----------------------------------------------------------------------
// <copyright file="ModelClass" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2019 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using Newtonsoft.Json;
namespace LoginRadiusSDK.V2.Models.ResponseModels.OtherObjects

{

    /// <summary>
    ///	Response containing Definition of Complete Forgot Password data
    /// </summary>
    public class ForgotPasswordResponse
    {
		/// <summary>
		///	Forgot token
		/// </summary>
		[JsonProperty(PropertyName = "ForgotToken")]
        public  string ForgotToken {get;set;}

		/// <summary>
		///	Identity providers
		/// </summary>
		[JsonProperty(PropertyName = "IdentityProviders")]
        public  List<string> IdentityProviders {get;set;}

    }
}