using System.Collections.Generic;
using LoginRadiusSDK.V2.Entity;
using LoginRadiusSDK.V2.Models;
using LoginRadiusSDK.V2.Util;
using static LoginRadiusSDK.V2.Util.LoginRadiusArgumentValidator;

namespace LoginRadiusSDK.V2.Api
{
    public class RolesApi : LoginRadiusResource
    {

        /// <summary>
        /// This API creates a role with permissions.
        /// </summary>
        /// <param name="accountRolesCreate">Object containing data to create a new role.</param>
        /// <returns>LoginRadiusRolesResponse: Contains data on the newly created role.</returns>
        public ApiResponse<LoginRadiusRolesResponse> CreateRoles(LoginRadiusRolesCreate accountRolesCreate)
        {
            Validate(new[] { accountRolesCreate });
            return ConfigureAndExecute<LoginRadiusRolesResponse>(RequestType.Role, HttpMethod.POST,
                "role", accountRolesCreate.ConvertToJson());
        }

        /// <summary>
        /// This API Gets the contexts that have been configured and the associated roles and permissions.
        /// </summary>
        /// <param name="uid">Uid for account getting queried.</param>
        /// <returns>RoleContextData: Role context data for the associated account.</returns>
        public ApiResponse<RoleContextData> GetContextWithRolesAndPermissions(string uid)
        {
            Validate(new[] { uid });
            var resourcePath = SDKUtil.FormatURIPath(new LoginRadiusResourcePath("{0}/rolecontext"), new object[] { uid });
            return ConfigureAndExecute<RoleContextData>(RequestType.Identity, HttpMethod.GET, resourcePath);
        }

        /// <summary>
        /// This API is used to get a list of all roles.
        /// </summary>
        /// <returns>LoginRadiusRolesResponse: A list of all roles set up.</returns>
        public ApiResponse<LoginRadiusRolesResponse> GetRoles()
        {
            return ConfigureAndExecute<LoginRadiusRolesResponse>(RequestType.Role, HttpMethod.GET, "role");
        }

        /// <summary>
        /// API is used to retrieve all the assigned roles of a particular User.
        /// </summary>
        /// <param name="uid">Uid for account getting queried.</param>
        /// <returns>LoginRadiusUserRoles: Roles for the associated account.</returns>
        public ApiResponse<LoginRadiusUserRoles> GetAccountRole(string uid)
        {
            Validate(new[] { uid });
            var resourcePath = SDKUtil.FormatURIPath("{0}/role", new object[] { uid });
            return ConfigureAndExecute<LoginRadiusUserRoles>(RequestType.Identity, HttpMethod.GET, resourcePath);
        }

        /// <summary>
        /// This API is used to add permissions to a given role.
        /// </summary>
        /// <param name="roleName">Role name getting updated.</param>
        /// <param name="permissions">Object containing data for permissions being added.</param>
        /// <returns>LoginRadiusRoles: Updated role.</returns>
        public ApiResponse<LoginRadiusRoles> AddRolePermissions(string roleName, LoginRadiusDeleteRolePermissions permissions)
        {
            Validate(new[] { roleName });
            var resourcePath = SDKUtil.FormatURIPath("role/{0}/permission", new object[] { roleName });
            return ConfigureAndExecute<LoginRadiusRoles>(RequestType.Role, HttpMethod.PUT, resourcePath,
                permissions.ConvertToJson());
        }

        /// <summary>
        /// This API is used to assign a role to a user.
        /// </summary>
        /// <param name="uid">Uid of user getting assigned a role.</param>
        /// <param name="accountRoles">Object containing data for roles being assigned to user.</param>
        /// <returns>LoginRadiusAccountRolesUpsert: A list of the user's updated roles.</returns>
        public ApiResponse<LoginRadiusAccountRolesUpsert> RolesAssignToUser(string uid, LoginRadiusAccountRolesUpsert accountRoles)
        {
            Validate(new List<object> { uid, accountRoles });
            var resourcePath = SDKUtil.FormatURIPath("{0}/role", new object[] { uid });
            return ConfigureAndExecute<LoginRadiusAccountRolesUpsert>(RequestType.Identity, HttpMethod.PUT,
                resourcePath, accountRoles.ConvertToJson());
        }

        /// <summary>
        /// This API creates a Context with a set of Roles
        /// </summary>
        /// <param name="uid">Uid of account with contexts getting added.</param>
        /// <param name="roleContext">The role context data being assigned to the user.</param>
        /// <returns>RoleContextData: Role context data in an object.</returns>
        public ApiResponse<RoleContextData> UpsertContext(string uid, AccountRoleContextModel roleContext)
        {
            Validate(new[] { uid });
            var resourcePath = SDKUtil.FormatURIPath(new LoginRadiusResourcePath("{0}/rolecontext"), new object[] { uid });
            return ConfigureAndExecute<RoleContextData>(RequestType.Identity, HttpMethod.PUT, resourcePath,
                roleContext.ConvertToJson());
        }

