using Abp.Authorization;
using ZyaWeb.Authorization.Roles;
using ZyaWeb.Authorization.Users;

namespace ZyaWeb.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
