using Microsoft.EntityFrameworkCore;

namespace DiscountGrpc.DataLayer
{
    public static class DiscountExtention
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
