using Microsoft.EntityFrameworkCore;

namespace AspNetCore.Configuration.DbConfiguration.Context
{
    public class ConfigurationContext : DbContext
    {
        public ConfigurationContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<MyOption> MyOptions { get; set; }
    }
}