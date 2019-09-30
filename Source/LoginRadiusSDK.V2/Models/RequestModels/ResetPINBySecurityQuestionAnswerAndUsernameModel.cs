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
    ///	Model Class containing Definition of payload for Reset Pin By Security Question and UserName API
    /// </summary>
    public class ResetPINBySecurityQuestionAnswerAndUsernameModel:ResetPINBySecurityQuestionAnswer
    {
		/// <summary>
		///	Username of the user
		/// </summary>
		[JsonProperty(PropertyName = "Username")]
        public  string Username {get;set;}

    }
}