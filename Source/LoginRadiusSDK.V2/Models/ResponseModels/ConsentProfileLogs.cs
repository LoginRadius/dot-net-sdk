//-----------------------------------------------------------------------
// <copyright file="ModelClass" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2019 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using LoginRadiusSDK.V2.Models.Enums;
namespace LoginRadiusSDK.V2.Models.ResponseModels

{

    /// <summary>
    ///	Response containg consent profile logs
    /// </summary>
    public class ConsentProfileLogs
    {
		/// <summary>
		///	List of consent logs
		/// </summary>
		[JsonProperty(PropertyName = "ConsentLogs")]
        public  List<ConsentProfileLog> ConsentLogs {get;set;}

		/// <summary>
		///	List of consetforms version
		/// </summary>
		[JsonProperty(PropertyName = "CurrentConsentFormsVersions")]
        public  List<ConsentVersions> CurrentConsentFormsVersions {get;set;}

		/// <summary>
		///	Host name
		/// </summary>
		[JsonProperty(PropertyName = "Host")]
        public  string Host {get;set;}

		/// <summary>
		///	ID of the User
		/// </summary>
		[JsonProperty(PropertyName = "Id")]
        public  string Id {get;set;}

		/// <summary>
		///	users ip address
		/// </summary>
		[JsonProperty(PropertyName = "IP")]
        public  string IP {get;set;}

		/// <summary>
		///	Logged On Date
		/// </summary>
		[JsonProperty(PropertyName = "LoggedOnDate")]
        public  DateTime LoggedOnDate {get;set;}

		/// <summary>
		///	Consent Profile Update Type
		/// </summary>
		[JsonProperty(PropertyName = "UpdateType")]
        public  ConsentProfileUpdateType UpdateType {get;set;}

		/// <summary>
		///	UserAgent
		/// </summary>
		[JsonProperty(PropertyName = "UserAgent")]
        public  string UserAgent {get;set;}

    }
}