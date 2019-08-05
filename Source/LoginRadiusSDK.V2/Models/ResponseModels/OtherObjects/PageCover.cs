//-----------------------------------------------------------------------
// <copyright file="ModelClass" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2019 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Newtonsoft.Json;
namespace LoginRadiusSDK.V2.Models.ResponseModels.OtherObjects

{

    /// <summary>
    ///	Response containing Definition of Complete Page Cover data
    /// </summary>
    public class PageCover
    {
		/// <summary>
		///	Page cover id
		/// </summary>
		[JsonProperty(PropertyName = "Id")]
        public  string Id {get;set;}

		/// <summary>
		///	Page cover offset X
		/// </summary>
		[JsonProperty(PropertyName = "OffsetX")]
        public  string OffsetX {get;set;}

		/// <summary>
		///	Page cover offset Y
		/// </summary>
		[JsonProperty(PropertyName = "OffsetY")]
        public  string OffsetY {get;set;}

		/// <summary>
		///	Page cover source
		/// </summary>
		[JsonProperty(PropertyName = "Source")]
        public  string Source {get;set;}

    }
}