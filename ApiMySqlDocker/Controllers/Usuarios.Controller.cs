using ApiMySqlDocker.Config;
using ApiMySqlDocker.DataContext;
using ApiMySqlDocker.Entities;
using BCrypt.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMySqlDocker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public UsuariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var Usuario = await _context.Usuarios.FindAsync(id);

            if (Usuario == null)
            {
                return NotFound();
            }

            return Usuario;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, Usuario Usuario)
        {
            if (id != Usuario.Id)
            {
                return BadRequest();
            }

            _context.Entry(Usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario Usuario)
        {
            _context.Usuarios.Add(new Usuario
            {
                Nome = Usuario.Nome,
                Tipo_Usuario = Usuario.Tipo_Usuario,
                Email = Usuario.Email,
                Senha = BCrypt.Net.BCrypt.HashPassword(Usuario.Senha),
                Status = true
            });
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuario", new { id = Usuario.Id }, Usuario);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var Usuario = await _context.Usuarios.FindAsync(id);
            if (Usuario == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(Usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.Id == id);
        }
    }
}
