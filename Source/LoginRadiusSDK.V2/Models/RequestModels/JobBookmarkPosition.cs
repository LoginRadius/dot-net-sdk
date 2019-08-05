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
    ///	Model Class containing Definition for JobBookmarkPosition Property
    /// </summary>
    public class JobBookmarkPosition
    {
		/// <summary>
		///	Position title
		/// </summary>
		[JsonProperty(PropertyName = "Title")]
        public  string Title {get;set;}

    }
}