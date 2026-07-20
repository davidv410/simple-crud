namespace SimpleCrud.Dtos;

public record DrinkSummaryDto(
    int Id,
    string Name,
    string Flavour,
    decimal Price,
    DateOnly ReleaseDate
);