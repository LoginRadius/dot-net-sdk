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
    ///	Response containing Definition of Complete Status Update data
    /// </summary>
    public class StatusUpdateStats
    {
		/// <summary>
		///	Comments
		/// </summary>
		[JsonProperty(PropertyName = "Comments")]
        public  int Comments {get;set;}

		/// <summary>
		///	Likes
		/// </summary>
		[JsonProperty(PropertyName = "Likes")]
        public  int Likes {get;set;}

		/// <summary>
		///	share
		/// </summary>
		[JsonProperty(PropertyName = "Shares")]
        public  int Shares {get;set;}

    }
}