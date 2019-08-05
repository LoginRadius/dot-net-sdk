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
    ///	Response containing Definition of Complete Verification data
    /// </summary>
    public class EmailVerificationTokenResponse
    {
		/// <summary>
		///	Verification token received in the email
		/// </summary>
		[JsonProperty(PropertyName = "VerificationToken")]
        public  string VerificationToken {get;set;}

    }
}