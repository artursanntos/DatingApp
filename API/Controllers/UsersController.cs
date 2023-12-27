using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[Authorize] // só usuários autorizados podem acessar essa controller
public class UsersController : BaseApiController
{
    private readonly DataContext _context; // convenção para nomear variáveis privadas: _nomeDaVariavel

    public UsersController(DataContext context)
    {
        _context = context;
    }

    [AllowAnonymous] // usuários não autorizados podem acessar esse método
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
