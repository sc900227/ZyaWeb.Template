using System.Threading.Tasks;
using Abp.Application.Services;
using ZyaWeb.Sessions.Dto;

namespace ZyaWeb.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
