using Abp.MultiTenancy;

namespace Abp.Zero.SqlSugarCore
{
    public interface IMultiTenantSeed
    {
        AbpTenantBase Tenant { get; set; }
    }
}