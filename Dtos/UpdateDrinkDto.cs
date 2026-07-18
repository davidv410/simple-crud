using System.ComponentModel.DataAnnotations;

namespace SimpleCrud.Dtos;

public record UpdateDrinkDto(
    [Required][StringLength(50)]string Name,
    [Required][StringLength(20)]string Flavour,
    [Range(1, 100)]decimal Price,
    DateOnly ReleaseDate
);