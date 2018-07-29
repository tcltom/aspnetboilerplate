using Abp.Domain.Repositories;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Abp.SqlSugarCore.Repositories
{
    internal class SqlSugarCoreRepositoryInstaller : IWindsorInstaller
    {
    
        public SqlSugarCoreRepositoryInstaller()
        {
           
        }

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For(typeof (IRepository<>)).ImplementedBy(typeof (SqlSugarCoreRepositoryBase<>)).LifestyleTransient(),
                Component.For(typeof (IRepository<,>)).ImplementedBy(typeof (SqlSugarCoreRepositoryBase<,>)).LifestyleTransient()
                );
        }
    }
}
