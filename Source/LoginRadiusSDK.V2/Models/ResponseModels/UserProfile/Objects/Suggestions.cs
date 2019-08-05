//-----------------------------------------------------------------------
// <copyright file="ModelClass" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2019 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using Newtonsoft.Json;
namespace LoginRadiusSDK.V2.Models.ResponseModels.UserProfile.Objects

{

    /// <summary>
    ///	Response containing Definition for Complete Suggestions data
    /// </summary>
    public class Suggestions
    {
		/// <summary>
		///	Companies needs to follow
		/// </summary>
		[JsonProperty(PropertyName = "CompaniestoFollow")]
        public  List<NameId> CompaniestoFollow {get;set;}

		/// <summary>
		///	Industries needs to follow
		/// </summary>
		[JsonProperty(PropertyName = "IndustriestoFollow")]
        public  List<NameId> IndustriestoFollow {get;set;}

		/// <summary>
		///	News sources needs to follow
		/// </summary>
		[JsonProperty(PropertyName = "NewssourcetoFollow")]
        public  List<NameId> NewssourcetoFollow {get;set;}

		/// <summary>
		///	People needs to follow
		/// </summary>
		[JsonProperty(PropertyName = "PeopletoFollow")]
        public  List<NameId> PeopletoFollow {get;set;}

    }
}