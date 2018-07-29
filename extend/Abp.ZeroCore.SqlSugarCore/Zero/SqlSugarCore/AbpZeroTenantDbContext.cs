using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using Abp.MultiTenancy;
using SqlSugar;

namespace Abp.Zero.SqlSugarCore
{
    [MultiTenancySide(MultiTenancySides.Host)]
    public abstract class AbpZeroTenantDbContext<TRole, TUser,TSelf> : AbpZeroCommonDbContext<TRole, TUser,TSelf>
        where TRole : AbpRole<TUser>
        where TUser : AbpUser<TUser>
        where TSelf: AbpZeroTenantDbContext<TRole, TUser, TSelf>
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        protected AbpZeroTenantDbContext()
        {

        }
    }
}