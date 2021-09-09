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
    ///	
    /// </summary>
    public class SecurityQuestionModel
    {
		/// <summary>
		///	
		/// </summary>
		[JsonProperty(PropertyName = "Answer")]
        public  string Answer {get;set;}

		/// <summary>
		///	
		/// </summary>
		[JsonProperty(PropertyName = "QuestionId")]
        public  string QuestionId {get;set;}

    }
}