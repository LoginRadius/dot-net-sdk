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
    ///	
    /// </summary>
    public class MultiSmsOtp
    {
		/// <summary>
		///	
		/// </summary>
		[JsonProperty(PropertyName = "Name")]
        public  string Name {get;set;}

		/// <summary>
		///	
		/// </summary>
		[JsonProperty(PropertyName = "Phone")]
        public  string Phone {get;set;}

		/// <summary>
		///	
		/// </summary>
		[JsonProperty(PropertyName = "Uid")]
        public  string Uid {get;set;}

    }
}