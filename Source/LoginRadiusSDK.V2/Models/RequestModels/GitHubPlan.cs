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
    ///	Model Class containing Definition for GitHubPlan Property
    /// </summary>
    public class GitHubPlan
    {
		/// <summary>
		///	Github plan collaborators
		/// </summary>
		[JsonProperty(PropertyName = "Collaborators")]
        public  string Collaborators {get;set;}

		/// <summary>
		///	Github plan name
		/// </summary>
		[JsonProperty(PropertyName = "Name")]
        public  string Name {get;set;}

		/// <summary>
		///	Private repos of github
		/// </summary>
		[JsonProperty(PropertyName = "PrivateRepos")]
        public  string PrivateRepos {get;set;}

		/// <summary>
		///	Github plan space
		/// </summary>
		[JsonProperty(PropertyName = "Space")]
        public  string Space {get;set;}

    }
}