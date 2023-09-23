using DBChoose.DataAccess.Ef;

namespace DBChoose.Middlewares
{
    public class DatabaseProviderValidationMiddleware
    {
        private readonly RequestDelegate _next;

        public DatabaseProviderValidationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string databaseProvider = Environment.GetEnvironmentVariable("DATABASE_PROVIDER")!;

            if (databaseProvider == null)
            {
                await context.Response.WriteAsync("Empty database provider.");
                return;
            }

            if (databaseProvider != DbProviders.Sql && databaseProvider != DbProviders.PostgreSql)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync("Invalid database provider.");
                return;
            }

            await _next(context);
        }
    }

}