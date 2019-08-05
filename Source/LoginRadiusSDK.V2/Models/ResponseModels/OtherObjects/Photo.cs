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
    ///	Response containing Definition of Complete Photo data
    /// </summary>
    public class Photo
    {
		/// <summary>
		///	User's Album Id
		/// </summary>
		[JsonProperty(PropertyName = "AlbumId")]
        public  string AlbumId {get;set;}

		/// <summary>
		///	Date of Creation of Profile
		/// </summary>
		[JsonProperty(PropertyName = "CreatedDate")]
        public  string CreatedDate {get;set;}

		/// <summary>
		///	detailed information
		/// </summary>
		[JsonProperty(PropertyName = "Description")]
        public  string Description {get;set;}

		/// <summary>
		///	DirectUrl
		/// </summary>
		[JsonProperty(PropertyName = "DirectUrl")]
        public  string DirectUrl {get;set;}

		/// <summary>
		///	Height of the image
		/// </summary>
		[JsonProperty(PropertyName = "Height")]
        public  string Height {get;set;}

		/// <summary>
		///	Id of the image
		/// </summary>
		[JsonProperty(PropertyName = "ID")]
        public  string ID {get;set;}

		/// <summary>
		///	Images
		/// </summary>
		[JsonProperty(PropertyName = "Images")]
        public  List<FacebookAlbumImages> Images {get;set;}

		/// <summary>
		///	image URL should be absolute and has HTTPS domain
		/// </summary>
		[JsonProperty(PropertyName = "ImageUrl")]
        public  string ImageUrl {get;set;}

		/// <summary>
		///	Image's link
		/// </summary>
		[JsonProperty(PropertyName = "Link")]
        public  string Link {get;set;}

		/// <summary>
		///	Photo Location
		/// </summary>
		[JsonProperty(PropertyName = "Location")]
        public  string Location {get;set;}

		/// <summary>
		///	Name of the image
		/// </summary>
		[JsonProperty(PropertyName = "Name")]
        public  string Name {get;set;}

		/// <summary>
		///	ID of account owner
		/// </summary>
		[JsonProperty(PropertyName = "OwnerId")]
        public  string OwnerId {get;set;}

		/// <summary>
		///	Name of account owner
		/// </summary>
		[JsonProperty(PropertyName = "OwnerName")]
        public  string OwnerName {get;set;}

		/// <summary>
		///	Updated date
		/// </summary>
		[JsonProperty(PropertyName = "UpdatedDate")]
        public  string UpdatedDate {get;set;}

		/// <summary>
		///	Width of the image
		/// </summary>
		[JsonProperty(PropertyName = "Width")]
        public  string Width {get;set;}

    }
}