using Microsoft.EntityFrameworkCore;
using SimpleCrud.Models;

namespace SimpleCrud.Data;


public static class DataExtensions
{
    public static void MigrateDb(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<DrinksContext>();
        dbContext.Database.Migrate();
    }

    public static void AddDrinksDb(this WebApplicationBuilder builder)
    {
        var connString = "Data Source=Drinks.db";
        builder.Services.AddSqlite<DrinksContext>(
            connString,
            optionsAction: options => options.UseSeeding((context, _) =>
            {
                if (!context.Set<Flavour>().Any())
                {
                    context.Set<Flavour>().AddRange(
                        new Flavour { Name = "Orange" },
                        new Flavour { Name = "Mango" },
                        new Flavour { Name = "Watermelon" },
                        new Flavour { Name = "Cola" },
                        new Flavour { Name = "Ultra" }
                    );

                    context.SaveChanges();
                };
            })
        );
    }
}