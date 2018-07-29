using Abp.Authorization.Users;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Linq;
using tcl.MetadataManageTool.Authorization.Roles;

namespace tcl.MetadataManageTool.Authorization.Users
{
    public class UserStore : AbpUserStore<Role, User>
    {
        public UserStore(
            IUnitOfWorkManager unitOfWorkManager, 
            IRepository<User, long> userRepository, 
            IRepository<Role> roleRepository,
            IRepository<UserClaim, long> uerClaimsRepository,
            //IAsyncQueryableExecuter asyncQueryableExecuter, 
            IRepository<UserRole, long> userRoleRepository, 
            IRepository<UserLogin, long> userLoginRepository, 
            IRepository<UserClaim, long> userClaimRepository, 
            IRepository<UserPermissionSetting, long> userPermissionSettingRepository) 
            : base(
                  unitOfWorkManager, 
                  userRepository, 
                  roleRepository,
                  uerClaimsRepository,
                 // asyncQueryableExecuter, 
                  userRoleRepository, 
                  userLoginRepository, 
                  userClaimRepository,
                  userPermissionSettingRepository)
        {
        }
    }
}
