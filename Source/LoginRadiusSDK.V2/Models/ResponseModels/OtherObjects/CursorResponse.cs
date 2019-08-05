//-----------------------------------------------------------------------
// <copyright file="ModelClass" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2019 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using Newtonsoft.Json;
namespace LoginRadiusSDK.V2.Models.ResponseModels.OtherObjects

{

    /// <summary>
    ///	Response containing Definition of Complete Cursor data
    /// </summary>
    public class CursorResponse<T>
    {
		/// <summary>
		///	Data
		/// </summary>
		[JsonProperty(PropertyName = "Data")]
        public  List<T> Data {get;set;}

		/// <summary>
		///	Cursor value if not all contacts can be retrieved once.
		/// </summary>
		[JsonProperty(PropertyName = "NextCursor")]
        public  string NextCursor {get;set;}

    }
}