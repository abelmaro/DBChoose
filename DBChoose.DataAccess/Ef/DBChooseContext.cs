using DBChoose.DataAccess.Ef.EntityConfigurations;
using DBChoose.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DBChoose.DataAccess.Ef
{
    public class DBChooseContext : DbContext
    {
        public DbSet<ProviderInfo> ProvidersInfo
           => Set<ProviderInfo>();

        public DBChooseContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ProviderInfoEntityConfiguration());
        }
    }
}
