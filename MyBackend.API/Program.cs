using schoolProject.WebApi.Repositories;
using Microsoft.Identity.Client;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.Configure<RouteOptions>(o => o.LowercaseUrls = true);

var sqlConnectionString = builder.Configuration["SqlConnectionString"];
var sqlConnectionStringFound = !string.IsNullOrEmpty(sqlConnectionString);


//if (string.IsNullOrWhiteSpace(sqlConnectionString))
//    throw new InvalidProgramException("Configuration variable SqlConnectionString not found");



// Environment2D
// Object2D

builder.Services.AddTransient<UserRepository, UserRepository>(o => new UserRepository(sqlConnectionString));
var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapOpenApi();

app.MapGet("/", () => $"WebApi is up 🚀. Connectionstring found: {(sqlConnectionStringFound ? "✅" : "❌")}");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