        /// <summary>
        /// This API is used to delete a role.
        /// </summary>
        /// <param name="roleName">Role name of role being deleted.</param>
        /// <returns>LoginRadiusDeleteResponse: Boolean to show if role was deleted.</returns>
        public ApiResponse<LoginRadiusDeleteResponse> DeleteRole(string roleName)
        {
            Validate(new[] { roleName });
            var resourcePath = SDKUtil.FormatURIPath("role/{0}", new object[] { roleName });
            return ConfigureAndExecute<LoginRadiusDeleteResponse>(RequestType.Role, HttpMethod.DELETE, resourcePath);
        }

        /// <summary>
        /// This API is used to unassign roles from a user.
        /// </summary>
        /// <param name="uid">Uid of account with roles being removed.</param>
        /// <param name="accountRoles">Roles being unassigned from user.</param>
        /// <returns>LoginRadiusDeleteResponse: Boolean to show if role was deleted.</returns>
        public ApiResponse<LoginRadiusDeleteResponse> UnAssignRolesToUser(string uid,
            LoginRadiusAccountRolesUpsert accountRoles)
        {
            Validate(new List<object> { uid, accountRoles });
            var resourcePath = SDKUtil.FormatURIPath("{0}/role", new object[] { uid });
            return ConfigureAndExecute<LoginRadiusDeleteResponse>(RequestType.Identity, HttpMethod.DELETE, resourcePath,
                accountRoles.ConvertToJson());
        }

        /// <summary>
        /// This API Deletes the specified Role Context
        /// </summary>
        /// <param name="uid">Uid of account with roles being removed.</param>
        /// <param name="rolecontextname">Name of role context being deleted.</param>
        /// <returns>LoginRadiusDeleteResponse: Boolean to show if context was deleted.</returns>
        public ApiResponse<LoginRadiusDeleteResponse> DeleteContext(string uid, string rolecontextname)
        {
            Validate(new[] { uid, rolecontextname });
            var resourcePath =
                SDKUtil.FormatURIPath(new LoginRadiusResourcePath("{0}/rolecontext/{1}"),
                    new object[] { uid, rolecontextname });
            return ConfigureAndExecute<LoginRadiusDeleteResponse>(RequestType.Identity, HttpMethod.DELETE, resourcePath);
        }

        /// <summary>
        /// This API is used to remove permissions from a role.
        /// </summary>
        /// <param name="roleName">Role name of role with permissions getting deleted.</param>
        /// <param name="permissions">Permissions getting deleted.</param>
        /// <returns>LoginRadiusDeleteResponse: Boolean to show if permissions was deleted.</returns>
        public ApiResponse<LoginRadiusRoles> DeleteRolePermissions(string roleName,
            LoginRadiusDeleteRolePermissions permissions)
        {
            Validate(new[] { roleName });
            var resourcePath = SDKUtil.FormatURIPath("role/{0}/permission", new object[] { roleName });
            return ConfigureAndExecute<LoginRadiusRoles>(RequestType.Role, HttpMethod.DELETE, resourcePath,
                permissions.ConvertToJson());
        }

        /// <summary>
        /// This API Deletes the specified Role from a Context.
        /// </summary>
        /// <param name="uid">Uid of account with roles being removed.</param>
        /// <param name="rolecontextname">Name of role context being deleted.</param>
        /// <param name="roles">Next of role context being deleted.</param>
        /// <returns>LoginRadiusDeleteResponse: Boolean to show if role was deleted.</returns>
        public ApiResponse<LoginRadiusDeleteResponse> DeleteRoleFromContext(string uid, string rolecontextname,
            LoginRadiusAccountRolesUpsert roles)
        {
            Validate(new[] { uid, rolecontextname });
            var resourcePath = SDKUtil.FormatURIPath(new LoginRadiusResourcePath("{0}/rolecontext/{1}/role"),
                new object[] { uid, rolecontextname });
            return ConfigureAndExecute<LoginRadiusDeleteResponse>(RequestType.Identity, HttpMethod.DELETE, resourcePath,
                roles.ConvertToJson());
        }

        /// <summary>
        /// This API deletes additional permissions from a context.
        /// </summary>
        /// <param name="uid">Uid of account with permissions getting deleted.</param>
        /// <param name="rolecontextname">Name of the role context.</param>
        /// <param name="additionalRolePermissions">Object containing permissions targeted for deletion.</param>
        /// <returns>LoginRadiusDeleteResponse: Boolean to show if permissions were deleted.</returns>
        public ApiResponse<LoginRadiusDeleteResponse> DeleteAdditionalPermissionFromContext(string uid,
            string rolecontextname, AdditionalRolePermissions additionalRolePermissions)
        {
            Validate(new[] { uid, rolecontextname });
            var resourcePath =
                SDKUtil.FormatURIPath(new LoginRadiusResourcePath("{0}/rolecontext/{1}/additionalpermission"),
                    new object[] { uid, rolecontextname });
            return ConfigureAndExecute<LoginRadiusDeleteResponse>(RequestType.Identity, HttpMethod.DELETE, resourcePath,
                additionalRolePermissions.ConvertToJson());
        }
    }
}