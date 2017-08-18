using System.Collections;
using System.Collections.Generic;
using LoginRadiusSDK.Models.CloudStorageModel;
using LoginRadiusSDK.Utility;
using LoginRadiusSDK.Utility.Http;
using LoginRadiusSDK.Utility.Serialization;

namespace LoginRadiusSDK.Entity
{
    public class LoginRadiusCloudStorageEntity : LoginRadiusV2EntityBase
    {
        readonly LoginRadiusArgumentValidator _validate = new LoginRadiusArgumentValidator();
        private readonly LoginRadiusObject _object = new LoginRadiusObject("identity");
        private ArrayList _valuesToCheck;

        public LoginRadiusCloudStorageEntity()
        {
        }
        public LoginRadiusCloudStorageEntity(string apikey, string apisecret)
            : base(apikey,apisecret)
        {
        }

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
        public List<LoginRadiusIdentityModel> GetUserList(string select, string from, string where, string orderBy, string skip,
            string limit)
        {
            var postRequest = new HttpRequestParameter
            {
                {"From", string.IsNullOrWhiteSpace(from)?"users":from}
            };
            if (!string.IsNullOrWhiteSpace(select)) { postRequest.Add("Select", select); }
            if (!string.IsNullOrWhiteSpace(where)) { postRequest.Add("Where", where); }
            if (!string.IsNullOrWhiteSpace(orderBy)) { postRequest.Add("OrderBy", orderBy); }
            if (!string.IsNullOrWhiteSpace(skip)) { postRequest.Add("Skip", skip); }
            if (!string.IsNullOrWhiteSpace(limit)) { postRequest.Add("Limit", limit); }
            var response = Post(_object, postRequest);
            return response.Deserialize<List<LoginRadiusIdentityModel>>();
        }


        /// <summary>
        /// This API is used to query the aggregation data from your LoginRadius cloud storage.
        /// </summary>
        /// <param name="from">From Date in format of (mm/dd/yyyy).</param>
        /// <param name="to">To Date in format of (mm/dd/yyyy).</param>
        /// <param name="firstDatapoint">Aggregation Field, supported are: os, browser, device, country, city, provider, emailType, friendsCount </param>
        /// <param name="statsType">Type of users should apply to i.e. NewUser, ActiveUser, Login</param>
        /// <returns></returns>
        public LoginRadiusQueryDataModel GetQueryAggregationData(string from, string to, string firstDatapoint, string statsType)
        {
            _validate.Validate(_valuesToCheck = new ArrayList() { from, to, firstDatapoint, statsType }, "Get Hash Password");
            var getRequest = new HttpRequestParameter
            {
                {"from",from},{"to",to}
            };
            var postRequest = new HttpRequestParameter
            {
                {"firstDatapoint", firstDatapoint},
                {"statsType", statsType}
            };
            var response = Post(new LoginRadiusObject("insights"), getRequest, postRequest);
            return response.Deserialize<LoginRadiusQueryDataModel>();
        }
    }
}
