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
    ///	Model Class containing Definition for Memberurlresources Property
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