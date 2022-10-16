using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace ADPortsGroup.Controllers
{
    public abstract class ADPortsGroupControllerBase: AbpController
    {
        protected ADPortsGroupControllerBase()
        {
            LocalizationSourceName = ADPortsGroupConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
