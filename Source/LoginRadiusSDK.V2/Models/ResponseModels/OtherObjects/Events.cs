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
    ///	Response containing Definition of Complete Events data
    /// </summary>
    public class Events
    {
		/// <summary>
		///	detailed information
		/// </summary>
		[JsonProperty(PropertyName = "Description")]
        public  string Description {get;set;}

		/// <summary>
		///	EndTime
		/// </summary>
		[JsonProperty(PropertyName = "EndTime")]
        public  string EndTime {get;set;}

		/// <summary>
		///	ID of the User
		/// </summary>
		[JsonProperty(PropertyName = "ID")]
        public  string ID {get;set;}

		/// <summary>
		///	Event Location
		/// </summary>
		[JsonProperty(PropertyName = "Location")]
        public  string Location {get;set;}

		/// <summary>
		///	Event name
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
		///	Privacy
		/// </summary>
		[JsonProperty(PropertyName = "Privacy")]
        public  string Privacy {get;set;}

		/// <summary>
		///	RsvpStatus
		/// </summary>
		[JsonProperty(PropertyName = "RsvpStatus")]
        public  string RsvpStatus {get;set;}

		/// <summary>
		///	Start time
		/// </summary>
		[JsonProperty(PropertyName = "StartTime")]
        public  string StartTime {get;set;}

		/// <summary>
		///	Updated date
		/// </summary>
		[JsonProperty(PropertyName = "UpdatedDate")]
        public  string UpdatedDate {get;set;}

    }
}