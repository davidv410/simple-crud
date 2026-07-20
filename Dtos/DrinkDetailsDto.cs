namespace SimpleCrud.Dtos;

public record DrinkDetailsDto(
    int Id,
    string Name,
    int Flavourid,
    decimal Price,
    DateOnly ReleaseDate
);