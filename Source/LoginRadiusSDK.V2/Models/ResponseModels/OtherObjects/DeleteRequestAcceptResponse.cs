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
    ///	Response containing Definition of Delete Request
    /// </summary>
    public class DeleteRequestAcceptResponse
    {
		/// <summary>
		///	Is Delete Request Accepted
		/// </summary>
		[JsonProperty(PropertyName = "IsDeleteRequestAccepted")]
        public  bool IsDeleteRequestAccepted {get;set;}

    }
}