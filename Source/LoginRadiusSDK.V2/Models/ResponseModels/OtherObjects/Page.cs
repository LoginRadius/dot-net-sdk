//-----------------------------------------------------------------------
// <copyright file="ModelClass" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2019 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using Newtonsoft.Json;
namespace LoginRadiusSDK.V2.Models.ResponseModels.OtherObjects

{

    /// <summary>
    ///	Response containing Definition of Complete page data
    /// </summary>
    public class Page
    {
		/// <summary>
		///	About value that need to be inserted
		/// </summary>
		[JsonProperty(PropertyName = "About")]
        public  string About {get;set;}

		/// <summary>
		///	Array of Objects,String represents Id, Name and  Issuer
		/// </summary>
		[JsonProperty(PropertyName = "Awards")]
        public  string Awards {get;set;}

		/// <summary>
		///	Page category
		/// </summary>
		[JsonProperty(PropertyName = "Category")]
        public  string Category {get;set;}

		/// <summary>
		///	Category list
		/// </summary>
		[JsonProperty(PropertyName = "CategoryList")]
        public  List<PageCategoryList> CategoryList {get;set;}

		/// <summary>
		///	checkin count
		/// </summary>
		[JsonProperty(PropertyName = "CheckinCount")]
        public  string CheckinCount {get;set;}

		/// <summary>
		///	Image url
		/// </summary>
		[JsonProperty(PropertyName = "CoverImage")]
        public  PageCover CoverImage {get;set;}

		/// <summary>
		///	detailed information
		/// </summary>
		[JsonProperty(PropertyName = "Description")]
        public  string Description {get;set;}

		/// <summary>
		///	Employee count range
		/// </summary>
		[JsonProperty(PropertyName = "EmployeeCountRange")]
        public  PageCodeName EmployeeCountRange {get;set;}

		/// <summary>
		///	Founded
		/// </summary>
		[JsonProperty(PropertyName = "Founded")]
        public  string Founded {get;set;}

		/// <summary>
		///	Page id
		/// </summary>
		[JsonProperty(PropertyName = "ID")]
        public  string ID {get;set;}

		/// <summary>
		///	Image url
		/// </summary>
		[JsonProperty(PropertyName = "Image")]
        public  string Image {get;set;}

		/// <summary>
		///	List of Industries
		/// </summary>
		[JsonProperty(PropertyName = "Industries")]
        public  List<PageCodeName> Industries {get;set;}

		/// <summary>
		///	Page likes
		/// </summary>
		[JsonProperty(PropertyName = "Likes")]
        public  string Likes {get;set;}

		/// <summary>
		///	Location of page
		/// </summary>
		[JsonProperty(PropertyName = "Locations")]
        public  List<PageLocations> Locations {get;set;}

		/// <summary>
		///	Page mission
		/// </summary>
		[JsonProperty(PropertyName = "Mission")]
        public  string Mission {get;set;}

		/// <summary>
		///	Page name
		/// </summary>
		[JsonProperty(PropertyName = "Name")]
        public  string Name {get;set;}

		/// <summary>
		///	New Phone Number
		/// </summary>
		[JsonProperty(PropertyName = "Phone")]
        public  string Phone {get;set;}

		/// <summary>
		///	Products
		/// </summary>
		[JsonProperty(PropertyName = "Products")]
        public  string Products {get;set;}

		/// <summary>
		///	Published
		/// </summary>
		[JsonProperty(PropertyName = "Published")]
        public  bool Published {get;set;}

		/// <summary>
		///	Release Date
		/// </summary>
		[JsonProperty(PropertyName = "ReleaseDate")]
        public  string ReleaseDate {get;set;}

		/// <summary>
		///	Specialties
		/// </summary>
		[JsonProperty(PropertyName = "Specialties")]
        public  Speciality Specialties {get;set;}

		/// <summary>
		///	Page Status
		/// </summary>
		[JsonProperty(PropertyName = "Status")]
        public  PageCodeName Status {get;set;}

		/// <summary>
		///	Stock Exchange
		/// </summary>
		[JsonProperty(PropertyName = "StockExchange")]
        public  PageCodeName StockExchange {get;set;}

		/// <summary>
		///	Talking About Count
		/// </summary>
		[JsonProperty(PropertyName = "TalkingAboutCount")]
        public  string TalkingAboutCount {get;set;}

		/// <summary>
		///	String represents website url
		/// </summary>
		[JsonProperty(PropertyName = "Url")]
        public  string Url {get;set;}

		/// <summary>
		///	Username of the user
		/// </summary>
		[JsonProperty(PropertyName = "UserName")]
        public  string UserName {get;set;}

		/// <summary>
		///	Personal Website a User has
		/// </summary>
		[JsonProperty(PropertyName = "Website")]
        public  string Website {get;set;}

    }
}