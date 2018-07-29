using Abp.MultiTenancy;
using tcl.MetadataManageTool.Authorization.Users;

namespace tcl.MetadataManageTool.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
