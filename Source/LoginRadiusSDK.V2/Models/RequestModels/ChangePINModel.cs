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
    ///	Model Class containing Definition for change PIN Property
    /// </summary>
    public class ChangePINModel
    {
		/// <summary>
		///	New PIN of user
		/// </summary>
		[JsonProperty(PropertyName = "NewPIN")]
        public  string NewPIN {get;set;}

		/// <summary>
		///	Old PIN of user
		/// </summary>
		[JsonProperty(PropertyName = "OldPIN")]
        public  string OldPIN {get;set;}

    }
}