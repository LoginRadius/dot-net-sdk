//-----------------------------------------------------------------------
// <copyright file="ModelClass" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2019 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using Newtonsoft.Json;
namespace LoginRadiusSDK.V2.Models.ResponseModels.UserProfile

{

    /// <summary>
    ///	Response containing Definition for Complete profile data
    /// </summary>
    public class Identity:UserProfile
    {
		/// <summary>
		///	User Identities list
		/// </summary>
		[JsonProperty(PropertyName = "Identities")]
        public  List<SocialUserProfile> Identities {get;set;}

    }
}