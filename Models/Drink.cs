namespace SimpleCrud.Models;

public class Drink
{
    public int Id  { get; set; }

    public required string Name { get; set; }

    public Flavour? Flavour { get; set; }

    public int FlavourId { get; set; }

    public decimal Price { get; set; }

    public DateOnly ReleaseDate { get; set; }
}