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
    ///	Model Class containing Definition of payload for Reset Pin By Reset Token API
    /// </summary>
    public class ResetPINByResetToken
    {
		/// <summary>
		///	PIN of user
		/// </summary>
		[JsonProperty(PropertyName = "PIN")]
        public  string PIN {get;set;}

		/// <summary>
		///	reset token received in the email
		/// </summary>
		[JsonProperty(PropertyName = "ResetToken")]
        public  string ResetToken {get;set;}

    }
}