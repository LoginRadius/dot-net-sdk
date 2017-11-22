using System.Collections;
using LoginRadiusSDK.V2.Entity;
using LoginRadiusSDK.V2.Models;
using LoginRadiusSDK.V2.Models.Object;
using LoginRadiusSDK.V2.Util;
using static LoginRadiusSDK.V2.Util.LoginRadiusArgumentValidator;

namespace LoginRadiusSDK.V2.Api
{
    public class AccountCustomObjectEntity : LoginRadiusResource
    {
        private readonly LoginRadiusArgumentValidator _validate = new LoginRadiusArgumentValidator();
        private readonly LoginRadiusResoucePath _resoucePath = new LoginRadiusResoucePath("{0}/CustomObject");

        public ApiResponse<CustomObjectprop> CreateAccountCustomObject(string uId, string objectname,
            string customObject)
        {
            Validate(new [] { uId, customObject });
            var resourcePath = SDKUtil.FormatURIPath(_resoucePath, new object[] { uId });
            var additionalParameter = new QueryParameters { ["objectname"] = objectname };
            return ConfigureAndExecute<CustomObjectprop>(RequestType.Identity, HttpMethod.Post, resourcePath,
                additionalParameter, customObject);
        }

        public ApiResponse<CustomObjectprop> UpdateAccountCustomObjectbyUID(string uId, string objectRecordId,
           string objectname, string customObject)
        {
            Validate(new [] { uId, objectRecordId, customObject });
            var pattern = _resoucePath.ChildObject("{1}").ObjectName;
            var additionalparams = new QueryParameters { ["objectname"] = objectname };
            var resourcePath = SDKUtil.FormatURIPath(pattern, new object[] { uId, objectRecordId });
            return ConfigureAndExecute<CustomObjectprop>(RequestType.Identity, HttpMethod.Put, resourcePath, additionalparams,
                customObject);
        }



        public ApiResponse<CustomObjectprop> UpdateAccountCustomObjectbytoken(string access_token, string objectRecordId, string objectname, string customObject)
        {
            Validate(new [] { objectRecordId, objectname, access_token });
            var additionalparams = new QueryParameters { ["objectname"] = objectname, ["access_token"] = access_token };
            var resourcePath = SDKUtil.FormatURIPath(("customobject/{0}"), new object[] { objectRecordId });
            return ConfigureAndExecute<CustomObjectprop>(RequestType.Authentication, HttpMethod.Put, resourcePath, additionalparams,
                customObject);
        }

        public ApiResponse<CustomObjectResponse> GetAccountCustomObject(string uId, string objectname)
        {
            Validate(new [] { uId });
            var resourcePath = SDKUtil.FormatURIPath(_resoucePath, new object[] { uId });
            var addtionalparameter = new QueryParameters { ["objectname"] = objectname };
            return ConfigureAndExecute<CustomObjectResponse>(RequestType.Identity, HttpMethod.Get, resourcePath,
                addtionalparameter);
        }

        //public ApiResponse<CustomObjectResponse> GetAccountCustomObjectByObjectId(string uId, string objectRecordId)
        //{
        //    Validate(new [] {uId, objectRecordId});
        //    var pattern = _resoucePath.ChildObject("{1}").ObjectName;
        //    var resourcePath = SDKUtil.FormatURIPath(pattern, new object[] {uId, objectRecordId});
        //    return ConfigureAndExecute<CustomObjectResponse>(RequestType.Identity, HttpMethod.Get, resourcePath);
        //}

        public ApiResponse<LoginRadiusDeleteResponse> DeleteAccountCustomObject(string uId, string objectRecordId, string objectname)
        {
            Validate(new [] { uId, objectRecordId });
            var pattern = _resoucePath.ChildObject("{1}").ObjectName;
            var resourcePath = SDKUtil.FormatURIPath(pattern, new object[] { uId, objectRecordId });
            var additionalparams = new QueryParameters { ["objectname"] = objectname };
            return ConfigureAndExecute<LoginRadiusDeleteResponse>(RequestType.Identity, HttpMethod.Delete,
                resourcePath, additionalparams);
        }


        public ApiResponse<CustomObjectprop> CustombyObjectRecordIdandToken(string access_token, string objectname, string objectrecordid)
        {
            Validate(new [] { access_token, objectname });
            var resourcePath = SDKUtil.FormatURIPath("customobject/{0}", new object[] { objectrecordid });
            var additionalparams = new QueryParameters
            {
                ["access_token"] = access_token,
                ["objectname"] = objectname
            };
            return ConfigureAndExecute<CustomObjectprop>(RequestType.Authentication, HttpMethod.Get,
                resourcePath, additionalparams);

        }
    }
}