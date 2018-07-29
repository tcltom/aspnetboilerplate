using Abp.Auditing;
using Abp.Authorization;
using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using Abp.Configuration;
using Abp.SqlSugarCore;
using Abp.EntityHistory;
using Abp.Localization;
using Abp.Notifications;
using Abp.Organizations;
using SqlSugar;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Abp.Zero.SqlSugarCore
{
    public abstract class AbpZeroCommonDbContext<TRole, TUser, TSelf>
        where TRole : AbpRole<TUser>
        where TUser : AbpUser<TUser>
        where TSelf : AbpZeroCommonDbContext<TRole, TUser, TSelf>
    {
        /// <summary>
        /// Roles.
        /// </summary>
        public virtual ISugarQueryable<TRole> Roles { get; set; }

        /// <summary>
        /// Users.
        /// </summary>
        public virtual ISugarQueryable<TUser> Users { get; set; }

        /// <summary>
        /// User logins.
        /// </summary>
        public virtual ISugarQueryable<UserLogin> UserLogins { get; set; }

        /// <summary>
        /// User login attempts.
        /// </summary>
        public virtual ISugarQueryable<UserLoginAttempt> UserLoginAttempts { get; set; }

        /// <summary>
        /// User roles.
        /// </summary>
        public virtual ISugarQueryable<UserRole> UserRoles { get; set; }

        /// <summary>
        /// User claims.
        /// </summary>
        public virtual ISugarQueryable<UserClaim> UserClaims { get; set; }

        /// <summary>
        /// User tokens.
        /// </summary>
        public virtual ISugarQueryable<UserToken> UserTokens { get; set; }

        /// <summary>
        /// Role claims.
        /// </summary>
        public virtual ISugarQueryable<RoleClaim> RoleClaims { get; set; }

        /// <summary>
        /// Permissions.
        /// </summary>
        public virtual ISugarQueryable<PermissionSetting> Permissions { get; set; }

        /// <summary>
        /// Role permissions.
        /// </summary>
        public virtual ISugarQueryable<RolePermissionSetting> RolePermissions { get; set; }

        /// <summary>
        /// User permissions.
        /// </summary>
        public virtual ISugarQueryable<UserPermissionSetting> UserPermissions { get; set; }

        /// <summary>
        /// Settings.
        /// </summary>
        public virtual ISugarQueryable<Setting> Settings { get; set; }

        /// <summary>
        /// Audit logs.
        /// </summary>
        public virtual ISugarQueryable<AuditLog> AuditLogs { get; set; }

        /// <summary>
        /// Languages.
        /// </summary>
        public virtual ISugarQueryable<ApplicationLanguage> Languages { get; set; }

        /// <summary>
        /// LanguageTexts.
        /// </summary>
        public virtual ISugarQueryable<ApplicationLanguageText> LanguageTexts { get; set; }

        /// <summary>
        /// OrganizationUnits.
        /// </summary>
        public virtual ISugarQueryable<OrganizationUnit> OrganizationUnits { get; set; }

        /// <summary>
        /// UserOrganizationUnits.
        /// </summary>
        public virtual ISugarQueryable<UserOrganizationUnit> UserOrganizationUnits { get; set; }

        /// <summary>
        /// Tenant notifications.
        /// </summary>
        public virtual ISugarQueryable<TenantNotificationInfo> TenantNotifications { get; set; }

        /// <summary>
        /// User notifications.
        /// </summary>
        public virtual ISugarQueryable<UserNotificationInfo> UserNotifications { get; set; }

        /// <summary>
        /// Notification subscriptions.
        /// </summary>
        public virtual ISugarQueryable<NotificationSubscriptionInfo> NotificationSubscriptions { get; set; }

        /// <summary>
        /// Entity changes.
        /// </summary>
        public virtual ISugarQueryable<EntityChange> EntityChanges { get; set; }

        /// <summary>
        /// Entity change sets.
        /// </summary>
        public virtual ISugarQueryable<EntityChangeSet> EntityChangeSets { get; set; }

        /// <summary>
        /// Entity property changes.
        /// </summary>
        public virtual ISugarQueryable<EntityPropertyChange> EntityPropertyChanges { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        protected AbpZeroCommonDbContext()
        {
            
        }
    }
}