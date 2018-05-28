using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace ZyaWeb.EntityFrameworkCore
{
    public static class ZyaWebDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<ZyaWebDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<ZyaWebDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
