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
    public class AtendimentosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public AtendimentosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Atendimentos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Atendimento>>> GetAtendimentos()
        {

            //Retorna atendimentos com inner join cliente e médico
            return await _context.Atendimentos
                .Include(a => a.Cliente)
                .Include(a => a.Clinica)
                .ToListAsync();

            //return await _context.Atendimentos.ToListAsync();
        }
        
        // GET: api/Atendimentos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Atendimento>> GetAtendimento(int id)
        {
            var Atendimento = await _context.Atendimentos.FindAsync(id);

            if (Atendimento == null)
            {
                return NotFound();
            }

            return Atendimento;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAtendimento(int id, Atendimento Atendimento)
        {
            if (id != Atendimento.Id)
            {
                return BadRequest();
            }

            _context.Entry(Atendimento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AtendimentoExists(id))
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
        public async Task<ActionResult<Atendimento>> PostAtendimento(Atendimento Atendimento)
        {
            _context.Atendimentos.Add(Atendimento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAtendimento", new { id = Atendimento.Id }, Atendimento);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAtendimento(int id)
        {
            var Atendimento = await _context.Atendimentos.FindAsync(id);
            if (Atendimento == null)
            {
                return NotFound();
            }

            _context.Atendimentos.Remove(Atendimento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //Rota atendimentos por Clínica
        [HttpGet("GetAtendimentosByClinica/{id}")]
        public async Task<ActionResult<IEnumerable<Atendimento>>> GetAtendimentosPorClinica(int id)
        {
            return await _context.Atendimentos
                .Include(a => a.Cliente)
                .Include(a => a.Clinica)
                .Where(a => a.ClinicaId == id)
                .ToListAsync();
        }

        private bool AtendimentoExists(int id)
        {
            return _context.Atendimentos.Any(e => e.Id == id);
        }
    }
}
