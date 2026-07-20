using System.ComponentModel.DataAnnotations;

namespace SimpleCrud.Dtos;

public record UpdateDrinkDto(
    [Required][StringLength(50)]string Name,
    [Range(1, 50)]int FlavourId,
    [Range(1, 100)]decimal Price,
    DateOnly ReleaseDate
);