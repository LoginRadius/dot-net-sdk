//-----------------------------------------------------------------------
// <copyright file="ModelClass" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2019 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Newtonsoft.Json;
namespace LoginRadiusSDK.V2.Models.RequestModels

{

    /// <summary>
    ///	Model Class containing Definition of payload for Status API
    /// </summary>
    public class StatusModel
    {
		/// <summary>
		///	Message displayed below the description(Requires URL, Under 70 Characters).
		/// </summary>
		[JsonProperty(PropertyName = "caption")]
        public  string Caption {get;set;}

		/// <summary>
		///	Description of the displayed URL and Image
		/// </summary>
		[JsonProperty(PropertyName = "description")]
        public  string Description {get;set;}

		/// <summary>
		///	image URL should be absolute and has HTTPS domain
		/// </summary>
		[JsonProperty(PropertyName = "imageurl")]
        public  string Imageurl {get;set;}

		/// <summary>
		///	short url
		/// </summary>
		[JsonProperty(PropertyName = "shorturl")]
        public  string Shorturl {get;set;}

		/// <summary>
		///	Main body of the Status update.
		/// </summary>
		[JsonProperty(PropertyName = "status")]
        public  string Status {get;set;}

		/// <summary>
		///	Title of Linked URL
		/// </summary>
		[JsonProperty(PropertyName = "title")]
        public  string Title {get;set;}

		/// <summary>
		///	String represents website url
		/// </summary>
		[JsonProperty(PropertyName = "url")]
        public  string Url {get;set;}

    }
}