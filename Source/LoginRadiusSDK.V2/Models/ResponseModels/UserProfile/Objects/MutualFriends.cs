//-----------------------------------------------------------------------
// <copyright file="ModelClass" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2019 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Newtonsoft.Json;
namespace LoginRadiusSDK.V2.Models.ResponseModels.UserProfile.Objects

{

    /// <summary>
    ///	Response containing Definition for Complete MutualFriends data
    /// </summary>
    public class MutualFriends
    {
		/// <summary>
		///	Birthday of mutual friend
		/// </summary>
		[JsonProperty(PropertyName = "Birthday")]
        public  string Birthday {get;set;}

		/// <summary>
		///	first name of mutual friend
		/// </summary>
		[JsonProperty(PropertyName = "FirstName")]
        public  string FirstName {get;set;}

		/// <summary>
		///	Gender of mutual friend
		/// </summary>
		[JsonProperty(PropertyName = "Gender")]
        public  string Gender {get;set;}

		/// <summary>
		///	Hometown of mutual friend
		/// </summary>
		[JsonProperty(PropertyName = "Hometown")]
        public  string Hometown {get;set;}

		/// <summary>
		///	Id of mutual friend
		/// </summary>
		[JsonProperty(PropertyName = "Id")]
        public  string Id {get;set;}

		/// <summary>
		///	Last name of mutual friend
		/// </summary>
		[JsonProperty(PropertyName = "LastName")]
        public  string LastName {get;set;}

		/// <summary>
		///	Link of mutual friend
		/// </summary>
		[JsonProperty(PropertyName = "Link")]
        public  string Link {get;set;}

		/// <summary>
		///	Name of mutual friend
		/// </summary>
		[JsonProperty(PropertyName = "Name")]
        public  string Name {get;set;}

    }
}