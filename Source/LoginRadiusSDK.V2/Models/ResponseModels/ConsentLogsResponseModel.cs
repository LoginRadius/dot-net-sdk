//-----------------------------------------------------------------------
// <copyright file="ModelClass" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2019 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using Newtonsoft.Json;
namespace LoginRadiusSDK.V2.Models.ResponseModels

{

    /// <summary>
    ///	Response containing consent logs
    /// </summary>
    public class ConsentLogsResponseModel
    {
		/// <summary>
		///	List of consent logs
		/// </summary>
		[JsonProperty(PropertyName = "ConsentLogs")]
        public  List<ConsentProfileLogs> ConsentLogs {get;set;}

		/// <summary>
		///	UID, the unified identifier for each user account
		/// </summary>
		[JsonProperty(PropertyName = "Uid")]
        public  string Uid {get;set;}

    }
}