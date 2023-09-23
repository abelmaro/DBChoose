using DBChoose.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DBChoose.DataAccess.Ef.EntityConfigurations
{
    public class ProviderInfoEntityConfiguration : IEntityTypeConfiguration<ProviderInfo>
    {
        public void Configure(EntityTypeBuilder<ProviderInfo> builder)
        {
            builder.Property(prop => prop.Id)
                           .ValueGeneratedOnAdd();

            builder.Property(prop => prop.Description)
                .HasMaxLength(250)
                .IsRequired();

            var databaseProvider = Environment.GetEnvironmentVariable("DATABASE_PROVIDER");

            if (databaseProvider == DbProviders.Sql)
            {
                SeedSqlDatabase(builder);
            }
            else if (databaseProvider == DbProviders.PostgreSql)
            {
                SeedPostgresqlDatabase(builder);
            }
            else
            {
                throw new InvalidOperationException("Proveedor de base de datos no reconocido");
            }
        }

        private void SeedSqlDatabase(EntityTypeBuilder<ProviderInfo> builder)
        {
            builder.HasData(
                new ProviderInfo { Id = 1, Description = "SQL" }
            );
        }

        private void SeedPostgresqlDatabase(EntityTypeBuilder<ProviderInfo> builder)
        {
            builder.HasData(
                new ProviderInfo { Id = 1, Description = "PostgreSQL" }
            );
        }
    }
}
