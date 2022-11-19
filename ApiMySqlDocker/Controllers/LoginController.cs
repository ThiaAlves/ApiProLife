using ApiMySqlDocker.DataContext;
using ApiMySqlDocker.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Linq;
using System.Security.Claims;

namespace ApiMySqlDocker.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _config;

        private readonly ApplicationDbContext _context;

        public LoginController(IConfiguration config, ApplicationDbContext context)
        {
            _config = config;
            _context = context;
        }


        [HttpPost]
        public IActionResult Login([FromBody] Usuario usuario)
        {
           
            var user = _context.Usuarios.Where(x => x.Email == usuario.Email).FirstOrDefault();
            

            //BCrypt.Net.BCrypt.Verify(senha, x.Senha)
            //var user = UsuarioRepository.Get(usuario.Email ,usuario.Senha);
            //var user = Usuario.Where(x => x.Email == email).FirstOrDefault();
            if (user == null)
            {
                return NotFound(new { message = "Usuário ou senha inválidos" });
            }

            if (BCrypt.Net.BCrypt.Verify(usuario.Senha, user.Senha) == true)
            {
                // return Ok(new { token = GerarToken() });
                return Ok(new
                {
                    token = GenerateToken(user)
                });
            }

               return NotFound(new { message = "Usuário ou senha inválidos" });
        }

        private string GerarToken()
        {
            var expiry = DateTime.Now.AddHours(1);
            var issuer = _config["Jwt:Issuer"];
            var audience = _config["Jwt:Audience"];
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config["Jwt:Key"])
            );
            var credentials = new SigningCredentials(
                key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(issuer: issuer, audience: audience,
                expires: expiry, signingCredentials: credentials);

            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(token);
        }

        public static string GenerateToken(Usuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.Email.ToString()),
                    new Claim(ClaimTypes.Role, usuario.Tipo_Usuario.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


    }
}
