using System.Collections.Generic;
using LoginRadiusSDK.V2.Entity;
using LoginRadiusSDK.V2.Models;
using LoginRadiusSDK.V2.Models.Object;
using LoginRadiusSDK.V2.Util;
using static LoginRadiusSDK.V2.Util.LoginRadiusArgumentValidator;
namespace LoginRadiusSDK.V2.Api
{
    public class CustomObjectApi : LoginRadiusResource
    {
        private readonly LoginRadiusResourcePath _uidResourcePath = new LoginRadiusResourcePath("{0}/CustomObject");
        private readonly LoginRadiusResourcePath _tokenResourcePath = new LoginRadiusResourcePath("CustomObject");

        /// <summary>
        /// This API is used to write information in JSON format to the custom object for the specified account.
        /// </summary>
        /// <param name="uid">The uid for the user getting the custom object.</param>
        /// <param name="objectName">The custom object name that is created by LoginRadius.</param>
        /// <param name="customObject">The data for the created custom object.</param>
        /// <returns>CustomObjectprop: Information on the created custom object.</returns>
        public ApiResponse<CustomObjectprop> CreateCustomObjectByUid(string uid, string objectName,
            string customObject)
        {
            Validate(new[] { uid, customObject });
            var resourcePath = SDKUtil.FormatURIPath(_uidResourcePath, new object[] { uid });
            var additionalParameter = new QueryParameters { ["objectname"] = objectName };
            return ConfigureAndExecute<CustomObjectprop>(RequestType.Identity, HttpMethod.POST, resourcePath,
                additionalParameter, customObject);
        }

        /// <summary>
        /// This API is used to write information in JSON format to the custom object for the specified account.
        /// </summary>
        /// <param name="accessToken">The access token for the user getting the custom object.</param>
        /// <param name="objectName">The custom object name that is created by LoginRadius.</param>
        /// <param name="customObject">The data for the created custom object.</param>
        /// <returns>CustomObjectprop: Information on the created custom object.</returns>
        public ApiResponse<CustomObjectprop> CreateCustomObjectByToken(string accessToken, string objectName, string customObject)
        {
            Validate(new[] { objectName, accessToken });
            var additionalQueryParams =
                new QueryParameters { ["objectName"] = objectName };
            var additionalHeaders = new Dictionary<string, string>() { [BaseConstants.AccessTokenAuthorizationHeader] = 
                BaseConstants.AccessTokenBearerHeader + accessToken };
            return ConfigureAndExecute<CustomObjectprop>(RequestType.Authentication, HttpMethod.POST,
                _tokenResourcePath.ToString(), additionalQueryParams, customObject, additionalHeaders);
        }

        /// <summary>
        /// This API is used to retrieve the Custom Object data for the specified account.
        /// </summary>
        /// <param name="uid">The uid for the user associated with the custom object.</param>
        /// <param name="objectRecordId">The custom object id being looked up</param>
        /// <param name="objectName">The custom object name that is created by LoginRadius.</param>
        /// <returns>CustomObjectprop: Information on the custom object.</returns>
        public ApiResponse<CustomObjectprop> GetByObjectRecordIdAndUid(string uid, string objectRecordId, string objectName)
        {
            Validate(new[] { uid, objectRecordId, objectName });
            var additionalQueryParams = new QueryParameters
            {
                ["objectname"] = objectName
            };
            //{uid}/customobject/{objectrecordid}
            var resourcePath = SDKUtil.FormatURIPath(("{0}/customobject/{1}"),
                new object[] { uid, objectRecordId });
            return ConfigureAndExecute<CustomObjectprop>(RequestType.Identity, HttpMethod.GET,
                resourcePath, additionalQueryParams);
        }

