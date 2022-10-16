using Abp.Authorization;
using ADPortsGroup.Authorization.Roles;
using ADPortsGroup.Authorization.Users;

namespace ADPortsGroup.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
