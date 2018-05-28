using System.Threading.Tasks;
using Abp.Application.Services;
using ZyaWeb.Authorization.Accounts.Dto;

namespace ZyaWeb.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
