using System;
using System.Collections.Generic;
using System.Text;
using tcl.RepositoryExtend;

namespace tcl.MetadataManageTool.Models
{
    public class RoleQuery : BaseRepositoryQuery<RoleQuery>
    {
        public long SchoolId { get; set; }

        public string Name { get; set; }
    }
}

