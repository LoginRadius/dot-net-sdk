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
    ///	Response containing Definition of Complete Post data
    /// </summary>
    public class Post
    {
		/// <summary>
		///	ID of the User
		/// </summary>
		[JsonProperty(PropertyName = "ID")]
        public  string ID {get;set;}

		/// <summary>
		///	Likes
		/// </summary>
		[JsonProperty(PropertyName = "Likes")]
        public  int Likes {get;set;}

		/// <summary>
		///	message
		/// </summary>
		[JsonProperty(PropertyName = "Message")]
        public  string Message {get;set;}

		/// <summary>
		///	Name of the customer
		/// </summary>
		[JsonProperty(PropertyName = "Name")]
        public  string Name {get;set;}

		/// <summary>
		///	Images
		/// </summary>
		[JsonProperty(PropertyName = "Picture")]
        public  string Picture {get;set;}

		/// <summary>
		///	Location of user
		/// </summary>
		[JsonProperty(PropertyName = "Place")]
        public  string Place {get;set;}

		/// <summary>
		///	share
		/// </summary>
		[JsonProperty(PropertyName = "Share")]
        public  int Share {get;set;}

		/// <summary>
		///	Start time
		/// </summary>
		[JsonProperty(PropertyName = "StartTime")]
        public  string StartTime {get;set;}

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
		///	last update time
		/// </summary>
		[JsonProperty(PropertyName = "UpdateTime")]
        public  string UpdateTime {get;set;}

    }
}