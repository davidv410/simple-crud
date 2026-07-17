using SimpleCrud.Dtos;
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<DrinkDto> drinks = [
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

app.MapGet("/drinks", () => drinks);

app.MapGet("/drinks/{id}", (int id) => drinks.Find(drink => drink.Id == id));

app.MapPost("/drinks", (CreateDrinkDto newDrink) =>
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

app.MapPut("/drinks/{id}", (int id, UpdateDrinkDto updateDrink) =>
{
    var index = drinks.FindIndex(drink => drink.Id == id);
    
    drinks[index] = new DrinkDto(
        id,
        updateDrink.Name,
        updateDrink.Flavour,
        updateDrink.Price,
        updateDrink.ReleaseDate
    );

    return Results.NoContent();
});

app.MapDelete("/drinks/{id}", (int id) =>
{
    drinks.RemoveAll(drink => drink.Id == id);

    return Results.NoContent();
});

app.Run();
