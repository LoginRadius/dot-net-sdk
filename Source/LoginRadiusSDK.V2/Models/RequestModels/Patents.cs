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
    ///	Model Class containing Definition for Patents Property
    /// </summary>
    public class Patents
    {
		/// <summary>
		///	Date of patents
		/// </summary>
		[JsonProperty(PropertyName = "Date")]
        public  string Date {get;set;}

		/// <summary>
		///	Id of the patents
		/// </summary>
		[JsonProperty(PropertyName = "Id")]
        public  string Id {get;set;}

		/// <summary>
		///	Title of the patents
		/// </summary>
		[JsonProperty(PropertyName = "Title")]
        public  string Title {get;set;}

    }
}