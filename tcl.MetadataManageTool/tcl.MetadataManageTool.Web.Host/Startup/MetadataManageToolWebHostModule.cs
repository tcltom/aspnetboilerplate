using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using tcl.MetadataManageTool.Configuration;

namespace tcl.MetadataManageTool.Web.Host.Startup
{
    [DependsOn(
       typeof(MetadataManageToolWebCoreModule))]
    public class MetadataManageToolWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public MetadataManageToolWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MetadataManageToolWebHostModule).GetAssembly());
        }
    }
}
