using Microsoft.EntityFrameworkCore;
using SimpleCrud.Data;
using SimpleCrud.Dtos;
using SimpleCrud.Models;

namespace SimpleCrud.Endpoints;

public static class FlavoursEndpoints
{
    public static void MapFlavoursEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/flavours");

        group.MapGet("/", async (DrinksContext dbContext) => 
        await dbContext.Flavours.Select(flavour => new FlavourDto(flavour.Id, flavour.Name)).AsNoTracking().ToListAsync()
        );
    }
}