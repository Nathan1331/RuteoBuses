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
    [Route("api/Choferes")]
    [ApiController]
    public class ChoferesController : ControllerBase
    {
        private readonly RuteoBusesDbcontext _context;

        public ChoferesController(RuteoBusesDbcontext context)
        {
            _context = context;
        }

        // GET: api/Choferes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Chofer>>> Getchoferes()
        {
          if (_context.choferes == null)
          {
              return NotFound();
          }
            return await _context.choferes.ToListAsync();
        }

        // GET: api/Chofers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Chofer>> GetChofer(int id)
        {
          if (_context.choferes == null)
          {
              return NotFound();
          }
            var chofer = await _context.choferes.FindAsync(id);

            if (chofer == null)
            {
                return NotFound();
            }

            return chofer;
        }

        // PUT: api/Chofers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChofer(int id, Chofer chofer)
        {
            if (id != chofer.choferId)
            {
                return BadRequest();
            }

            _context.Entry(chofer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChoferExists(id))
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

        // POST: api/Chofers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Chofer>> PostChofer(Chofer chofer)
        {
          if (_context.choferes == null)
          {
              return Problem("Entity set 'RuteoBusesDbcontext.choferes'  is null.");
          }
            _context.choferes.Add(chofer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChofer", new { id = chofer.choferId }, chofer);
        }

        // DELETE: api/Chofers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChofer(int id)
        {
            if (_context.choferes == null)
            {
                return NotFound();
            }
            var chofer = await _context.choferes.FindAsync(id);
            if (chofer == null)
            {
                return NotFound();
            }

            _context.choferes.Remove(chofer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChoferExists(int id)
        {
            return (_context.choferes?.Any(e => e.choferId == id)).GetValueOrDefault();
        }
    }
}
