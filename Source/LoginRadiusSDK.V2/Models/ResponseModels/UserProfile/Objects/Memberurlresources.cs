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
    ///	Response containing Definition for Complete Member url resources data
    /// </summary>
    public class Memberurlresources
    {
		/// <summary>
		///	String represents website url
		/// </summary>
		[JsonProperty(PropertyName = "Url")]
        public  string Url {get;set;}

		/// <summary>
		///	URL name
		/// </summary>
		[JsonProperty(PropertyName = "UrlName")]
        public  string UrlName {get;set;}

    }
}