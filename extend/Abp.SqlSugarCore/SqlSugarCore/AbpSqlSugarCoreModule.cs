using Abp.Dependency;
using Abp.Modules;
using Abp.Orm;
using Abp.Reflection.Extensions;
using Abp.SqlSugarCore.Repositories;
using Abp.SqlSugarCore.Uow;

namespace Abp.SqlSugarCore
{
    [DependsOn(typeof(AbpKernelModule))]
    public class AbpSqlSugarCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
          
        }

        public override void Initialize()
        {
            IocManager.IocContainer.Install(new SqlSugarCoreRepositoryInstaller());
            IocManager.RegisterAssemblyByConvention(typeof(AbpSqlSugarCoreModule).GetAssembly());
        }

        public override void PostInitialize()
        {

        }
    }
}
