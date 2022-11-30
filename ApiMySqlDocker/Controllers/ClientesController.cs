using ApiMySqlDocker.Config;
using ApiMySqlDocker.DataContext;
using ApiMySqlDocker.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

            //Descriptografa o CPF
            Cliente.Cpf = Criptografia.AesDecrypt(Cliente.Cpf);
            Cliente.Religiao = Criptografia.AesDecrypt(Cliente.Religiao);

            return Cliente;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, Cliente Cliente)
        {
            if (id != Cliente.Id)
            {
                return BadRequest();
            }
            
            //Atualiza cliente criptografando o CPF e a religião se não for nula
            if (Cliente.Cpf != null)
            {
                Cliente.Cpf = Criptografia.AesEncrypt(Cliente.Cpf);
            }

            if (Cliente.Religiao != null)
            {
                Cliente.Religiao = Criptografia.AesEncrypt(Cliente.Religiao);
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
            _context.Clientes.Add(
                new Cliente
                {
                    Nome = Cliente.Nome,
                    Cpf = Criptografia.AesEncrypt(Cliente.Cpf),
                    Telefone = Cliente.Telefone,
                    Logradouro = Cliente.Logradouro,
                    Cidade = Cliente.Cidade,
                    Estado = Cliente.Estado,
                    Bairro = Cliente.Bairro,
                    Cep = Cliente.Cep,
                    Numero = Cliente.Numero,
                    Tipo_Sanguineo = Cliente.Tipo_Sanguineo,
                    Religiao = Criptografia.AesEncrypt(Cliente.Religiao),
                    Status = Cliente.Status
                }
                );
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
