using Abp.Application.Editions;
using Abp.Application.Features;
using Abp.Auditing;
using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using Abp.BackgroundJobs;
using Abp.MultiTenancy;
using Abp.Notifications;
using SqlSugar;

namespace Abp.Zero.SqlSugarCore
{
    /// <summary>
    /// Base DbContext for ABP zero.
    /// Derive your DbContext from this class to have base entities.
    /// </summary>
    public abstract class AbpZeroDbContext<TTenant, TRole, TUser, TSelf> : AbpZeroCommonDbContext<TRole, TUser, TSelf>
        where TTenant : AbpTenant<TUser>
        where TRole : AbpRole<TUser>
        where TUser : AbpUser<TUser>
        where TSelf : AbpZeroDbContext<TTenant, TRole, TUser, TSelf>
    {
        /// <summary>
        /// Tenants
        /// </summary>
        public virtual ISugarQueryable<TTenant> Tenants { get; set; }

        /// <summary>
        /// Editions.
        /// </summary>
        public virtual ISugarQueryable<Edition> Editions { get; set; }

        /// <summary>
        /// FeatureSettings.
        /// </summary>
        public virtual ISugarQueryable<FeatureSetting> FeatureSettings { get; set; }

        /// <summary>
        /// TenantFeatureSetting.
        /// </summary>
        public virtual ISugarQueryable<TenantFeatureSetting> TenantFeatureSettings { get; set; }

        /// <summary>
        /// EditionFeatureSettings.
        /// </summary>
        public virtual ISugarQueryable<EditionFeatureSetting> EditionFeatureSettings { get; set; }

        /// <summary>
        /// Background jobs.
        /// </summary>
        public virtual ISugarQueryable<BackgroundJobInfo> BackgroundJobs { get; set; }

        /// <summary>
        /// User accounts
        /// </summary>
        public virtual ISugarQueryable<UserAccount> UserAccounts { get; set; }

        /// <summary>
        /// Notifications.
        /// </summary>
        public virtual ISugarQueryable<NotificationInfo> Notifications { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        protected AbpZeroDbContext()
        {

        }
    }
}
