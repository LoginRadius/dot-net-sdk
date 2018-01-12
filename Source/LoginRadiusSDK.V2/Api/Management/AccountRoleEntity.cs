using System.Collections.Generic;
using LoginRadiusSDK.V2.Entity;
using LoginRadiusSDK.V2.Models;
using LoginRadiusSDK.V2.Util;
using static LoginRadiusSDK.V2.Util.LoginRadiusArgumentValidator;

namespace LoginRadiusSDK.V2.Api
{
    public class AccountRoleEntity : LoginRadiusResource
    {
        private readonly LoginRadiusResoucePath _resoucePath = new LoginRadiusResoucePath("{0}/role");

        public ApiResponse<LoginRadiusUserRoles> GetAccountRole(string uId)
        {
            Validate(new [] {uId});
            var resourcePath = SDKUtil.FormatURIPath(_resoucePath, new object[] {uId});
            return ConfigureAndExecute<LoginRadiusUserRoles>(RequestType.Identity, HttpMethod.Get, resourcePath);
        }

        public ApiResponse<LoginRadiusAccountRolesUpsert> RolesAssignToUser(string uId,
            LoginRadiusAccountRolesUpsert accountRoles)
        {
            Validate(new List<object> { uId, accountRoles});
            var resourcePath = SDKUtil.FormatURIPath(_resoucePath, new object[] {uId});
            return ConfigureAndExecute<LoginRadiusAccountRolesUpsert>(RequestType.Identity, HttpMethod.Put,
                resourcePath, accountRoles.ConvertToJson());
        }

        public ApiResponse<LoginRadiusDeleteResponse> UnAssignRolesToUser(string uId,
            LoginRadiusAccountRolesUpsert accountRoles)
        {
            Validate(new List<object> { uId, accountRoles});
            var resourcePath = SDKUtil.FormatURIPath(_resoucePath, new object[] {uId});
            return ConfigureAndExecute<LoginRadiusDeleteResponse>(RequestType.Identity, HttpMethod.Delete, resourcePath,
                accountRoles.ConvertToJson());
        }

        public ApiResponse<RoleContextData> UpsertContext(string uid, AccountRoleContextModel roleContext)
        {
            Validate(new [] {uid});
            var resourcePath = SDKUtil.FormatURIPath(new LoginRadiusResoucePath("{0}/rolecontext"), new object[] {uid});
            return ConfigureAndExecute<RoleContextData>(RequestType.Identity, HttpMethod.Put, resourcePath,
                roleContext.ConvertToJson());
        }


        public ApiResponse<RoleContextData> GetContextwithRolesAndPermissions(string uid)
        {
            Validate(new [] {uid});
            var resourcePath = SDKUtil.FormatURIPath(new LoginRadiusResoucePath("{0}/rolecontext"), new object[] {uid});
            return ConfigureAndExecute<RoleContextData>(RequestType.Identity, HttpMethod.Get, resourcePath);
        }


        public ApiResponse<LoginRadiusDeleteResponse> DeleteRolefromContext(string uid, string rolecontextname,
            LoginRadiusAccountRolesUpsert roles)
        {
            Validate(new [] {uid, rolecontextname});
            var resourcePath = SDKUtil.FormatURIPath(new LoginRadiusResoucePath("{0}/rolecontext/{1}/role"),
                new object[] {uid, rolecontextname});
            return ConfigureAndExecute<LoginRadiusDeleteResponse>(RequestType.Identity, HttpMethod.Delete, resourcePath,
                roles.ConvertToJson());
        }


        public ApiResponse<LoginRadiusDeleteResponse> DeleteAdditionalPermissionfromContext(string uid,
            string rolecontextname, AdditionalRolePermissions additionalRolePermissions)
        {
            Validate(new [] {uid, rolecontextname});
            var resourcePath =
                SDKUtil.FormatURIPath(new LoginRadiusResoucePath("{0}/rolecontext/{1}/additionalpermission"),
                    new object[] {uid, rolecontextname});
            return ConfigureAndExecute<LoginRadiusDeleteResponse>(RequestType.Identity, HttpMethod.Delete, resourcePath,
                additionalRolePermissions.ConvertToJson());
        }

        public ApiResponse<LoginRadiusDeleteResponse> DeleteContex( string uid,  string rolecontextname)
        {
            Validate(new [] { uid, rolecontextname });
            var resourcePath =
               SDKUtil.FormatURIPath(new LoginRadiusResoucePath("{0}/rolecontext/{1}"),
                   new object[] { uid, rolecontextname });
            return ConfigureAndExecute<LoginRadiusDeleteResponse>(RequestType.Identity, HttpMethod.Delete, resourcePath );
        }
    }
}