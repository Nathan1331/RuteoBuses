using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RuteoBusesDAL;

namespace RuteoBusesApi.Controllers
{
    [Route("api/Estados")]
    [ApiController]
    public class EstadosController : ControllerBase
    {
        private readonly RuteoBusesDbcontext _context;

        public EstadosController(RuteoBusesDbcontext context)
        {
            _context = context;
        }

        // GET: api/Estados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estado>>> Getestados()
        {
          if (_context.estados == null)
          {
              return NotFound();
          }
            return await _context.estados.ToListAsync();
        }

        // GET: api/Estados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Estado>> GetEstado(int id)
        {
          if (_context.estados == null)
          {
              return NotFound();
          }
            var estado = await _context.estados.FindAsync(id);

            if (estado == null)
            {
                return NotFound();
            }

            return estado;
        }

        // PUT: api/Estados/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstado(int id, Estado estado)
        {
            if (id != estado.EstadoId)
            {
                return BadRequest();
            }

            _context.Entry(estado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadoExists(id))
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

        // POST: api/Estados
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Estado>> PostEstado(string estado)
        {
          if (_context.estados == null)
          {
              return Problem("Entity set 'RuteoBusesDbcontext.estados'  is null.");
          }
            Estado nuevo = new Estado();
            nuevo.Description = estado;
            _context.estados.Add(nuevo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstado", new { id = nuevo.EstadoId }, nuevo);
        }

        // DELETE: api/Estados/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstado(int id)
        {
            if (_context.estados == null)
            {
                return NotFound();
            }
            var estado = await _context.estados.FindAsync(id);
            if (estado == null)
            {
                return NotFound();
            }

            _context.estados.Remove(estado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EstadoExists(int id)
        {
            return (_context.estados?.Any(e => e.EstadoId == id)).GetValueOrDefault();
        }
    }
}
