namespace SimpleCrud.Dtos;

public record CreateDrinkDto(
    string Name,
    string Flavour,
    decimal Price,
    DateOnly ReleaseDate
);