using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.SqlSugarCore;

namespace tcl.MetadataManageTool.SqlSugarCore
{
    [DependsOn(
        typeof(MetadataManageToolCoreModule),typeof(AbpSqlSugarCoreModule))]
    public class MetadataManageToolSqlSugarModule : AbpModule
    {
        public override void PreInitialize()
        {
 
        }

        public override void Initialize()
        {
            ////加载SqlSugar模块
            IocManager.RegisterAssemblyByConvention(typeof(MetadataManageToolSqlSugarModule).GetAssembly());
        }

        public override void PostInitialize()
        {

        }
    }
}
