using SimpleCrud.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidation();

var app = builder.Build();

app.MapDrinksEndpoints();

app.Run();