namespace SimpleCrud.Dtos;

public record DrinkDto(
    int Id,
    string Name,
    string Flavour,
    decimal Price,
    DateOnly ReleaseDate
);