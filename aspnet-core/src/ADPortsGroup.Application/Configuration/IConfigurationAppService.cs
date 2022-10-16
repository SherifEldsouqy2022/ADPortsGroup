using System.Threading.Tasks;
using ADPortsGroup.Configuration.Dto;

namespace ADPortsGroup.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
