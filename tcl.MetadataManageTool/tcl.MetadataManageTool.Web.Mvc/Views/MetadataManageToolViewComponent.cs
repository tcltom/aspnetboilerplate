using Abp.AspNetCore.Mvc.ViewComponents;

namespace tcl.MetadataManageTool.Web.Views
{
    public abstract class MetadataManageToolViewComponent : AbpViewComponent
    {
        protected MetadataManageToolViewComponent()
        {
            LocalizationSourceName = MetadataManageToolConsts.LocalizationSourceName;
        }
    }
}
