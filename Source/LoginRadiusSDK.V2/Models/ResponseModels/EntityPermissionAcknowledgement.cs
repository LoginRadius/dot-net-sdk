//-----------------------------------------------------------------------
// <copyright file="ModelClass" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2019 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Newtonsoft.Json;
namespace LoginRadiusSDK.V2.Models.ResponseModels

{

    /// <summary>
    ///	Response containing Definition of Complete Validation data
    /// </summary>
    public class EntityPermissionAcknowledgement
    {
		/// <summary>
		///	Webhook is allowed or not
		/// </summary>
		[JsonProperty(PropertyName = "IsAllowed")]
        public  bool IsAllowed {get;set;}

    }
}