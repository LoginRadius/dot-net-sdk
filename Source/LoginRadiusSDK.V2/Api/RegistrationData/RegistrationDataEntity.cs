using LoginRadiusSDK.V2.Models;
using LoginRadiusSDK.V2.Models.RegistrationData;
using System.Collections.Generic;
using LoginRadiusSDK.V2.Entity;
using LoginRadiusSDK.V2.Util;
using static LoginRadiusSDK.V2.Util.LoginRadiusArgumentValidator;
using Newtonsoft.Json.Linq;

namespace LoginRadiusSDK.V2.Api.RegistrationData
{
    public class RegistrationDataEntity : LoginRadiusResource
    {

        private readonly LoginRadiusResoucePath _resoucePath_validatecode = new LoginRadiusResoucePath("/validatecode");
        private readonly LoginRadiusResoucePath _resoucePath_getData = new LoginRadiusResoucePath("/{0}");
        /// <summary>
        /// 
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        public ApiResponse<LoginRadiusPostResponse> AddRegistrationData(AddRegistrationDataModel payload)
        {
            Validate(new[] { payload });
            return ConfigureAndExecute<LoginRadiusPostResponse>(RequestType.RegistrationData, HttpMethod.POST, null,
                payload.ConvertToJson());
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="recordid"></param>
        /// <param name="code"></param>
        /// <returns></returns>

        public ApiResponse<ValidateSecretCodeResponse> ValidateSecretCode(string recordid ,string code)
        {
            var payload = new JObject();
            payload.Add("recordid", recordid);
            payload.Add("code", code);
           
            Validate(new[] { payload.ToString() });
            return ConfigureAndExecute<ValidateSecretCodeResponse>(RequestType.RegistrationDataAuth, HttpMethod.POST, _resoucePath_validatecode.ToString(), null,
                payload.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="parentid"></param>
        /// <param name="skip"></param>
        /// <param name="limit"></param>
        /// <returns></returns>

        public ApiResponse<List<GetRegistrationDataResponse>> GetRegistrationData(string type, string parentid, string skip, string limit)
        {
           
            var additionalQueryParams = new QueryParameters
            {
                {"parentid", parentid},
                {"skip", skip},
                {"limit", limit}
            };

            Validate(new[] {type});
            var resourcePath = SDKUtil.FormatURIPath(_resoucePath_getData, new object[] { type });
            return ConfigureAndExecute<List<GetRegistrationDataResponse>>(RequestType.RegistrationData, HttpMethod.GET, resourcePath, additionalQueryParams);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="recordid"></param>
        /// <param name="payload"></param>
        /// <returns></returns>

        public ApiResponse<UpdateRegistrationDataResponse> UpdateRegistrationData(string recordid, UpdateRegistrationDataModel updateRegistrationData)
        {
            Validate(new[] { recordid });
            var resourcePath = SDKUtil.FormatURIPath(_resoucePath_getData, new object[] { recordid });
            return ConfigureAndExecute<UpdateRegistrationDataResponse>(RequestType.RegistrationData, HttpMethod.PUT, resourcePath, null,
                updateRegistrationData.ConvertToJson());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="recordid"></param>
        /// <param name="payload"></param>
        /// <returns></returns>

        public ApiResponse<LoginRadiusDeleteResponse> DeleteRegistrationData(string recordid)
        {
            Validate(new[] { recordid });
            var resourcePath = SDKUtil.FormatURIPath(_resoucePath_getData, new object[] { recordid });
            return ConfigureAndExecute<LoginRadiusDeleteResponse>(RequestType.RegistrationData, HttpMethod.DELETE, resourcePath);
        }
    }
}
