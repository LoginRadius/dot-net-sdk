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
    ///	Model Class containing Definition for Current Status Property
    /// </summary>
    public class CurrentStatus
    {
		/// <summary>
		///	Current status created date
		/// </summary>
		[JsonProperty(PropertyName = "CreatedDate")]
        public  string CreatedDate {get;set;}

		/// <summary>
		///	Current status id
		/// </summary>
		[JsonProperty(PropertyName = "Id")]
        public  string Id {get;set;}

		/// <summary>
		///	Current status source
		/// </summary>
		[JsonProperty(PropertyName = "Source")]
        public  string Source {get;set;}

		/// <summary>
		///	Current status text
		/// </summary>
		[JsonProperty(PropertyName = "Text")]
        public  string Text {get;set;}

    }
}