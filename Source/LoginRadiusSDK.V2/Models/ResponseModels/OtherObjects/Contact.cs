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
    ///	Response containing Definition of Complete Contact data
    /// </summary>
    public class Contact
    {
		/// <summary>
		///	Country of the user
		/// </summary>
		[JsonProperty(PropertyName = "Country")]
        public  string Country {get;set;}

		/// <summary>
		///	user's date of birth
		/// </summary>
		[JsonProperty(PropertyName = "DateOfBirth")]
        public  string DateOfBirth {get;set;}

		/// <summary>
		///	user's email address
		/// </summary>
		[JsonProperty(PropertyName = "EmailID")]
        public  string EmailID {get;set;}

		/// <summary>
		///	user's gender
		/// </summary>
		[JsonProperty(PropertyName = "Gender")]
        public  string Gender {get;set;}

		/// <summary>
		///	Contact ID
		/// </summary>
		[JsonProperty(PropertyName = "ID")]
        public  string ID {get;set;}

		/// <summary>
		///	image URL should be absolute and has HTTPS domain
		/// </summary>
		[JsonProperty(PropertyName = "ImageUrl")]
        public  string ImageUrl {get;set;}

		/// <summary>
		///	Industry name
		/// </summary>
		[JsonProperty(PropertyName = "Industry")]
        public  string Industry {get;set;}

		/// <summary>
		///	Contact location
		/// </summary>
		[JsonProperty(PropertyName = "Location")]
        public  string Location {get;set;}

		/// <summary>
		///	Contact's name
		/// </summary>
		[JsonProperty(PropertyName = "Name")]
        public  string Name {get;set;}

		/// <summary>
		///	Phone number of contact
		/// </summary>
		[JsonProperty(PropertyName = "PhoneNumber")]
        public  string PhoneNumber {get;set;}

		/// <summary>
		///	Profile URL
		/// </summary>
		[JsonProperty(PropertyName = "ProfileUrl")]
        public  string ProfileUrl {get;set;}

		/// <summary>
		///	Main body of the Status update.
		/// </summary>
		[JsonProperty(PropertyName = "Status")]
        public  string Status {get;set;}

    }
}