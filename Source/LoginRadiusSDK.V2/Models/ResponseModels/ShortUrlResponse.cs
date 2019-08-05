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
    ///	Response containing Definition for Complete ShortUrl data
    /// </summary>
    public class ShortUrlResponse
    {
		/// <summary>
		///	short url
		/// </summary>
		[JsonProperty(PropertyName = "ShortUrl")]
        public  string ShortUrl {get;set;}

		/// <summary>
		///	Base 36 key of url
		/// </summary>
		[JsonProperty(PropertyName = "UrlBase36Key")]
        public  string UrlBase36Key {get;set;}

		/// <summary>
		///	Url key
		/// </summary>
		[JsonProperty(PropertyName = "UrlKey")]
        public  long UrlKey {get;set;}

    }
}