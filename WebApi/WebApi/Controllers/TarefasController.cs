using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Tarefas")]
    public class TarefasController : Controller
    {
        private readonly TarefaContext _context;

        public TarefasController(TarefaContext context)
        {
            _context = context;
        }

        // GET: api/Tarefas
        [HttpGet]
        public IEnumerable<Tarefas> GetTarefas()
        {
            return _context.Tarefas;
        }

        // GET: api/Tarefas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTarefas([FromRoute] Guid id)
        {
            var tarefas = await _context.Tarefas.SingleOrDefaultAsync(m => m.Id == id);

            if (tarefas == null)
            {
                return NotFound();
            }

            return Ok(tarefas);
        }

        // PUT: api/Tarefas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTarefas([FromRoute] Guid id, [FromBody] Tarefas tarefas)
        {
           
            if (id != tarefas.Id)
            {
                return BadRequest();
            }

            _context.Entry(tarefas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TarefasExists(id))
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

        // POST: api/Tarefas
        [HttpPost]
        public async Task<IActionResult> PostTarefas([FromBody] Tarefas tarefas)
        {
           
            _context.Tarefas.Add(tarefas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTarefas", new { id = tarefas.Id }, tarefas);
        }

        // DELETE: api/Tarefas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTarefas([FromRoute] Guid id)
        {
           
            var tarefas = await _context.Tarefas.SingleOrDefaultAsync(m => m.Id == id);
            if (tarefas == null)
            {
                return NotFound();
            }

            _context.Tarefas.Remove(tarefas);
            await _context.SaveChangesAsync();

            return Ok(tarefas);
        }

        private bool TarefasExists(Guid id)
        {
            return _context.Tarefas.Any(e => e.Id == id);
        }
    }
}