        /// <summary>
        /// This API is used to retrieve the Custom Object data for the specified account.
        /// </summary>
        /// <param name="accessToken">The access token for the user associated with the custom object.</param>
        /// <param name="objectRecordId">The custom object id being looked up</param>
        /// <param name="objectName">The custom object name that is created by LoginRadius.</param>
        /// <returns>CustomObjectprop: Information on the custom object.</returns>
        public ApiResponse<CustomObjectprop> GetByObjectRecordIdAndToken(string accessToken, string objectRecordId,
            string objectName)
        {
            Validate(new[] { objectName, objectRecordId, accessToken });
            var additionalQueryParams = new QueryParameters { ["objectName"] = objectName };
            var additionalHeaders = new Dictionary<string, string>()
            {
                [BaseConstants.AccessTokenAuthorizationHeader] =
                    BaseConstants.AccessTokenBearerHeader + accessToken
            };
            var resourcePath = SDKUtil.FormatURIPath(_tokenResourcePath.ChildObject("{0}").ToString(),
                new object[] { objectRecordId });
            return ConfigureAndExecute<CustomObjectprop>(RequestType.Authentication, HttpMethod.GET, resourcePath,
                additionalQueryParams, null, additionalHeaders);
        }

        /// <summary>
        /// his API is used to all Custom Object data for the specified account.
        /// </summary>
        /// <param name="accessToken">The access token for the user getting the custom object.</param>
        /// <param name="objectName">The custom object name that is created by LoginRadius.</param>
        /// <returns>List of CustomObjectprop: Information on the created custom object.</returns>
        public ApiResponse<LoginRadiusCountResponse<List<CustomObjectprop>>> GetByAccessToken(string accessToken,
            string objectName)
        {
            Validate(new[] { objectName, accessToken });
            var additionalQueryParams = new QueryParameters { ["objectName"] = objectName };
            var additionalHeaders = new Dictionary<string, string>() { [BaseConstants.AccessTokenAuthorizationHeader] = BaseConstants.AccessTokenBearerHeader + accessToken };
            return ConfigureAndExecute<LoginRadiusCountResponse<List<CustomObjectprop>>>(RequestType.Authentication,
                HttpMethod.GET, _tokenResourcePath.ToString(), additionalQueryParams, null, additionalHeaders);
        }

        /// <summary>
        /// his API is used to all Custom Object data for the specified account.
        /// </summary>
        /// <param name="uid">The uid for the user getting the custom object.</param>
        /// <param name="objectName">The custom object name that is created by LoginRadius.</param>
        /// <returns>List of CustomObjectprop: Information on the created custom object.</returns>
        public ApiResponse<CustomObjectResponse> GetByUid(string uid, string objectName)
        {
            Validate(new[] { uid });
            var resourcePath = SDKUtil.FormatURIPath(_uidResourcePath, new object[] { uid });
            var additionalParameter = new QueryParameters { ["objectname"] = objectName };
            return ConfigureAndExecute<CustomObjectResponse>(RequestType.Identity, HttpMethod.GET, resourcePath,
                additionalParameter);
        }

        /// <summary>
        /// This API is used to write information in JSON format to the custom object for the specified account.
        /// </summary>
        /// <param name="accessToken">The access token for the user associated with the custom object.</param>
        /// <param name="objectRecordId">The custom object id that is being updated</param>
        /// <param name="objectName">The custom object name that is created by LoginRadius.</param>
        /// <param name="customObject">The data for the updated custom object.</param>
        /// <param name="fullReplace">Determines whether to do a full replace or a partial replace for the custom object.</param>
        /// <returns>CustomObjectprop: Information on the updated custom object.</returns>
        public ApiResponse<CustomObjectprop> UpdateByObjectRecordIdAndAccessToken(string accessToken, string objectRecordId, string objectName,
            string customObject, bool? fullReplace = false)
        {
            Validate(new[] { objectName, accessToken });
            var additionalQueryParams =
                new QueryParameters { ["objectName"] = objectName };
            var additionalHeaders = new Dictionary<string, string>() { [BaseConstants.AccessTokenAuthorizationHeader] = BaseConstants.AccessTokenBearerHeader + accessToken };
            if (fullReplace.HasValue && fullReplace.Value)
            {
                additionalQueryParams.Add("updateType", "Replace");
            }
            else
            {
                additionalQueryParams.Add("updateType", "PartialReplace");
            }
            var resourcePath = SDKUtil.FormatURIPath(_tokenResourcePath.ChildObject("{0}").ToString(),
                new object[] { objectRecordId });
            return ConfigureAndExecute<CustomObjectprop>(RequestType.Authentication, HttpMethod.PUT, resourcePath,
                additionalQueryParams, customObject, additionalHeaders);
        }

