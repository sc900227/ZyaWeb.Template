using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ZyaWeb.Articles.Authorization;
using ZyaWeb.Articles.Dtos.LTMAutoMapper;
using ZyaWeb.Authorization;
using ZyaWeb.Persons.Authorization;
using ZyaWeb.Persons.Dtos.LTMAutoMapper;

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
            Configuration.Authorization.Providers.Add<PersonAppAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<ArticleAppAuthorizationProvider>();
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomerPersonMapper.CreateMappings);
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomerArticleMapper.CreateMappings);
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
