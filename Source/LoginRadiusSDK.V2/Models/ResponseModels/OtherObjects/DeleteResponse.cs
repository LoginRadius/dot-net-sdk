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
    ///	Response containing Definition of Delete Request
    /// </summary>
    public class DeleteResponse
    {
		/// <summary>
		///	boolean type value, default is true
		/// </summary>
		[JsonProperty(PropertyName = "IsDeleted")]
        public  bool IsDeleted {get;set;}

		/// <summary>
		///	Number of Records Deleted
		/// </summary>
		[JsonProperty(PropertyName = "RecordsDeleted")]
        public  int? RecordsDeleted {get;set;}

    }
}