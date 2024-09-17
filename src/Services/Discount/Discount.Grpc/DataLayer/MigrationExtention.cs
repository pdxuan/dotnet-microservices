using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.DataLayer
{
    public static class MigrationExtention
    {
        public static IApplicationBuilder UseMigration(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            using var dbContext = scope.ServiceProvider.GetRequiredService<DiscountContext>();
            dbContext.Database.MigrateAsync();

            return app;
        }
    }
}
