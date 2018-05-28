using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using ZyaWeb.Configuration;
using ZyaWeb.Web;

namespace ZyaWeb.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class ZyaWebDbContextFactory : IDesignTimeDbContextFactory<ZyaWebDbContext>
    {
        public ZyaWebDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ZyaWebDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            ZyaWebDbContextConfigurer.Configure(builder, configuration.GetConnectionString(ZyaWebConsts.ConnectionStringName));

            return new ZyaWebDbContext(builder.Options);
        }
    }
}
