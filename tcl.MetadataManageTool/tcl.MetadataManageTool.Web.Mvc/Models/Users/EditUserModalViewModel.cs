using System.Collections.Generic;
using System.Linq;
using tcl.MetadataManageTool.Roles.Dto;
using tcl.MetadataManageTool.Users.Dto;

namespace tcl.MetadataManageTool.Web.Models.Users
{
    public class EditUserModalViewModel
    {
        public UserDto User { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }

        public bool UserIsInRole(RoleDto role)
        {
            return User.RoleNames != null && User.RoleNames.Any(r => r == role.NormalizedName);
        }
    }
}
