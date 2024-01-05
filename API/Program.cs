using API.Data;
using API.Extensions;
using API.Middleware;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddApplicationServices(builder.Configuration); // o addApplicationServices serve para adicionar os serviços que estão na pasta Extensions
builder.Services.AddIdentityServices(builder.Configuration); // o addIdentityServices serve para adicionar os serviços de autenticação que estão na pasta Extensions

var app = builder.Build();
app.UseMiddleware<ExceptionMiddleware>(); // o useMiddleware serve para adicionar o middleware que está na pasta Middleware

app.UseHttpsRedirection();

// Configure the HTTP request pipeline.
app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200")); 
// o cors serve para permitir que o angular acesse a api

app.UseAuthentication(); // o authentication serve para autenticar o usuário
app.UseAuthorization(); // o authorization serve para autorizar o usuário

app.MapControllers(); // o mapControllers serve para mapear os controllers que estão na pasta Controllers

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
/*try {
    var context = services.GetRequiredService<DataContext>();
    await context.Database.MigrateAsync(); // o migrateAsync serve para aplicar migrações não realizadas ou mesmo criar o banco de dados
    await Seed.SendUsers(context); // o sendUsers serve para enviar os usuários para o banco de dados
} catch (Exception ex) {
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occurred during migration");
}*/

app.Run();