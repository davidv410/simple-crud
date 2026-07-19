using SimpleCrud.Data;
using SimpleCrud.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidation();

var connString = "Data Source=Drinks.db";
builder.Services.AddSqlite<DrinksContext>(connString);

var app = builder.Build();

app.MapDrinksEndpoints();

app.MigrateDb();

app.Run();