//-----------------------------------------------------------------------
// <copyright file="ModelClass" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2019 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Newtonsoft.Json;
using LoginRadiusSDK.V2.Models.Enums;
namespace LoginRadiusSDK.V2.Models.RequestModels

{

    /// <summary>
    ///	Model Class containing Definition for Languages Property
    /// </summary>
    public class Languages
    {
		/// <summary>
		///	Language id
		/// </summary>
		[JsonProperty(PropertyName = "Id")]
        public  string Id {get;set;}

		/// <summary>
		///	Name of language
		/// </summary>
		[JsonProperty(PropertyName = "Name")]
        public  string Name {get;set;}

		/// <summary>
		///	Languages operation Type
		/// </summary>
		[JsonProperty(PropertyName = "op")]
        public  OperationType? Op {get;set;}

		/// <summary>
		///	Proficiency in language
		/// </summary>
		[JsonProperty(PropertyName = "Proficiency")]
        public  string Proficiency {get;set;}

    }
}