//-----------------------------------------------------------------------
// <copyright file="ModelClass" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2025 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Newtonsoft.Json;
namespace LoginRadiusSDK.V2.Models.RequestModels

{

    /// <summary>
    ///	Model Class containing Definition for Badges Property
    /// </summary>
    public class Badges
    {
		/// <summary>
		///	Badge ID
		/// </summary>
		[JsonProperty(PropertyName = "BadgeId")]
        public  string BadgeId {get;set;}

		/// <summary>
		///	Badge Message
		/// </summary>
		[JsonProperty(PropertyName = "BadgeMessage")]
        public  string BadgeMessage {get;set;}

		/// <summary>
		///	Bage Id
		/// </summary>
		[JsonProperty(PropertyName = "BageId")]
        public  string BageId {get;set;}

		/// <summary>
		///	Bage Message
		/// </summary>
		[JsonProperty(PropertyName = "BageMessage")]
        public  string BageMessage {get;set;}

		/// <summary>
		///	detailed information
		/// </summary>
		[JsonProperty(PropertyName = "Description")]
        public  string Description {get;set;}

		/// <summary>
		///	image URL should be absolute and has HTTPS domain
		/// </summary>
		[JsonProperty(PropertyName = "ImageUrl")]
        public  string ImageUrl {get;set;}

		/// <summary>
		///	Badge Name
		/// </summary>
		[JsonProperty(PropertyName = "Name")]
        public  string Name {get;set;}

    }
}