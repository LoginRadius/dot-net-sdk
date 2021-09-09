//-----------------------------------------------------------------------
// <copyright file="ModelClass" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2019 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using Newtonsoft.Json;
namespace LoginRadiusSDK.V2.Models.RequestModels

{

    /// <summary>
    ///	
    /// </summary>
    public class SecurityQuestionAnswerUpdateModel
    {
		/// <summary>
		///	
		/// </summary>
		[JsonProperty(PropertyName = "SecurityQuestionAnswer")]
        public  List<SecurityQuestionModel> SecurityQuestionAnswer {get;set;}

    }
}