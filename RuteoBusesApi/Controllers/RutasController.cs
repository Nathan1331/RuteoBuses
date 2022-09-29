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
    [Route("api/Rutas")]
    [ApiController]
    public class RutasController : ControllerBase
    {
        private readonly RutaBL _rutaBL;

        public RutasController(RuteoBusesDbcontext context)
        {
            _rutaBL = new RutaBL(context);
        }

        // GET: api/Rutas
        [HttpGet]
        public ICollection<Ruta> Getrutas()
        {
            return _rutaBL.listaRuta(); 
        }

        // GET: api/Rutas/5
        [HttpGet("{id}")]
        public Ruta? GetRuta(int id)
        {
            return _rutaBL.BuscarRutaId(id);
        }

        // PUT: api/Rutas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public bool ModificarRuta(int id, Ruta ruta)
        {
            return _rutaBL.ModificarRuta(id, ruta);   
        }

        // POST: api/Rutas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public bool AgregarRuta(Ruta ruta)
        {
          return  _rutaBL.AgregarRuta(ruta);

        }

        // DELETE: api/Rutas/5
        [HttpDelete("{id}")]
        public bool DeleteRuta(int id)
        {
            return _rutaBL.EliminarRuta(id);
        }
    }
}
