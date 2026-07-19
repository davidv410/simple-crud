using Microsoft.EntityFrameworkCore;

namespace SimpleCrud.Data;


public static class DataExtensions
{
    public static void MigrateDb(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<DrinksContext>();
        dbContext.Database.Migrate();
    }
}