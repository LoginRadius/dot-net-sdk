using System.Collections;
using LoginRadiusSDK.V2.Entity;
using LoginRadiusSDK.V2.Models;
using LoginRadiusSDK.V2.Util;
using static LoginRadiusSDK.V2.Util.LoginRadiusArgumentValidator;

namespace LoginRadiusSDK.V2.Api
{
    public class LoginRadiusRoleEnity : LoginRadiusResource
    {
        private readonly LoginRadiusResoucePath _resoucePath = new LoginRadiusResoucePath("role");

        public ApiResponse<LoginRadiusRolesResponse> GetRoles()
        {
            return ConfigureAndExecute<LoginRadiusRolesResponse>(RequestType.Role, HttpMethod.GET,
                _resoucePath.ToString());
        }

        public ApiResponse<LoginRadiusRolesResponse> CreateRoles(LoginRadiusRolesCreate accoutRolesCreate)
        {
            Validate(new [] {accoutRolesCreate});
            return ConfigureAndExecute<LoginRadiusRolesResponse>(RequestType.Role, HttpMethod.POST,
                _resoucePath.ToString(),
                accoutRolesCreate.ConvertToJson());
        }

        public ApiResponse<LoginRadiusDeleteResponse> DeleteRole(string roleName)
        {
            Validate(new [] {roleName});
            var pattern = _resoucePath.ChildObject("{0}");
            var resourcePath = SDKUtil.FormatURIPath(pattern, new object[] {roleName});
            return ConfigureAndExecute<LoginRadiusDeleteResponse>(RequestType.Role, HttpMethod.DELETE, resourcePath);
        }

        public ApiResponse<LoginRadiusRoles> AddRolePermissions(string roleName, LoginRadiusDeleteRolePermissions permissions)
        {
            Validate(new [] {roleName});
            var pattern = _resoucePath.ChildObject("{0}/permission");
            var resourcePath = SDKUtil.FormatURIPath(pattern, new object[] {roleName});
            return ConfigureAndExecute<LoginRadiusRoles>(RequestType.Role, HttpMethod.PUT, resourcePath,
                permissions.ConvertToJson());
        }

        public ApiResponse<LoginRadiusRoles> DeleteRolePermissions(string roleName,
            LoginRadiusDeleteRolePermissions permissions)
        {
            Validate(new [] {roleName});
            var pattern = _resoucePath.ChildObject("{0}/permission");
            var resourcePath = SDKUtil.FormatURIPath(pattern, new object[] {roleName});
            return ConfigureAndExecute<LoginRadiusRoles>(RequestType.Role, HttpMethod.DELETE, resourcePath,
                permissions.ConvertToJson());
        }
    }
}