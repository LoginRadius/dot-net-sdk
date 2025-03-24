//-----------------------------------------------------------------------
// <copyright file="ModelClass" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2025 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Newtonsoft.Json;
namespace LoginRadiusSDK.V2.Models.ResponseModels.OtherObjects

{

    /// <summary>
    ///	Response containing Definition for Complete AuthSendVerificationEmailForLinkingSocialProfiles API Response
    /// </summary>
    public class PostResponseResendEmailVerification
    {
		/// <summary>
		///	check data is posted
		/// </summary>
		[JsonProperty(PropertyName = "IsPosted")]
        public  bool IsPosted {get;set;}

		/// <summary>
		///	The uuid received in the response
		/// </summary>
		[JsonProperty(PropertyName = "uuid")]
        public  string Uuid {get;set;}

    }
}