using System.Collections.Generic;
using tcl.MetadataManageTool.Roles.Dto;

namespace tcl.MetadataManageTool.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }

        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
