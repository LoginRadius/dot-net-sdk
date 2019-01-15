using LoginRadiusSDK.V2.Models;
using LoginRadiusSDK.V2.Models.RegistrationData;
using System.Collections.Generic;
using LoginRadiusSDK.V2.Util;
using static LoginRadiusSDK.V2.Util.LoginRadiusArgumentValidator;
using Newtonsoft.Json.Linq;

namespace LoginRadiusSDK.V2.Api
{
    public class CustomRegistrationApi : LoginRadiusResource
    {
        /// <summary>
        /// This API allows you to fill data into a dropdown list which you have created for user Registeration.
        /// </summary>
        /// <param name="payload">Contains fields that are used in generating custom registration data.</param>
        /// <returns>LoginRadiusPostResponse: Boolean that shows if custom registration data was added.</returns>
        public ApiResponse<LoginRadiusPostResponse> AddRegistrationData(AddRegistrationDataModel payload)
        {
            Validate(new[] { payload });
            return ConfigureAndExecute<LoginRadiusPostResponse>(RequestType.RegistrationData, HttpMethod.POST, null,
                payload.ConvertToJson());
        }

        /// <summary>
        /// This API allows you to validate code for a particular dropdown member.
        /// </summary>
        /// <param name="recordId">The dropdown's record id.</param>
        /// <param name="code">A secret code.</param>
        /// <returns>ValidateSecretCodeResponse: Boolean that shows if the secret code is valid.</returns>
        public ApiResponse<ValidateSecretCodeResponse> ValidateSecretCode(string recordId, string code)
        {
            var payload = new JObject();
            payload.Add("recordid", recordId);
            payload.Add("code", code);

            Validate(new[] { payload.ToString() });
            return ConfigureAndExecute<ValidateSecretCodeResponse>(RequestType.RegistrationDataAuth, HttpMethod.POST, "validatecode", null,
                payload.ToString());
        }

        /// <summary>
        /// This API is used to retrieve dropdown data. Uses apikey and apisecret.
        /// </summary>
        /// <param name="type">Type of the data source.</param>
        /// <param name="parentid">The id of the parent dropdown member if it exists.</param>
        /// <param name="skip">Skips a number of records from the start.</param>
        /// <param name="limit">Retrieves at most this number of records at a time (max is 50).</param>
        /// <returns>List of GetRegistrationDataResponse: Registration data object.</returns>
        public ApiResponse<List<GetRegistrationDataResponse>> GetRegistrationData(string type, string parentid, string skip, string limit)
        {

            var additionalQueryParams = new QueryParameters
            {
                {"parentid", parentid},
                {"skip", skip},
                {"limit", limit}
            };

            Validate(new[] { type });
            var resourcePath = SDKUtil.FormatURIPath("{0}", new object[] { type });
            return ConfigureAndExecute<List<GetRegistrationDataResponse>>(RequestType.RegistrationData, HttpMethod.GET, resourcePath, additionalQueryParams);
        }

        /// <summary>
        /// This API is used to retrieve dropdown data. Uses just an apikey.
        /// </summary>
        /// <param name="type">Type of the data source.</param>
        /// <param name="parentid">The id of the parent dropdown member if it exists.</param>
        /// <param name="skip">Skips a number of records from the start.</param>
        /// <param name="limit">Retrieves at most this number of records at a time (max is 50).</param>
        /// <returns>List of GetRegistrationDataResponse: Registration data object.</returns>
        public ApiResponse<List<GetRegistrationDataResponse>> GetRegistrationDataAuth(string type, string parentid, string skip, string limit)
        {

            var additionalQueryParams = new QueryParameters
            {
                {"parentid", parentid},
                {"skip", skip},
                {"limit", limit}
            };

            Validate(new[] { type });
            var resourcePath = SDKUtil.FormatURIPath("{0}", new object[] { type });
            return ConfigureAndExecute<List<GetRegistrationDataResponse>>(RequestType.RegistrationDataAuth, HttpMethod.GET, resourcePath, additionalQueryParams);
        }

        /// <summary>
        /// This API is used to retrieve dropdown data. Uses just an apikey.
        /// </summary>
        /// <param name="recordId">Dropdown item's record id.</param>
        /// <param name="updateRegistrationData">Object that contains identifiers for the object being updated.</param>
        /// <returns>List of GetRegistrationDataResponse: Boolean that shows if registration data was updated and updated data.</returns>
        public ApiResponse<UpdateRegistrationDataResponse> UpdateRegistrationData(string recordId, UpdateRegistrationDataModel updateRegistrationData)
        {
            Validate(new[] { recordId });
            var resourcePath = SDKUtil.FormatURIPath("{0}", new object[] { recordId });
            return ConfigureAndExecute<UpdateRegistrationDataResponse>(RequestType.RegistrationData, HttpMethod.PUT, resourcePath, null,
                updateRegistrationData.ConvertToJson());
        }

        /// <summary>
        /// This API allows you to delete an item from a dropdown list.
        /// </summary>
        /// <param name="recordId">Record id of the data being deleted.</param>
        /// <returns>LoginRadiusDeleteResponse: Boolean that shows if registration data was deleted.</returns>
        public ApiResponse<LoginRadiusDeleteResponse> DeleteRegistrationData(string recordId)
        {
            Validate(new[] { recordId });
            var resourcePath = SDKUtil.FormatURIPath("{0}", new object[] { recordId });
            return ConfigureAndExecute<LoginRadiusDeleteResponse>(RequestType.RegistrationData, HttpMethod.DELETE, resourcePath);
        }

        /// <summary>
        /// This API allows you to delete all records contained in a data source.
        /// </summary>
        /// <param name="type">The name of the data source.</param>
        /// <returns>LoginRadiusDeleteResponse: Boolean that shows if registration data was deleted.</returns>
        public ApiResponse<LoginRadiusDeleteResponse> DeleteAllRecordsByDataSource(string type)
        {
            Validate(new[] { type });
            var resourcePath = SDKUtil.FormatURIPath("type/{0}", new object[] { type });
            return ConfigureAndExecute<LoginRadiusDeleteResponse>(RequestType.RegistrationData, HttpMethod.DELETE, resourcePath);
        }
    }
}
