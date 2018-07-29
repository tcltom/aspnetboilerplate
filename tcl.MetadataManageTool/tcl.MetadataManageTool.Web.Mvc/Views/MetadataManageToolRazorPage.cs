using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;

namespace tcl.MetadataManageTool.Web.Views
{
    public abstract class MetadataManageToolRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected MetadataManageToolRazorPage()
        {
            LocalizationSourceName = MetadataManageToolConsts.LocalizationSourceName;
        }
    }
}
