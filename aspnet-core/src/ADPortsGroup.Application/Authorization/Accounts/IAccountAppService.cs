using System.Threading.Tasks;
using Abp.Application.Services;
using ADPortsGroup.Authorization.Accounts.Dto;

namespace ADPortsGroup.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    { 

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
