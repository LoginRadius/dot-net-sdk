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
    ///	Response containing Definition of Complete Album data
    /// </summary>
    public class FacebookAlbumImages
    {
		/// <summary>
		///	Photo dimensions
		/// </summary>
		[JsonProperty(PropertyName = "Dimensions")]
        public  string Dimensions {get;set;}

		/// <summary>
		///	Images
		/// </summary>
		[JsonProperty(PropertyName = "Image")]
        public  string Image {get;set;}

    }
}