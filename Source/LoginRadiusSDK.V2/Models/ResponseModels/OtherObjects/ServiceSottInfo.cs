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
    ///	Response containing Definition of Complete Sott data
    /// </summary>
    public class ServiceSottInfo
    {
		/// <summary>
		///	EndTime
		/// </summary>
		[JsonProperty(PropertyName = "EndTime")]
        public  string EndTime {get;set;}

		/// <summary>
		///	Forwarded IP
		/// </summary>
		[JsonProperty(PropertyName = "ForWardedIP")]
        public  string ForWardedIP {get;set;}

		/// <summary>
		///	users ip address
		/// </summary>
		[JsonProperty(PropertyName = "IP")]
        public  string IP {get;set;}

		/// <summary>
		///	Start time
		/// </summary>
		[JsonProperty(PropertyName = "StartTime")]
        public  string StartTime {get;set;}

		/// <summary>
		///	Difference between start time and end time
		/// </summary>
		[JsonProperty(PropertyName = "TimeDifference")]
        public  string TimeDifference {get;set;}

    }
}