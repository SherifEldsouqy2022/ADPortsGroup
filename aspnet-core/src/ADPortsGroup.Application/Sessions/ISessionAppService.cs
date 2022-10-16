using System.Threading.Tasks;
using Abp.Application.Services;
using ADPortsGroup.Sessions.Dto;

namespace ADPortsGroup.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
