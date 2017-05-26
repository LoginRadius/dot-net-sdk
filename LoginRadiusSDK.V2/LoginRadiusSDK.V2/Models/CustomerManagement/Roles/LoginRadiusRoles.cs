using System.Collections.Generic;
using LoginRadiusSDK.V2.Util.Serialization;

namespace LoginRadiusSDK.V2.Models
{
    public class LoginRadiusRolesResponse
    {
        public List<LoginRadiusRoles> data { get; set; }
        public string Count { get; set; }
    }

    public class LoginRadiusRoles : LoginRadiusRolePermissions
    {
        public string Name { get; set; }
    }

    public class LoginRadiusRolePermissions : LoginRadiusSerializableObject
    {
        public Dictionary<string, bool> Permissions { get; set; }
    }

    public class LoginRadiusRolesCreate : LoginRadiusSerializableObject
    {
        public List<LoginRadiusRoles> Roles { get; set; }
    }


    public class LoginRadiusDeleteRolePermissions : LoginRadiusSerializableObject
    {
        public string[] Permissions { get; set; }
    }
}