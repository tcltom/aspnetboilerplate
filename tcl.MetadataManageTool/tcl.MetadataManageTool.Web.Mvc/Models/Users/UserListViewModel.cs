using System.Collections.Generic;
using tcl.MetadataManageTool.Roles.Dto;
using tcl.MetadataManageTool.Users.Dto;

namespace tcl.MetadataManageTool.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
