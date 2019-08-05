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
    public class Album
    {
		/// <summary>
		///	Image url
		/// </summary>
		[JsonProperty(PropertyName = "CoverImageUrl")]
        public  string CoverImageUrl {get;set;}

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
		///	Directory's url
		/// </summary>
		[JsonProperty(PropertyName = "DirectoryUrl")]
        public  string DirectoryUrl {get;set;}

		/// <summary>
		///	ID of the User
		/// </summary>
		[JsonProperty(PropertyName = "ID")]
        public  string ID {get;set;}

		/// <summary>
		///	Number of images
		/// </summary>
		[JsonProperty(PropertyName = "ImageCount")]
        public  string ImageCount {get;set;}

		/// <summary>
		///	user's location
		/// </summary>
		[JsonProperty(PropertyName = "Location")]
        public  string Location {get;set;}

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
		///	Title of Linked URL
		/// </summary>
		[JsonProperty(PropertyName = "Title")]
        public  string Title {get;set;}

		/// <summary>
		///	String to identify the type of parameter
		/// </summary>
		[JsonProperty(PropertyName = "Type")]
        public  string Type {get;set;}

		/// <summary>
		///	Updated date
		/// </summary>
		[JsonProperty(PropertyName = "UpdatedDate")]
        public  string UpdatedDate {get;set;}

    }
}