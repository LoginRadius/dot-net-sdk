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
    ///	Model Class containing Definition of payload for RelatedProfileViews Property
    /// </summary>
    public class RelatedProfileViews
    {
		/// <summary>
		///	user's first name
		/// </summary>
		[JsonProperty(PropertyName = "FirstName")]
        public  string FirstName {get;set;}

		/// <summary>
		///	ID of the User
		/// </summary>
		[JsonProperty(PropertyName = "Id")]
        public  string Id {get;set;}

		/// <summary>
		///	user's last name
		/// </summary>
		[JsonProperty(PropertyName = "LastName")]
        public  string LastName {get;set;}

    }
}