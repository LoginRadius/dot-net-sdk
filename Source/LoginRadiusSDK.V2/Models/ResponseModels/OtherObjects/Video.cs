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
    ///	Response containing Definition for Complete Video data
    /// </summary>
    public class Video
    {
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
		///	Video direct link
		/// </summary>
		[JsonProperty(PropertyName = "DirectLink")]
        public  string DirectLink {get;set;}

		/// <summary>
		///	Video duration
		/// </summary>
		[JsonProperty(PropertyName = "Duration")]
        public  string Duration {get;set;}

		/// <summary>
		///	Embed html of video
		/// </summary>
		[JsonProperty(PropertyName = "EmbedHtml")]
        public  string EmbedHtml {get;set;}

		/// <summary>
		///	Video id
		/// </summary>
		[JsonProperty(PropertyName = "ID")]
        public  string ID {get;set;}

		/// <summary>
		///	image URL should be absolute and has HTTPS domain
		/// </summary>
		[JsonProperty(PropertyName = "Image")]
        public  string Image {get;set;}

		/// <summary>
		///	Video name
		/// </summary>
		[JsonProperty(PropertyName = "Name")]
        public  string Name {get;set;}

		/// <summary>
		///	Video owner id
		/// </summary>
		[JsonProperty(PropertyName = "OwnerId")]
        public  string OwnerId {get;set;}

		/// <summary>
		///	Video owner name
		/// </summary>
		[JsonProperty(PropertyName = "OwnerName")]
        public  string OwnerName {get;set;}

		/// <summary>
		///	Source of video
		/// </summary>
		[JsonProperty(PropertyName = "Source")]
        public  string Source {get;set;}

		/// <summary>
		///	Updated date
		/// </summary>
		[JsonProperty(PropertyName = "UpdatedDate")]
        public  string UpdatedDate {get;set;}

    }
}