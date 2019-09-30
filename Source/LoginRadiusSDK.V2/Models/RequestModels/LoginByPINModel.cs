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
    ///	Model Class containing Definition of payload for LoginByPin API
    /// </summary>
    public class LoginByPINModel
    {
		/// <summary>
		///	PIN of user
		/// </summary>
		[JsonProperty(PropertyName = "PIN")]
        public  string PIN {get;set;}

    }
}