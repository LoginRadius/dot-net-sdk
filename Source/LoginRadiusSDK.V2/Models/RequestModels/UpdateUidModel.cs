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
    ///	Payload containing Update UID
    /// </summary>
    public class UpdateUidModel
    {
		/// <summary>
		///	New Uid
		/// </summary>
		[JsonProperty(PropertyName = "NewUid")]
        public  string NewUid {get;set;}

    }
}