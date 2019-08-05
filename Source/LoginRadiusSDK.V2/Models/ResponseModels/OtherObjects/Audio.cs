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
    ///	Response containing Definition of Complete Audio data
    /// </summary>
    public class Audio
    {
		/// <summary>
		///	Artist
		/// </summary>
		[JsonProperty(PropertyName = "Artist")]
        public  string Artist {get;set;}

		/// <summary>
		///	Date of Creation of Profile
		/// </summary>
		[JsonProperty(PropertyName = "CreatedDate")]
        public  string CreatedDate {get;set;}

		/// <summary>
		///	Total time of audio
		/// </summary>
		[JsonProperty(PropertyName = "Duration")]
        public  string Duration {get;set;}

		/// <summary>
		///	Id of audio file
		/// </summary>
		[JsonProperty(PropertyName = "ID")]
        public  string ID {get;set;}

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
		///	Title of audio file
		/// </summary>
		[JsonProperty(PropertyName = "Title")]
        public  string Title {get;set;}

		/// <summary>
		///	Updated date
		/// </summary>
		[JsonProperty(PropertyName = "UpdatedDate")]
        public  string UpdatedDate {get;set;}

		/// <summary>
		///	String represents website url
		/// </summary>
		[JsonProperty(PropertyName = "Url")]
        public  string Url {get;set;}

    }
}