//-----------------------------------------------------------------------
// <copyright file="ModelClass" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2019 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Newtonsoft.Json;
namespace LoginRadiusSDK.V2.Models.ResponseModels.UserProfile.Objects

{

    /// <summary>
    ///	Response containing Definition for Complete Job Bookmark Position data
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