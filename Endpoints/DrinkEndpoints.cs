using Microsoft.EntityFrameworkCore;
using SimpleCrud.Data;
using SimpleCrud.Dtos;
using SimpleCrud.Models;
namespace SimpleCrud.Endpoints;

public static class DrinksEndpoints
{
    public static void MapDrinksEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/drinks");

        group.MapGet("/", async (DrinksContext dbContext) 
        => await dbContext.Drinks
        .Include(drink => drink.Flavour)
        .Select(drink => new DrinkSummaryDto(
            drink.Id,
            drink.Name,
            drink.Flavour!.Name,
            drink.Price,
            drink.ReleaseDate
        ))
        .AsNoTracking()
        .ToListAsync());

        group.MapGet("/{id}", async (int id, DrinksContext dbContext) =>
        {
            var drink = await dbContext.Drinks.FindAsync(id);

            return drink is null ? Results.NotFound() : Results.Ok(
                new DrinkDetailsDto(
                    drink.Id,
                    drink.Name,
                    drink.FlavourId,
                    drink.Price,
                    drink.ReleaseDate
                )
            );
        });

        group.MapPost("/", async (CreateDrinkDto newDrink, DrinksContext dbContext) =>
        {
            Drink drink = new()
            {
                Name = newDrink.Name,
                FlavourId = newDrink.FlavourId,
                Price = newDrink.Price,
                ReleaseDate = newDrink.ReleaseDate
            };

            dbContext.Drinks.Add(drink);
            await dbContext.SaveChangesAsync();

            DrinkDetailsDto drinkDto = new(
                drink.Id,
                drink.Name,
                drink.FlavourId,
                drink.Price,
                drink.ReleaseDate
            );

            return Results.Ok(drinkDto);
        });

        group.MapPut("/{id}", async (int id, UpdateDrinkDto updateDrink, DrinksContext dbContext) =>
        {
            var existingGame = await dbContext.Drinks.FindAsync(id);

            if(existingGame is null)
            {
                return Results.NotFound();
            }
            
            existingGame.Name = updateDrink.Name;
            existingGame.FlavourId = updateDrink.FlavourId;
            existingGame.Price = updateDrink.Price;
            existingGame.ReleaseDate = updateDrink.ReleaseDate;

            await  dbContext.SaveChangesAsync();

            return Results.NoContent();
        });

        group.MapDelete("/{id}", async (int id, DrinksContext dbContext) =>
        {
            await dbContext.Drinks.Where(drink => drink.Id == id).ExecuteDeleteAsync();

            return Results.NoContent();
        });
    }
}