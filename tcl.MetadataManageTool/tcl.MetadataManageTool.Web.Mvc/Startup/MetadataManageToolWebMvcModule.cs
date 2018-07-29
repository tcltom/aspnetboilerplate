using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using tcl.MetadataManageTool.Configuration;

namespace tcl.MetadataManageTool.Web.Startup
{
    [DependsOn(typeof(MetadataManageToolWebCoreModule))]
    public class MetadataManageToolWebMvcModule : AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public MetadataManageToolWebMvcModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            Configuration.Navigation.Providers.Add<MetadataManageToolNavigationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MetadataManageToolWebMvcModule).GetAssembly());
        }
    }
}
