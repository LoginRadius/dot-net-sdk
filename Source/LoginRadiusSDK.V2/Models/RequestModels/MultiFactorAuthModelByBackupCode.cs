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
    ///	Model Class containing Definition of payload for MultiFactorAuth By BackupCode API
    /// </summary>
    public class MultiFactorAuthModelByBackupCode
    {
		/// <summary>
		///	The Code generated as a recourse
		/// </summary>
		[JsonProperty(PropertyName = "BackupCode")]
        public  string BackupCode {get;set;}

    }
}