using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RuteoBusesBL;
using RuteoBusesDAL;

namespace RuteoBusesApi.Controllers
{
    [Route("api/Rols")]
    [ApiController]
    public class RolsController : ControllerBase
    {
        private readonly RolBL _context;

        public RolsController(RuteoBusesDbcontext context)
        {
            _context = new RolBL(context);
        }

        // GET: api/Rols
        [HttpGet]
        public ICollection<Rol> Getroles()
        {
            return _context.listaRoles();

        }

        //// GET: api/Rols/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Rol>> GetRol(int id)
        //{
        //  if (_context.roles == null)
        //  {
        //      return NotFound();
        //  }
        //    var rol = await _context.roles.FindAsync(id);

        //    if (rol == null)
        //    {
        //        return NotFound();
        //    }

        //    return rol;
        //}

        //// PUT: api/Rols/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutRol(int id, Rol rol)
        //{
        //    if (id != rol.rolId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(rol).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!RolExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Rols
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Rol>> PostRol(Rol rol)
        //{
        //  if (_context.roles == null)
        //  {
        //      return Problem("Entity set 'RuteoBusesDbcontext.roles'  is null.");
        //  }
        //    _context.roles.Add(rol);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetRol", new { id = rol.rolId }, rol);
        //}

        //// DELETE: api/Rols/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteRol(int id)
        //{
        //    if (_context.roles == null)
        //    {
        //        return NotFound();
        //    }
        //    var rol = await _context.roles.FindAsync(id);
        //    if (rol == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.roles.Remove(rol);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool RolExists(int id)
        //{
        //    return (_context.roles?.Any(e => e.rolId == id)).GetValueOrDefault();
        //}
    }
}
