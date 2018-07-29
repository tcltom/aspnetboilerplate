using System;
using System.Collections.Generic;
using System.Text;

namespace tcl.MetadataManageTool.Models
{
    public class SchoolSave
    {
        public long SchoolId { get; set; }

        public string Name { get; set; }

        public bool IsDeleted { get; set; }

        public int TenantId { get; set; }
    }
}
