using API.Extensions;
using API.Middleware;

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

app.Run();