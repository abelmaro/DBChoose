using DBChoose.DataAccess.Ef;
using Microsoft.EntityFrameworkCore;

namespace DBChoose.Ef.Extensions
{
    public static class DbContextExtension
    {
        public static void AddDataContext(this WebApplicationBuilder builder)
        {
            var databaseProvider = Environment.GetEnvironmentVariable("DATABASE_PROVIDER");

            builder.Services.AddDbContext<DBChooseContext>(
                options => _ = databaseProvider switch
                {
                    DbProviders.PostgreSql => options.UseNpgsql(
                        builder.Configuration.GetConnectionString("DataContextPostgreSql"),
                        x => x.MigrationsAssembly("DBChoose.Migrations.PostgreSQL")),

                    DbProviders.Sql => options.UseSqlServer(
                        builder.Configuration.GetConnectionString("DataContextSql")!,
                        x => x.MigrationsAssembly("DBChoose.Migrations.SQL")),

                    _ => throw new NotSupportedException($"Database provider without configuration: {databaseProvider}")
                }).AddOptions();
        }

    }
}
