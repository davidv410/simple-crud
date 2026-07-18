using SimpleCrud.Dtos;
namespace SimpleCrud.Endpoints;

public static class DrinksEndpoints
{
    private static readonly List<DrinkDto> drinks = [
        new(
            1,
            "Monster",
            "Mango Loco",
            2.55M,
            new DateOnly(2024, 2, 29)
        ),
        new(
            2,
            "Monster",
            "Ultra",
            2.55M,
            new DateOnly(2015, 2, 12)
        )
    ];

    public static void MapDrinksEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/drinks");

        group.MapGet("/", () => drinks);

        group.MapGet("/{id}", (int id) =>
        {
            var game = drinks.Find(drink => drink.Id == id);

            return game is null ? Results.NotFound() : Results.Ok(game);
        });

        group.MapPost("/", (CreateDrinkDto newDrink) =>
        {
            DrinkDto drink = new(
                drinks.Count + 1,
                newDrink.Name,
                newDrink.Flavour,
                newDrink.Price,
                newDrink.ReleaseDate
            );

            drinks.Add(drink);

            return Results.Ok(drink);
        });

        group.MapPut("/{id}", (int id, UpdateDrinkDto updateDrink) =>
        {
            var index = drinks.FindIndex(drink => drink.Id == id);

            if(index == -1)
            {
                return Results.NotFound();
            }
            
            drinks[index] = new DrinkDto(
                id,
                updateDrink.Name,
                updateDrink.Flavour,
                updateDrink.Price,
                updateDrink.ReleaseDate
            );

            return Results.NoContent();
        });

        group.MapDelete("/{id}", (int id) =>
        {
            drinks.RemoveAll(drink => drink.Id == id);

            return Results.NoContent();
        });
    }
}