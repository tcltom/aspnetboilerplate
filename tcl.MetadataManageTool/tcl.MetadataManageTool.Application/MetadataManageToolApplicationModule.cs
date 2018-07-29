using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using tcl.MetadataManageTool.Authorization;

namespace tcl.MetadataManageTool
{
    [DependsOn(
        typeof(MetadataManageToolCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class MetadataManageToolApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<MetadataManageToolAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(MetadataManageToolApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
