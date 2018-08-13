using System.Collections;
using System.Collections.Generic;
using LoginRadiusSDK.V2.Models;
using LoginRadiusSDK.V2.Util;

namespace LoginRadiusSDK.V2.Api
{
    public class CloudStorageEntity : LoginRadiusResource
    {

        /// <summary>
        /// This API allows you to query your LoginRadius Cloud Storage and retrieve up to 20 user records.
        /// </summary>
        /// <param name="select"> Fields included in the Query, default all fields, Optional: can be null or empty string</param>
        /// <param name="from">LoginRadius Table that details are being retrieved from, for now users only supported </param>
        /// <param name="where">Filter for data based on condition,Optional: can be null or empty string </param>
        /// <param name="orderBy">Determines ascending order of returned data,Optional: can be null or empty string</param>
        /// <param name="skip">Ignores the specified amount of values used to page through responses, value must be positive and default value is 0, Optional: can be null or empty string</param>
        /// <param name="limit">Determines size of dataset returned. default value is 20 and max value is 20, Optional: can be null or empty string</param>
        /// <returns></returns>
        public ApiResponse<LoginRadiusIdentityUserList> GetUserList(string select = "", string from = "", string where = "",
            string orderBy = "", string skip = "",
            string limit = "")
        {
            var postRequest = new BodyParameters
            {
                {"From", string.IsNullOrWhiteSpace(from) ? "users" : from}
            };
            if (!string.IsNullOrWhiteSpace(select))
            {
                postRequest.Add("Select", select);
            }
            if (!string.IsNullOrWhiteSpace(where))
            {
                postRequest.Add("Where", where);
            }
            if (!string.IsNullOrWhiteSpace(orderBy))
            {
                postRequest.Add("OrderBy", orderBy);
            }
            if (!string.IsNullOrWhiteSpace(skip))
            {
                postRequest.Add("Skip", skip);
            }
            if (!string.IsNullOrWhiteSpace(limit))
            {
                postRequest.Add("Limit", limit);
            }
            return ConfigureAndExecute<LoginRadiusIdentityUserList>(RequestType.Cloud, HttpMethod.POST,
                "identity",
                postRequest.ConvertToJson());
        }

        /// <summary>
        /// This API is used to query the aggregation data from your LoginRadius cloud storage.
        /// </summary>
        /// <param name="from">From Date in format of (mm/dd/yyyy).</param>
        /// <param name="to">To Date in format of (mm/dd/yyyy).</param>
        /// <param name="firstDatapoint">Aggregation Field, supported are: os, browser, device, country, city, provider, emailType, friendsCount </param>
        /// <param name="statsType">Type of users should apply to i.e. NewUser, ActiveUser, Login</param>
        /// <returns></returns>
        public ApiResponse<LoginRadiusQueryDataModel> GetQueryAggregationData(string from, string to, string firstDatapoint,
            string statsType)
        {
            LoginRadiusArgumentValidator.Validate(new [] {from, to, firstDatapoint, statsType});
            var additionalQueryParams = new QueryParameters
            {
                {"from", from},
                {"to", to}
            };
            var postRequest = new BodyParameters
            {
                {"firstDatapoint", firstDatapoint},
                {"statsType", statsType}
            };
            return ConfigureAndExecute<LoginRadiusQueryDataModel>(RequestType.Cloud, HttpMethod.POST,
                "insights", additionalQueryParams,
                postRequest.ConvertToJson());
        }
    }
}
