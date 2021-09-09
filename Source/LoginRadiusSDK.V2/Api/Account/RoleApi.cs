//-----------------------------------------------------------------------
// <copyright file="RoleApi.cs" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2019 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using LoginRadiusSDK.V2.Common;
using System.Threading.Tasks;
using LoginRadiusSDK.V2.Util;
using LoginRadiusSDK.V2.Models.ResponseModels.OtherObjects;
using LoginRadiusSDK.V2.Models.RequestModels;
using LoginRadiusSDK.V2.Models.ResponseModels;
using LoginRadiusSDK.V2.Models.ResponseModels.UserProfile.Objects;

namespace LoginRadiusSDK.V2.Api.Account
{
    public class RoleApi : LoginRadiusResource
    {
        /// <summary>
        /// API is used to retrieve all the assigned roles of a particular User.
        /// </summary>
        /// <param name="uid">UID, the unified identifier for each user account</param>
        /// <returns>Response containing Definition of Complete Roles data</returns>
        /// 18.6

        public async Task<ApiResponse<LoginRadiusSDK.V2.Models.ResponseModels.OtherObjects.AccountRolesModel>> GetRolesByUid(string uid)
        {
            if (string.IsNullOrWhiteSpace(uid))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(uid));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "apiSecret", ConfigDictionary[LRConfigConstants.LoginRadiusApiSecret] }
            };

            var resourcePath = $"identity/v2/manage/account/{uid}/role";
            
            return await ConfigureAndExecute<LoginRadiusSDK.V2.Models.ResponseModels.OtherObjects.AccountRolesModel>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// This API is used to assign your desired roles to a given user.
        /// </summary>
        /// <param name="accountRolesModel">Model Class containing Definition of payload for Create Role API</param>
        /// <param name="uid">UID, the unified identifier for each user account</param>
        /// <returns>Response containing Definition of Complete Roles data</returns>
        /// 18.7

        public async Task<ApiResponse<LoginRadiusSDK.V2.Models.ResponseModels.OtherObjects.AccountRolesModel>> AssignRolesByUid(LoginRadiusSDK.V2.Models.RequestModels.AccountRolesModel accountRolesModel, string uid)
        {
            if (accountRolesModel == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(accountRolesModel));
            }
            if (string.IsNullOrWhiteSpace(uid))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(uid));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "apiSecret", ConfigDictionary[LRConfigConstants.LoginRadiusApiSecret] }
            };

            var resourcePath = $"identity/v2/manage/account/{uid}/role";
            
            return await ConfigureAndExecute<LoginRadiusSDK.V2.Models.ResponseModels.OtherObjects.AccountRolesModel>(HttpMethod.PUT, resourcePath, queryParameters, ConvertToJson(accountRolesModel));
        }
        /// <summary>
        /// This API is used to unassign roles from a user.
        /// </summary>
        /// <param name="accountRolesModel">Model Class containing Definition of payload for Create Role API</param>
        /// <param name="uid">UID, the unified identifier for each user account</param>
        /// <returns>Response containing Definition of Delete Request</returns>
        /// 18.8

        public async Task<ApiResponse<DeleteResponse>> UnassignRolesByUid(LoginRadiusSDK.V2.Models.RequestModels.AccountRolesModel accountRolesModel, string uid)
        {
            if (accountRolesModel == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(accountRolesModel));
            }
            if (string.IsNullOrWhiteSpace(uid))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(uid));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "apiSecret", ConfigDictionary[LRConfigConstants.LoginRadiusApiSecret] }
            };

            var resourcePath = $"identity/v2/manage/account/{uid}/role";
            
            return await ConfigureAndExecute<DeleteResponse>(HttpMethod.DELETE, resourcePath, queryParameters, ConvertToJson(accountRolesModel));
        }
        /// <summary>
        /// This API Gets the contexts that have been configured and the associated roles and permissions.
        /// </summary>
        /// <param name="uid">UID, the unified identifier for each user account</param>
        /// <returns>Complete user RoleContext data</returns>
        /// 18.9

        public async Task<ApiResponse<ListReturn<RoleContext>>> GetRoleContextByUid(string uid)
        {
            if (string.IsNullOrWhiteSpace(uid))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(uid));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "apiSecret", ConfigDictionary[LRConfigConstants.LoginRadiusApiSecret] }
            };

            var resourcePath = $"identity/v2/manage/account/{uid}/rolecontext";
            
            return await ConfigureAndExecute<ListReturn<RoleContext>>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// The API is used to retrieve role context by the context name.
        /// </summary>
        /// <param name="contextName">Name of context</param>
        /// <returns>Complete user RoleContext data</returns>
        /// 18.10

        public async Task<ApiResponse<ListReturn<RoleContextResponseModel>>> GetRoleContextByContextName(string contextName)
        {
            if (string.IsNullOrWhiteSpace(contextName))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(contextName));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "apiSecret", ConfigDictionary[LRConfigConstants.LoginRadiusApiSecret] }
            };

            var resourcePath = $"identity/v2/manage/account/rolecontext/{contextName}";
            
            return await ConfigureAndExecute<ListReturn<RoleContextResponseModel>>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// This API creates a Context with a set of Roles
        /// </summary>
        /// <param name="accountRoleContextModel">Model Class containing Definition of RoleContext payload</param>
        /// <param name="uid">UID, the unified identifier for each user account</param>
        /// <returns>Complete user RoleContext data</returns>
        /// 18.11

        public async Task<ApiResponse<ListReturn<RoleContext>>> UpdateRoleContextByUid(AccountRoleContextModel accountRoleContextModel, string uid)
        {
            if (accountRoleContextModel == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(accountRoleContextModel));
            }
            if (string.IsNullOrWhiteSpace(uid))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(uid));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "apiSecret", ConfigDictionary[LRConfigConstants.LoginRadiusApiSecret] }
            };

            var resourcePath = $"identity/v2/manage/account/{uid}/rolecontext";
            
            return await ConfigureAndExecute<ListReturn<RoleContext>>(HttpMethod.PUT, resourcePath, queryParameters, ConvertToJson(accountRoleContextModel));
        }
        /// <summary>
        /// This API Deletes the specified Role Context
        /// </summary>
        /// <param name="contextName">Name of context</param>
        /// <param name="uid">UID, the unified identifier for each user account</param>
        /// <returns>Response containing Definition of Delete Request</returns>
        /// 18.12

        public async Task<ApiResponse<DeleteResponse>> DeleteRoleContextByUid(string contextName, string uid)
        {
            if (string.IsNullOrWhiteSpace(contextName))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(contextName));
            }
            if (string.IsNullOrWhiteSpace(uid))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(uid));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "apiSecret", ConfigDictionary[LRConfigConstants.LoginRadiusApiSecret] }
            };

            var resourcePath = $"identity/v2/manage/account/{uid}/rolecontext/{contextName}";
            
            return await ConfigureAndExecute<DeleteResponse>(HttpMethod.DELETE, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// This API Deletes the specified Role from a Context.
        /// </summary>
        /// <param name="contextName">Name of context</param>
        /// <param name="roleContextRemoveRoleModel">Model Class containing Definition of payload for RoleContextRemoveRole API</param>
        /// <param name="uid">UID, the unified identifier for each user account</param>
        /// <returns>Response containing Definition of Delete Request</returns>
        /// 18.13

        public async Task<ApiResponse<DeleteResponse>> DeleteRolesFromRoleContextByUid(string contextName, RoleContextRemoveRoleModel roleContextRemoveRoleModel,
        string uid)
        {
            if (string.IsNullOrWhiteSpace(contextName))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(contextName));
            }
            if (roleContextRemoveRoleModel == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(roleContextRemoveRoleModel));
            }
            if (string.IsNullOrWhiteSpace(uid))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(uid));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "apiSecret", ConfigDictionary[LRConfigConstants.LoginRadiusApiSecret] }
            };

            var resourcePath = $"identity/v2/manage/account/{uid}/rolecontext/{contextName}/role";
            
            return await ConfigureAndExecute<DeleteResponse>(HttpMethod.DELETE, resourcePath, queryParameters, ConvertToJson(roleContextRemoveRoleModel));
        }
        /// <summary>
        /// This API Deletes Additional Permissions from Context.
        /// </summary>
        /// <param name="contextName">Name of context</param>
        /// <param name="roleContextAdditionalPermissionRemoveRoleModel">Model Class containing Definition of payload for RoleContextAdditionalPermissionRemoveRole API</param>
        /// <param name="uid">UID, the unified identifier for each user account</param>
        /// <returns>Response containing Definition of Delete Request</returns>
        /// 18.14

        public async Task<ApiResponse<DeleteResponse>> DeleteAdditionalPermissionFromRoleContextByUid(string contextName, RoleContextAdditionalPermissionRemoveRoleModel roleContextAdditionalPermissionRemoveRoleModel,
        string uid)
        {
            if (string.IsNullOrWhiteSpace(contextName))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(contextName));
            }
            if (roleContextAdditionalPermissionRemoveRoleModel == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(roleContextAdditionalPermissionRemoveRoleModel));
            }
            if (string.IsNullOrWhiteSpace(uid))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(uid));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "apiSecret", ConfigDictionary[LRConfigConstants.LoginRadiusApiSecret] }
            };

            var resourcePath = $"identity/v2/manage/account/{uid}/rolecontext/{contextName}/additionalpermission";
            
            return await ConfigureAndExecute<DeleteResponse>(HttpMethod.DELETE, resourcePath, queryParameters, ConvertToJson(roleContextAdditionalPermissionRemoveRoleModel));
        }
        /// <summary>
        /// This API retrieves the complete list of created roles with permissions of your app.
        /// </summary>
        /// <returns>Complete user Roles List data</returns>
        /// 41.1

        public async Task<ApiResponse<ListData<LoginRadiusSDK.V2.Models.ResponseModels.OtherObjects.RoleModel>>> GetRolesList()
        {
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "apiSecret", ConfigDictionary[LRConfigConstants.LoginRadiusApiSecret] }
            };

            var resourcePath = "identity/v2/manage/role";
            
            return await ConfigureAndExecute<ListData<LoginRadiusSDK.V2.Models.ResponseModels.OtherObjects.RoleModel>>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// This API creates a role with permissions.
        /// </summary>
        /// <param name="rolesModel">Model Class containing Definition of payload for Roles API</param>
        /// <returns>Complete user Roles data</returns>
        /// 41.2

        public async Task<ApiResponse<ListData<LoginRadiusSDK.V2.Models.ResponseModels.OtherObjects.RoleModel>>> CreateRoles(RolesModel rolesModel)
        {
            if (rolesModel == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(rolesModel));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "apiSecret", ConfigDictionary[LRConfigConstants.LoginRadiusApiSecret] }
            };

            var resourcePath = "identity/v2/manage/role";
            
            return await ConfigureAndExecute<ListData<LoginRadiusSDK.V2.Models.ResponseModels.OtherObjects.RoleModel>>(HttpMethod.POST, resourcePath, queryParameters, ConvertToJson(rolesModel));
        }
        /// <summary>
        /// This API is used to delete the role.
        /// </summary>
        /// <param name="role">Created RoleName</param>
        /// <returns>Response containing Definition of Delete Request</returns>
        /// 41.3

        public async Task<ApiResponse<DeleteResponse>> DeleteRole(string role)
        {
            if (string.IsNullOrWhiteSpace(role))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(role));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "apiSecret", ConfigDictionary[LRConfigConstants.LoginRadiusApiSecret] }
            };

            var resourcePath = $"identity/v2/manage/role/{role}";
            
            return await ConfigureAndExecute<DeleteResponse>(HttpMethod.DELETE, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// This API is used to add permissions to a given role.
        /// </summary>
        /// <param name="permissionsModel">Model Class containing Definition for PermissionsModel Property</param>
        /// <param name="role">Created RoleName</param>
        /// <returns>Response containing Definition of Complete role data</returns>
        /// 41.4

        public async Task<ApiResponse<LoginRadiusSDK.V2.Models.ResponseModels.OtherObjects.RoleModel>> AddRolePermissions(PermissionsModel permissionsModel, string role)
        {
            if (permissionsModel == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(permissionsModel));
            }
            if (string.IsNullOrWhiteSpace(role))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(role));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "apiSecret", ConfigDictionary[LRConfigConstants.LoginRadiusApiSecret] }
            };

            var resourcePath = $"identity/v2/manage/role/{role}/permission";
            
            return await ConfigureAndExecute<LoginRadiusSDK.V2.Models.ResponseModels.OtherObjects.RoleModel>(HttpMethod.PUT, resourcePath, queryParameters, ConvertToJson(permissionsModel));
        }
        /// <summary>
        /// API is used to remove permissions from a role.
        /// </summary>
        /// <param name="permissionsModel">Model Class containing Definition for PermissionsModel Property</param>
        /// <param name="role">Created RoleName</param>
        /// <returns>Response containing Definition of Complete role data</returns>
        /// 41.5

        public async Task<ApiResponse<LoginRadiusSDK.V2.Models.ResponseModels.OtherObjects.RoleModel>> RemoveRolePermissions(PermissionsModel permissionsModel, string role)
        {
            if (permissionsModel == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(permissionsModel));
            }
            if (string.IsNullOrWhiteSpace(role))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(role));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "apiSecret", ConfigDictionary[LRConfigConstants.LoginRadiusApiSecret] }
            };

            var resourcePath = $"identity/v2/manage/role/{role}/permission";
            
            return await ConfigureAndExecute<LoginRadiusSDK.V2.Models.ResponseModels.OtherObjects.RoleModel>(HttpMethod.DELETE, resourcePath, queryParameters, ConvertToJson(permissionsModel));
        }
    }
}