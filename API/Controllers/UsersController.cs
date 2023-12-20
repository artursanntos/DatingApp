using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")] // esse [controller] usa o nome do controller para criar a rota ("Users")
public class UsersController : ControllerBase
{
    private readonly DataContext _context; // convenção para nomear variáveis privadas: _nomeDaVariavel

    public UsersController(DataContext context)
    {
        _context = context;
    }

    [HttpGet] // api/users
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        var users = await _context.Users.ToListAsync(); // ToListAsync() é um método assíncrono, por isso o await é necessário

        return users;
    }

    [HttpGet("{id}")] // api/users/3
    public async Task<ActionResult<AppUser>> GetUser(int id)
    {
        return await _context.Users.FindAsync(id); // Find() procura pelo id
    }
}
