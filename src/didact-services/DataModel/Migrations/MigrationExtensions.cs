using Microsoft.EntityFrameworkCore;

namespace DidactEngine.Services.Extensions
{
    public static class MigrationExtensions
    {
        public static WebApplication MigrateDatabase<T>(this WebApplication webApp)
            where T : DbContext
        {
            using (var scope = webApp.Services.CreateScope())
            using (var dbContext = scope.ServiceProvider.GetRequiredService<T>())
                try
                {
                    dbContext.Database.Migrate();
                }
                catch (Exception e)
                {
                    scope.ServiceProvider
                        .GetRequiredService<ILogger<T>>()
                        .LogError(e, "Unhandled exception while applying migrations for {T}", typeof(T));

                    Console.WriteLine(e);

                    throw;
                }

            return webApp;
        }
    }
}
