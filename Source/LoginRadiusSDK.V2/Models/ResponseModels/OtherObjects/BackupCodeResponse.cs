//-----------------------------------------------------------------------
// <copyright file="ModelClass" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2019 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using Newtonsoft.Json;
namespace LoginRadiusSDK.V2.Models.ResponseModels.OtherObjects

{

    /// <summary>
    ///	Response containing Definition of Complete Backup Code data
    /// </summary>
    public class BackupCodeResponse
    {
		/// <summary>
		///	The Code generated as a recourse
		/// </summary>
		[JsonProperty(PropertyName = "BackUpCodes")]
        public  List<string> BackUpCodes {get;set;}

    }
}