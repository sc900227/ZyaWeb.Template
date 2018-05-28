using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ZyaWeb.Configuration;

namespace ZyaWeb.Web.Host.Startup
{
    [DependsOn(
       typeof(ZyaWebWebCoreModule))]
    public class ZyaWebWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public ZyaWebWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ZyaWebWebHostModule).GetAssembly());
        }
    }
}
