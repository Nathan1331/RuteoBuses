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
    public class ParadaRutasController : ControllerBase
    {
        private readonly RuteoBusesDbcontext _context;

        public ParadaRutasController(RuteoBusesDbcontext context)
        {
            _context = context;
        }

        // GET: api/ParadaRutas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParadaRuta>>> Getparadarutas()
        {
          if (_context.paradarutas == null)
          {
              return NotFound();
          }
            return await _context.paradarutas.ToListAsync();
        }

        // GET: api/ParadaRutas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ParadaRuta>> GetParadaRuta(int id)
        {
          if (_context.paradarutas == null)
          {
              return NotFound();
          }
            var paradaRuta = await _context.paradarutas.FindAsync(id);

            if (paradaRuta == null)
            {
                return NotFound();
            }

            return paradaRuta;
        }

        // PUT: api/ParadaRutas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParadaRuta(int id, ParadaRuta paradaRuta)
        {
            if (id != paradaRuta.paradaRutaId)
            {
                return BadRequest();
            }

            _context.Entry(paradaRuta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParadaRutaExists(id))
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

        // POST: api/ParadaRutas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ParadaRuta>> PostParadaRuta(ParadaRuta paradaRuta)
        {
          if (_context.paradarutas == null)
          {
              return Problem("Entity set 'RuteoBusesDbcontext.paradarutas'  is null.");
          }
            _context.paradarutas.Add(paradaRuta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParadaRuta", new { id = paradaRuta.paradaRutaId }, paradaRuta);
        }

        // DELETE: api/ParadaRutas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParadaRuta(int id)
        {
            if (_context.paradarutas == null)
            {
                return NotFound();
            }
            var paradaRuta = await _context.paradarutas.FindAsync(id);
            if (paradaRuta == null)
            {
                return NotFound();
            }

            _context.paradarutas.Remove(paradaRuta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ParadaRutaExists(int id)
        {
            return (_context.paradarutas?.Any(e => e.paradaRutaId == id)).GetValueOrDefault();
        }
    }
}
