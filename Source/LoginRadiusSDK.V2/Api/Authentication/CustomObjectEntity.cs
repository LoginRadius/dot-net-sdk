using System.Collections.Generic;
using LoginRadiusSDK.V2.Entity;
using LoginRadiusSDK.V2.Models;
using LoginRadiusSDK.V2.Models.Object;
using LoginRadiusSDK.V2.Util;
using static LoginRadiusSDK.V2.Util.LoginRadiusArgumentValidator;

namespace LoginRadiusSDK.V2.Api
{
    public class CustomObjectEntity : LoginRadiusResource
    {
        private readonly LoginRadiusResoucePath _resoucePath = new LoginRadiusResoucePath("CustomObject");
       
        public ApiResponse<CustomObjectprop> CreateCustomObjectbyToken(string accessToken, string objectName, string customObject)
        {
            Validate(new [] { objectName, accessToken });
            var additionalQueryParams =
                new QueryParameters { ["objectName"] = objectName };
            var additionalHeaders = new Dictionary<string, string>() { [BaseConstants.AccessTokenAuthorizationHeader] = BaseConstants.AccessTokenBearerHeader + accessToken };
            return ConfigureAndExecute<CustomObjectprop>(RequestType.Authentication, HttpMethod.POST,
                _resoucePath.ToString(),additionalQueryParams, customObject, additionalHeaders);
        }

        public ApiResponse<CustomObjectprop> UpdateCustomObjectbyAccessToken(string accessToken, string objectRecordId, string objectName,
            string customObject, bool? fullReplace = false)
        {
            Validate(new [] { objectName, accessToken });
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
            var resourcePath = SDKUtil.FormatURIPath(_resoucePath.ChildObject("{0}").ToString(),
                new object[] { objectRecordId });
            return ConfigureAndExecute<CustomObjectprop>(RequestType.Authentication, HttpMethod.PUT, resourcePath,
                additionalQueryParams, customObject, additionalHeaders);
        }

        public ApiResponse<LoginRadiusCountResponse<List<CustomObjectprop>>> GetByAccessToken(string accessToken,
            string objectName)
        {
            Validate(new [] { objectName, accessToken });
            var additionalQueryParams =
                new QueryParameters { ["objectName"] = objectName };
            var additionalHeaders = new Dictionary<string, string>() { [BaseConstants.AccessTokenAuthorizationHeader] = BaseConstants.AccessTokenBearerHeader + accessToken };
            return ConfigureAndExecute<LoginRadiusCountResponse<List<CustomObjectprop>>>(RequestType.Authentication,
                HttpMethod.GET, _resoucePath.ToString(),
                additionalQueryParams,null, additionalHeaders);
        }

        public ApiResponse<CustomObjectprop> GetByRecordId(string accessToken, string objectRecordId,
            string objectName)
        {
            Validate(new [] { objectName, accessToken });
            var additionalQueryParams =
                new QueryParameters {  ["objectName"] = objectName };
            var additionalHeaders = new Dictionary<string, string>() { [BaseConstants.AccessTokenAuthorizationHeader] = BaseConstants.AccessTokenBearerHeader + accessToken };
            var resourcePath = SDKUtil.FormatURIPath(_resoucePath.ChildObject("{0}").ToString(),
                new object[] { objectRecordId });
            return ConfigureAndExecute<CustomObjectprop>(RequestType.Authentication, HttpMethod.GET, resourcePath,
                additionalQueryParams,null,additionalHeaders);
        }

        public ApiResponse<LoginRadiusDeleteResponse> CustomObjectDeletebyRecordIdAndToken(string accessToken, string objectRecordId,
            string objectName)
        {
            Validate(new [] { objectName, accessToken });
            var additionalQueryParams =
                new QueryParameters { ["objectName"] = objectName };
            var additionalHeaders = new Dictionary<string, string>() { [BaseConstants.AccessTokenAuthorizationHeader] = BaseConstants.AccessTokenBearerHeader + accessToken };
            var resourcePath = SDKUtil.FormatURIPath(_resoucePath.ChildObject("{0}").ToString(),
                new object[] { objectRecordId });
            return ConfigureAndExecute<LoginRadiusDeleteResponse>(RequestType.Authentication, HttpMethod.DELETE,
                resourcePath,
                additionalQueryParams,null,additionalHeaders);
        }

        public ApiResponse<CustomObjectprop> CustomObjectbyObjectRecordIdandUID(string uid, string objectrecordid, string objectname)
        {
            Validate(new [] { uid, objectrecordid, objectname });
            var additionalQueryParams = new QueryParameters
            {
                ["objectname"] = objectname
            };
            //{uid}/customobject/{objectrecordid}
            var resourcePath = SDKUtil.FormatURIPath(("{0}/customobject/{1}"),
               new object[] { uid, objectrecordid });
            return ConfigureAndExecute<CustomObjectprop>(RequestType.Identity, HttpMethod.GET,
                resourcePath, additionalQueryParams);

        }
    }
}