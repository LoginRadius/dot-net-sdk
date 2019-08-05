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
    ///	Response containing Definition for Complete active sessions
    /// </summary>
    public class UserActiveSession
    {
		/// <summary>
		///	Data
		/// </summary>
		[JsonProperty(PropertyName = "data")]
        public  List<ActiveSessionDetail> Data {get;set;}

		/// <summary>
		///	Cursor value if not all contacts can be retrieved once.
		/// </summary>
		[JsonProperty(PropertyName = "nextcursor")]
        public  int Nextcursor {get;set;}

    }
}