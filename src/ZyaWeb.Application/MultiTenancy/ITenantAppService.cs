using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ZyaWeb.MultiTenancy.Dto;

namespace ZyaWeb.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
