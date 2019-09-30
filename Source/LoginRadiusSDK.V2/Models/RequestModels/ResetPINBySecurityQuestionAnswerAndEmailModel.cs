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
    ///	Model Class containing Definition of payload for Reset Pin By Security Question and Email API
    /// </summary>
    public class ResetPINBySecurityQuestionAnswerAndEmailModel:ResetPINBySecurityQuestionAnswer
    {
		/// <summary>
		///	user's email
		/// </summary>
		[JsonProperty(PropertyName = "Email")]
        public  string Email {get;set;}

    }
}