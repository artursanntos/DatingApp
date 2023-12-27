using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API.Entities;
using API.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace API.Services;

public class TokenService : ITokenService
{

    private readonly SymmetricSecurityKey _key; // o key é a chave que vai ser usada para criptografar o token

    public TokenService(IConfiguration config)
    {
        _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"])); // o tokenKey é a chave que vai ser usada para criptografar o token
    }

    public string CreateToken(AppUser user)
    {
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.NameId, user.UserName) // o nameId é o nome do usuário
        };

        var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature); // o creds é a chave que vai ser usada para assinar o token

        var tokenDescriptor = new SecurityTokenDescriptor // o tokenDescriptor é a descrição do token
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddDays(7),
            SigningCredentials = creds
        };

        var tokenHandler = new JwtSecurityTokenHandler(); // o tokenHandler é o manipulador do token

        var token = tokenHandler.CreateToken(tokenDescriptor); // o token é criado com base no tokenDescriptor

        return tokenHandler.WriteToken(token); // o token é retornado
    }
}
