using System.Collections.Generic;
using LoginRadiusSDK.V2.Util.Serialization;

namespace LoginRadiusSDK.V2.Models
{
    public class LoginRadiusAccountRolesResponse
    {
        public List<string> Data { get; set; }
        public bool ?SignIn { get; set; }
    }

    public class LoginRadiusAccountRolesUpsert : LoginRadiusSerializableObject
    {
        public List<string> roles { get; set; }
    }

    public class LoginRadiusUserRoles : LoginRadiusSerializableObject
    {
        public string[] Roles { get; set; }
    }

    public class AdditionalRolePermissions : LoginRadiusSerializableObject
    {
        public List<string> AdditionalPermissions { get; set; }
    }

    public class RoleContextRoleModel : LoginRadiusSerializableObject
    {
        public string Context { get; set; }
        public List<string> Roles { get; set; }
        public List<string> AdditionalPermissions { get; set; }
    }

    public class AccountRoleContextModel : LoginRadiusSerializableObject
    {
        public List<RoleContextRoleModel> RoleContext { get; set; }
    }

    public class RoleContextData: LoginRadiusSerializableObject
    {
        public List<RoleContextRoleModel> Data { get; set; }
    }
}