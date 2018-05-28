using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ZyaWeb.Authorization;

namespace ZyaWeb
{
    [DependsOn(
        typeof(ZyaWebCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class ZyaWebApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<ZyaWebAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(ZyaWebApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
