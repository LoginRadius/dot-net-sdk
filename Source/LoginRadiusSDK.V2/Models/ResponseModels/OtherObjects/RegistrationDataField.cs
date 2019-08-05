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
    ///	Response containing Definition of Custom registration data object
    /// </summary>
    public class RegistrationDataField:RegistrationDataFieldBasic
    {
		/// <summary>
		///	Validation Code/Secret Code,Code Parameter, given when Login Dialog is performed
		/// </summary>
		[JsonProperty(PropertyName = "Code")]
        public  string Code {get;set;}

    }
}