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
        1,
        "Monster",
        "Ultra",
        2.55M,
        new DateOnly(2015, 2, 12)
    )
];

app.MapGet("/drinks", () => drinks);

app.MapGet("/drinks/{id}", (int id) => drinks.Find(drink => drink.Id == id));

app.Run();
