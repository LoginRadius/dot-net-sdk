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
    ///	Model Class containing Definition of payload for Reset Pin By Security Question and Phone API
    /// </summary>
    public class ResetPINBySecurityQuestionAnswerAndPhoneModel:ResetPINBySecurityQuestionAnswer
    {
		/// <summary>
		///	New Phone Number
		/// </summary>
		[JsonProperty(PropertyName = "Phone")]
        public  string Phone {get;set;}

    }
}