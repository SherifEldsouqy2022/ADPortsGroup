using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using ADPortsGroup.Configuration.Dto;

namespace ADPortsGroup.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : ADPortsGroupAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
