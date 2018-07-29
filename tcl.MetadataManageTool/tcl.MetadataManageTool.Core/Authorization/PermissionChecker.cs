using Abp.Authorization;
using tcl.MetadataManageTool.Authorization.Roles;
using tcl.MetadataManageTool.Authorization.Users;

namespace tcl.MetadataManageTool.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
