namespace API.Helpers
{
    using Data;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Migrate Database with the Context and Data changes
    /// </summary>
    public static class MigrateDatabase
    {
        public static void UpdateDatabase(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<DataContext>())
                {
                    context.Database.Migrate();
                    DbInitializer.InitializeDatabase(context);
                }
            }
        }
    }
}