using System.Threading.Tasks;
using ZyaWeb.Configuration.Dto;

namespace ZyaWeb.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
