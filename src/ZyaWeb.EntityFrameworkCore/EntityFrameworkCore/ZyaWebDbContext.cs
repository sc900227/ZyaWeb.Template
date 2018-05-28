using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using ZyaWeb.Authorization.Roles;
using ZyaWeb.Authorization.Users;
using ZyaWeb.MultiTenancy;
using ZyaWeb.PersonArticles.Articles;
using ZyaWeb.PersonArticles.Persons;

namespace ZyaWeb.EntityFrameworkCore
{
    public class ZyaWebDbContext : AbpZeroDbContext<Tenant, Role, User, ZyaWebDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Article> Articles { get; set; }
        public DbSet<Person> Persons { get; set; }
        public ZyaWebDbContext(DbContextOptions<ZyaWebDbContext> options)
            : base(options)
        {
        }
    }
}
