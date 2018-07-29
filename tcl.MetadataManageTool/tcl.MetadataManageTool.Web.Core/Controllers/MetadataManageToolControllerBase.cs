using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace tcl.MetadataManageTool.Controllers
{
    public abstract class MetadataManageToolControllerBase: AbpController
    {
        protected MetadataManageToolControllerBase()
        {
            LocalizationSourceName = MetadataManageToolConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
