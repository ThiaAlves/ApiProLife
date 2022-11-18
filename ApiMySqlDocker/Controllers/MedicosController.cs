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
    public class MedicosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public MedicosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Medicos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Medico>>> GetMedicos()
        {
            return await _context.Medicos.ToListAsync();
        }

        // GET: api/Medicos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Medico>> GetMedico(int id)
        {
            var Medico = await _context.Medicos.FindAsync(id);

            if (Medico == null)
            {
                return NotFound();
            }

            return Medico;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedico(int id, Medico Medico)
        {
            if (id != Medico.Id)
            {
                return BadRequest();
            }

            _context.Entry(Medico).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicoExists(id))
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
        public async Task<ActionResult<Medico>> PostMedico(Medico Medico)
        {
            _context.Medicos.Add(Medico);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMedico", new { id = Medico.Id }, Medico);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedico(int id)
        {
            var Medico = await _context.Medicos.FindAsync(id);
            if (Medico == null)
            {
                return NotFound();
            }

            _context.Medicos.Remove(Medico);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MedicoExists(int id)
        {
            return _context.Medicos.Any(e => e.Id == id);
        }
    }
}
