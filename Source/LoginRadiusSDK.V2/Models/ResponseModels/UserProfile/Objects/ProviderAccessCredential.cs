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
    ///	Response containing Definition for Complete Provider Access Credential data
    /// </summary>
    public class ProviderAccessCredential
    {
		/// <summary>
		///	Uniquely generated identifier key by LoginRadius that is activated after successful authentication.
		/// </summary>
		[JsonProperty(PropertyName = "AccessToken")]
        public  string AccessToken {get;set;}

		/// <summary>
		///	secret token of the provider
		/// </summary>
		[JsonProperty(PropertyName = "TokenSecret")]
        public  string TokenSecret {get;set;}

    }
}