using System.Collections;
using LoginRadiusSDK.V2.Entity;
using LoginRadiusSDK.V2.Models;
using LoginRadiusSDK.V2.Util;
using static LoginRadiusSDK.V2.Util.LoginRadiusArgumentValidator;
using System.Collections.Generic;

namespace LoginRadiusSDK.V2.Api
{
    public class AccountRoleEntity : LoginRadiusResource
    {
        private readonly LoginRadiusResoucePath _resoucePath = new LoginRadiusResoucePath("{0}/role");

        public ApiResponse<LoginRadiusUserRoles> GetAccountRole(string uId)
        {
            Validate(new ArrayList {uId});
            var resourcePath = SDKUtil.FormatURIPath(_resoucePath, new object[] {uId});
            return ConfigureAndExecute<LoginRadiusUserRoles>(RequestType.Identity, HttpMethod.Get, resourcePath);
        }

        public ApiResponse<LoginRadiusAccountRolesUpsert> RolesAssignToUser(string uId,
            LoginRadiusAccountRolesUpsert accountRoles)
        {
            Validate(new ArrayList {uId, accountRoles});
            var resourcePath = SDKUtil.FormatURIPath(_resoucePath, new object[] {uId});
            return ConfigureAndExecute<LoginRadiusAccountRolesUpsert>(RequestType.Identity, HttpMethod.Put,
                resourcePath, accountRoles.ConvertToJson());
        }

        public ApiResponse<LoginRadiusDeleteResponse> UnAssignRolesToUser(string uId,
            LoginRadiusAccountRolesUpsert accountRoles)
        {
            Validate(new ArrayList {uId, accountRoles});
            var resourcePath = SDKUtil.FormatURIPath(_resoucePath, new object[] {uId});
            return ConfigureAndExecute<LoginRadiusDeleteResponse>(RequestType.Identity, HttpMethod.Delete, resourcePath,
                accountRoles.ConvertToJson());
        }

        public ApiResponse<RoleContextData> UpsertContext(string uid, AccountRoleContextModel _ListRoleContext)
        {
            Validate(new ArrayList {uid});
            var resourcePath = SDKUtil.FormatURIPath(new LoginRadiusResoucePath("{0}/rolecontext"), new object[] {uid});
            return ConfigureAndExecute<RoleContextData>(RequestType.Identity, HttpMethod.Put, resourcePath,
                _ListRoleContext.ConvertToJson());
        }


        public ApiResponse<RoleContextData> GetContextwithRolesAndPermissions(string uid)
        {
            Validate(new ArrayList {uid});
            var resourcePath = SDKUtil.FormatURIPath(new LoginRadiusResoucePath("{0}/rolecontext"), new object[] {uid});
            return ConfigureAndExecute<RoleContextData>(RequestType.Identity, HttpMethod.Get, resourcePath);
        }


        public ApiResponse<LoginRadiusDeleteResponse> DeleteRolefromContext(string uid, string rolecontextname,
            LoginRadiusAccountRolesUpsert _LoginRadiusUserRoles)
        {
            Validate(new ArrayList {uid, rolecontextname});
            var resourcePath = SDKUtil.FormatURIPath(new LoginRadiusResoucePath("{0}/rolecontext/{1}/role"),
                new object[] {uid, rolecontextname});
            return ConfigureAndExecute<LoginRadiusDeleteResponse>(RequestType.Identity, HttpMethod.Delete, resourcePath,
                _LoginRadiusUserRoles.ConvertToJson());
        }


        public ApiResponse<LoginRadiusDeleteResponse> DeleteAdditionalPermissionfromContext(string uid,
            string rolecontextname, AdditionalRolePermissions _AdditionalRolePermissions)
        {
            Validate(new ArrayList {uid, rolecontextname});
            var resourcePath =
                SDKUtil.FormatURIPath(new LoginRadiusResoucePath("{0}/rolecontext/{1}/additionalpermission"),
                    new object[] {uid, rolecontextname});
            return ConfigureAndExecute<LoginRadiusDeleteResponse>(RequestType.Identity, HttpMethod.Delete, resourcePath,
                _AdditionalRolePermissions.ConvertToJson());
        }

        public ApiResponse<LoginRadiusDeleteResponse> DeleteContex( string uid,  string rolecontextname)
        {
            Validate(new ArrayList { uid, rolecontextname });
            var resourcePath =
               SDKUtil.FormatURIPath(new LoginRadiusResoucePath("{0}/rolecontext/{1}"),
                   new object[] { uid, rolecontextname });
            return ConfigureAndExecute<LoginRadiusDeleteResponse>(RequestType.Identity, HttpMethod.Delete, resourcePath );
        }
    }
}