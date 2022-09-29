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
    [Route("api/ParadaRutas")]
    [ApiController]
    public class ParadaRutasController : ControllerBase
    {
        private readonly ParadaRutaBL _ParadaRutaBL;

        public ParadaRutasController(RuteoBusesDbcontext context)
        {
            _ParadaRutaBL = new ParadaRutaBL(context);
        }

        // GET: api/ParadaRutas
        [HttpGet]
        public ICollection<ParadaRuta> Getparadarutas()
        {
            return _ParadaRutaBL.listaParadaRuta();
        }

        // GET: api/ParadaRutas/5
        [HttpGet("{id}")]
        public ParadaRuta? GetParadaRuta(int id)
        {
          return _ParadaRutaBL.BuscarParadaRutaId(id);
        }

        // PUT: api/ParadaRutas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public bool ModificarParadaRuta(int id, ParadaRuta paradaRuta)
        {
            return _ParadaRutaBL.ModificarParadaRuta(id, paradaRuta);
        }

        // POST: api/ParadaRutas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public bool AgregarParadaRuta(ParadaRuta paradaRuta)
        {
            return _ParadaRutaBL.AgregarParadaRuta(paradaRuta);
        }

        // DELETE: api/ParadaRutas/5
        [HttpDelete("{id}")]
        public bool EliminarParadaRuta(int id)
        {
            return _ParadaRutaBL.EliminarBus(id);
        }
    }
}
