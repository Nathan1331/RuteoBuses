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
    [Route("api/[controller]")]
    [ApiController]
    public class RutasController : ControllerBase
    {
        private readonly RuteoBusesDbcontext _context;

        public RutasController(RuteoBusesDbcontext context)
        {
            _context = context;
        }

        // GET: api/Rutas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ruta>>> Getrutas()
        {
          if (_context.rutas == null)
          {
              return NotFound();
          }
            return await _context.rutas.ToListAsync();
        }

        // GET: api/Rutas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ruta>> GetRuta(int id)
        {
          if (_context.rutas == null)
          {
              return NotFound();
          }
            var ruta = await _context.rutas.FindAsync(id);

            if (ruta == null)
            {
                return NotFound();
            }

            return ruta;
        }

        // PUT: api/Rutas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRuta(int id, Ruta ruta)
        {
            if (id != ruta.rutaId)
            {
                return BadRequest();
            }

            _context.Entry(ruta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RutaExists(id))
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

        // POST: api/Rutas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ruta>> PostRuta(Ruta ruta)
        {
          if (_context.rutas == null)
          {
              return Problem("Entity set 'RuteoBusesDbcontext.rutas'  is null.");
          }
            _context.rutas.Add(ruta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRuta", new { id = ruta.rutaId }, ruta);
        }

        // DELETE: api/Rutas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRuta(int id)
        {
            if (_context.rutas == null)
            {
                return NotFound();
            }
            var ruta = await _context.rutas.FindAsync(id);
            if (ruta == null)
            {
                return NotFound();
            }

            _context.rutas.Remove(ruta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RutaExists(int id)
        {
            return (_context.rutas?.Any(e => e.rutaId == id)).GetValueOrDefault();
        }
    }
}
