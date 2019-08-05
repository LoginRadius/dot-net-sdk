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
    ///	Response containing Definition of Complete Status data
    /// </summary>
    public class Status
    {
		/// <summary>
		///	Status date and time
		/// </summary>
		[JsonProperty(PropertyName = "DateTime")]
        public  string DateTime {get;set;}

		/// <summary>
		///	ID of the User
		/// </summary>
		[JsonProperty(PropertyName = "Id")]
        public  string Id {get;set;}

		/// <summary>
		///	image URL should be absolute and has HTTPS domain
		/// </summary>
		[JsonProperty(PropertyName = "ImageUrl")]
        public  string ImageUrl {get;set;}

		/// <summary>
		///	Likes
		/// </summary>
		[JsonProperty(PropertyName = "Likes")]
        public  int Likes {get;set;}

		/// <summary>
		///	Status Link URL
		/// </summary>
		[JsonProperty(PropertyName = "LinkUrl")]
        public  string LinkUrl {get;set;}

		/// <summary>
		///	Name of the customer
		/// </summary>
		[JsonProperty(PropertyName = "Name")]
        public  string Name {get;set;}

		/// <summary>
		///	Status Place
		/// </summary>
		[JsonProperty(PropertyName = "Place")]
        public  string Place {get;set;}

		/// <summary>
		///	Status Source
		/// </summary>
		[JsonProperty(PropertyName = "Source")]
        public  string Source {get;set;}

		/// <summary>
		///	text user
		/// </summary>
		[JsonProperty(PropertyName = "Text")]
        public  string Text {get;set;}

    }
}