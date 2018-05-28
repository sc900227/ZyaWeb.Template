using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using ZyaWeb.Configuration.Dto;

namespace ZyaWeb.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : ZyaWebAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
