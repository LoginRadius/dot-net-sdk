//-----------------------------------------------------------------------
// <copyright file="ModelClass" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2019 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Newtonsoft.Json;
namespace LoginRadiusSDK.V2.Models.ResponseModels.UserProfile.Objects

{

    /// <summary>
    ///	Response containing Definition for Complete Job Bookmark data
    /// </summary>
    public class JobBookmarks
    {
		/// <summary>
		///	Job Bookmarks Apply Timestamp
		/// </summary>
		[JsonProperty(PropertyName = "ApplyTimestamp")]
        public  string ApplyTimestamp {get;set;}

		/// <summary>
		///	Job bookmark is applied or not
		/// </summary>
		[JsonProperty(PropertyName = "IsApplied")]
        public  bool? IsApplied {get;set;}

		/// <summary>
		///	Job bookmark is saved or not
		/// </summary>
		[JsonProperty(PropertyName = "IsSaved")]
        public  bool? IsSaved {get;set;}

		/// <summary>
		///	Job
		/// </summary>
		[JsonProperty(PropertyName = "Job")]
        public  Job Job {get;set;}

		/// <summary>
		///	Saved time stamp of Job bookmarks
		/// </summary>
		[JsonProperty(PropertyName = "SavedTimestamp")]
        public  string SavedTimestamp {get;set;}

    }
}