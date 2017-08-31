using System.Collections;
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
            Validate(new ArrayList { objectName, accessToken });
            var additionalQueryParams =
                new QueryParameters { ["access_token"] = accessToken, ["objectName"] = objectName };
            return ConfigureAndExecute<CustomObjectprop>(RequestType.Authentication, HttpMethod.Post,
                _resoucePath.ToString(),
                additionalQueryParams, customObject);
        }

        public ApiResponse<CustomObjectprop> UpdateCustomObjectbyObjectRecordId(string accessToken, string objectRecordId, string objectName,
            string customObject)
        {
            Validate(new ArrayList { objectName, accessToken });
            var additionalQueryParams =
                new QueryParameters { ["access_token"] = accessToken, ["objectName"] = objectName };
            var resourcePath = SDKUtil.FormatURIPath(_resoucePath.ChildObject("{0}").ToString(),
                new object[] { objectRecordId });
            return ConfigureAndExecute<CustomObjectprop>(RequestType.Authentication, HttpMethod.Put, resourcePath,
                additionalQueryParams, customObject);
        }

        public ApiResponse<LoginRadiusCountResponse<List<CustomObjectprop>>> GetByAccessToken(string accessToken,
            string objectName)
        {
            Validate(new ArrayList { objectName, accessToken });
            var additionalQueryParams =
                new QueryParameters { ["access_token"] = accessToken, ["objectName"] = objectName };
            return ConfigureAndExecute<LoginRadiusCountResponse<List<CustomObjectprop>>>(RequestType.Authentication,
                HttpMethod.Get, _resoucePath.ToString(),
                additionalQueryParams);
        }

        public ApiResponse<CustomObjectprop> GetByRecordId(string accessToken, string objectRecordId,
            string objectName)
        {
            Validate(new ArrayList { objectName, accessToken });
            var additionalQueryParams =
                new QueryParameters { ["access_token"] = accessToken, ["objectName"] = objectName };
            var resourcePath = SDKUtil.FormatURIPath(_resoucePath.ChildObject("{0}").ToString(),
                new object[] { objectRecordId });
            return ConfigureAndExecute<CustomObjectprop>(RequestType.Authentication, HttpMethod.Get, resourcePath,
                additionalQueryParams);
        }

        public ApiResponse<LoginRadiusDeleteResponse> CustomObjectDeletebyRecordIdAndToken(string accessToken, string objectRecordId,
            string objectName)
        {
            Validate(new ArrayList { objectName, accessToken });
            var additionalQueryParams =
                new QueryParameters { ["access_token"] = accessToken, ["objectName"] = objectName };
            var resourcePath = SDKUtil.FormatURIPath(_resoucePath.ChildObject("{0}").ToString(),
                new object[] { objectRecordId });
            return ConfigureAndExecute<LoginRadiusDeleteResponse>(RequestType.Authentication, HttpMethod.Delete,
                resourcePath,
                additionalQueryParams);
        }

        public ApiResponse<CustomObjectprop> CustomObjectbyObjectRecordIdandUID(string uid, string objectrecordid, string objectname)
        {
            Validate(new ArrayList { uid, objectrecordid, objectname });
            var additionalQueryParams = new QueryParameters
            {
                ["objectname"] = objectname
            };
            //{uid}/customobject/{objectrecordid}
            var resourcePath = SDKUtil.FormatURIPath(("{0}/customobject/{1}"),
               new object[] { uid, objectrecordid });
            return ConfigureAndExecute<CustomObjectprop>(RequestType.Identity, HttpMethod.Get,
                resourcePath, additionalQueryParams);

        }
    }
}