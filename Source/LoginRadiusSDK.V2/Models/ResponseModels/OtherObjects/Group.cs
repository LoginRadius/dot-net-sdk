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
    ///	Response containing Definition of Complete group data
    /// </summary>
    public class Group
    {
		/// <summary>
		///	Country of the user
		/// </summary>
		[JsonProperty(PropertyName = "Country")]
        public  string Country {get;set;}

		/// <summary>
		///	detailed information
		/// </summary>
		[JsonProperty(PropertyName = "Description")]
        public  string Description {get;set;}

		/// <summary>
		///	user's email
		/// </summary>
		[JsonProperty(PropertyName = "Email")]
        public  string Email {get;set;}

		/// <summary>
		///	Identity providers
		/// </summary>
		[JsonProperty(PropertyName = "ID")]
        public  string ID {get;set;}

		/// <summary>
		///	Images
		/// </summary>
		[JsonProperty(PropertyName = "Image")]
        public  string Image {get;set;}

		/// <summary>
		///	logo
		/// </summary>
		[JsonProperty(PropertyName = "Logo")]
        public  string Logo {get;set;}

		/// <summary>
		///	Number of members
		/// </summary>
		[JsonProperty(PropertyName = "MemberCount")]
        public  string MemberCount {get;set;}

		/// <summary>
		///	Name of the customer
		/// </summary>
		[JsonProperty(PropertyName = "Name")]
        public  string Name {get;set;}

		/// <summary>
		///	Postal code value that need to be updated
		/// </summary>
		[JsonProperty(PropertyName = "PostalCode")]
        public  string PostalCode {get;set;}

		/// <summary>
		///	String to identify the type of parameter
		/// </summary>
		[JsonProperty(PropertyName = "Type")]
        public  string Type {get;set;}

    }
}