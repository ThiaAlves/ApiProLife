using ApiMySqlDocker.DataContext;
using ApiMySqlDocker.Entities;
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
    public class ClinicasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ClinicasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Clinicas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Clinica>>> GetClinicas()
        {
            return await _context.Clinicas.ToListAsync();
        }

        // GET: api/Clinicas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Clinica>> GetClinica(int id)
        {
            var Clinica = await _context.Clinicas.FindAsync(id);

            if (Clinica == null)
            {
                return NotFound();
            }

            return Clinica;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutClinica(int id, Clinica Clinica)
        {
            if (id != Clinica.Id)
            {
                return BadRequest();
            }

            _context.Entry(Clinica).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClinicaExists(id))
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
        public async Task<ActionResult<Clinica>> PostClinica(Clinica Clinica)
        {
            _context.Clinicas.Add(Clinica);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClinica", new { id = Clinica.Id }, Clinica);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClinica(int id)
        {
            var Clinica = await _context.Clinicas.FindAsync(id);
            if (Clinica == null)
            {
                return NotFound();
            }

            _context.Clinicas.Remove(Clinica);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClinicaExists(int id)
        {
            return _context.Clinicas.Any(e => e.Id == id);
        }
    }
}
