using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace ZyaWeb.Controllers
{
    public abstract class ZyaWebControllerBase: AbpController
    {
        protected ZyaWebControllerBase()
        {
            LocalizationSourceName = ZyaWebConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
