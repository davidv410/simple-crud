namespace SimpleCrud.Dtos;

public record UpdateDrinkDto(
    string Name,
    string Flavour,
    decimal Price,
    DateOnly ReleaseDate
);