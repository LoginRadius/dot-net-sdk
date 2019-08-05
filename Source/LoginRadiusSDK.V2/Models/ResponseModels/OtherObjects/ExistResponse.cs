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
    ///	Response containing Definition Complete ExistResponse data
    /// </summary>
    public class ExistResponse
    {
		/// <summary>
		///	IsExist
		/// </summary>
		[JsonProperty(PropertyName = "IsExist")]
        public  bool IsExist {get;set;}

    }
}