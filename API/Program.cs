using System.Globalization;
using API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Explain the following:
// - AddDbContext is an extension method that adds a DbContext to the service container.
// - The DbContextOptions parameter is used to configure the context.
// - The UseSqlServer method configures the context to use SQL Server.
// - The GetConnectionString method gets the connection string from the appsettings.json file.
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers(); // o mapControllers serve para mapear os controllers que estão na pasta Controllers

app.Run();