using System;
using System.Collections.Generic;
using System.Text;

namespace tcl.MetadataManageTool.Models
{
    public class RoleOut : Authorization.Roles.Role
    {
        public string UserName { get; set; }

    }
}