        /// <summary>
        /// This API is used to write information in JSON format to the custom object for the specified account.
        /// </summary>
        /// <param name="uid">The uid for the user associated with the custom object.</param>
        /// <param name="objectRecordId">The custom object id that is being updated</param>
        /// <param name="objectName">The custom object name that is created by LoginRadius.</param>
        /// <param name="customObject">The data for the updated custom object.</param>
        /// <param name="fullReplace">Determines whether to do a full replace or a partial replace for the custom object.</param>
        /// <returns>CustomObjectprop: Information on the updated custom object.</returns>
        public ApiResponse<CustomObjectprop> UpdateByObjectRecordIdAndUid(string uid, string objectRecordId,
            string objectName, string customObject, bool? fullReplace = false)
        {
            Validate(new[] { uid, objectRecordId, customObject });
            var pattern = _uidResourcePath.ChildObject("{1}").ObjectName;
            var additionalparams = new QueryParameters { ["objectname"] = objectName };
            if (fullReplace.HasValue && fullReplace.Value)
            {
                additionalparams.Add("updateType", "Replace");
            }
            else
            {
                additionalparams.Add("updateType", "PartialReplace");
            }
            var resourcePath = SDKUtil.FormatURIPath(pattern, new object[] { uid, objectRecordId });
            return ConfigureAndExecute<CustomObjectprop>(RequestType.Identity, HttpMethod.PUT, resourcePath, additionalparams,
                customObject);
        }

        /// <summary>
        /// This API is used to write information in JSON format to the custom object for the specified account.
        /// </summary>
        /// <param name="uid">The uid for the user associated with the custom object.</param>
        /// <param name="objectRecordId">The custom object id that is being deleted.</param>
        /// <param name="objectName">The custom object name that is created by LoginRadius.</param>
        /// <returns>LoginRadiusDeleteResponse: Boolean that shows whether the custom object was deleted.</returns>
        public ApiResponse<LoginRadiusDeleteResponse> DeleteByRecordIdAndUid(string uid, string objectRecordId, string objectName)
        {
            Validate(new[] { uid, objectRecordId });
            var pattern = _uidResourcePath.ChildObject("{1}").ObjectName;
            var resourcePath = SDKUtil.FormatURIPath(pattern, new object[] { uid, objectRecordId });
            var additionalparams = new QueryParameters { ["objectname"] = objectName };
            return ConfigureAndExecute<LoginRadiusDeleteResponse>(RequestType.Identity, HttpMethod.DELETE,
                resourcePath, additionalparams);
        }

        /// <summary>
        /// This API is used to write information in JSON format to the custom object for the specified account.
        /// </summary>
        /// <param name="accessToken">The access token for the user getting the custom object.</param>
        /// <param name="objectRecordId">The custom object id that is being deleted.</param>
        /// <param name="objectName">The data for the created custom object.</param>
        /// <returns>LoginRadiusDeleteResponse: Boolean that shows whether the custom object was deleted.</returns>
        public ApiResponse<LoginRadiusDeleteResponse> DeleteByRecordIdAndToken(string accessToken, string objectRecordId,
            string objectName)
        {
            Validate(new[] { objectName, accessToken });
            var additionalQueryParams =
                new QueryParameters { ["objectName"] = objectName };
            var additionalHeaders = new Dictionary<string, string>() { [BaseConstants.AccessTokenAuthorizationHeader] = BaseConstants.AccessTokenBearerHeader + accessToken };
            var resourcePath = SDKUtil.FormatURIPath(_tokenResourcePath.ChildObject("{0}").ToString(),
                new object[] { objectRecordId });
            return ConfigureAndExecute<LoginRadiusDeleteResponse>(RequestType.Authentication, HttpMethod.DELETE,
                resourcePath, additionalQueryParams, null, additionalHeaders);
        }
    }
}
