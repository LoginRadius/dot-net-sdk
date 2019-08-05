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
    ///	Response containing Definition for Complete SecurityQuestions data
    /// </summary>
    public class SecurityQuestions
    {
		/// <summary>
		///	Question
		/// </summary>
		[JsonProperty(PropertyName = "Question")]
        public  string Question {get;set;}

		/// <summary>
		///	Id of question
		/// </summary>
		[JsonProperty(PropertyName = "QuestionId")]
        public  string QuestionId {get;set;}

    }
}