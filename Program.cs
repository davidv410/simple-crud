using SimpleCrud.Data;
using SimpleCrud.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidation();
builder.AddDrinksDb();

var app = builder.Build();

app.MapDrinksEndpoints();

app.MigrateDb();

app.Run();