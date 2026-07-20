using SimpleCrud.Models;
using Microsoft.EntityFrameworkCore;

namespace SimpleCrud.Data;

public class DrinksContext(DbContextOptions<DrinksContext> options) : DbContext(options)
{
    public DbSet<Drink> Drinks => Set<Drink>();

    public DbSet<Flavour> Flavours => Set<Flavour>();
}