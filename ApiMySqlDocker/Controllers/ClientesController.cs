using ApiMySqlDocker.DataContext;
using ApiMySqlDocker.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMySqlDocker.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ClientesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            return await _context.Clientes.ToListAsync();
        }

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            var Cliente = await _context.Clientes.FindAsync(id);

            if (Cliente == null)
            {
                return NotFound();
            }

            return Cliente;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, Cliente Cliente)
        {
            if (id != Cliente.Id)
            {
                return BadRequest();
            }

            _context.Entry(Cliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(id))
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
        public async Task<ActionResult<Cliente>> PostCliente(Cliente Cliente)
        {
            _context.Clientes.Add(Cliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCliente", new { id = Cliente.Id }, Cliente);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var Cliente = await _context.Clientes.FindAsync(id);
            if (Cliente == null)
            {
                return NotFound();
            }

            _context.Clientes.Remove(Cliente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClienteExists(int id)
        {
            return _context.Clientes.Any(e => e.Id == id);
        }
    }
}
