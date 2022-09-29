using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RuteoBusesBL;
using RuteoBusesDAL;
using RuteoBusesDAL.CrudsDAL;

namespace RuteoBusesApi.Controllers
{
    [Route("api/Estados")]
    [ApiController]
    public class EstadosController : ControllerBase
    {
        private readonly EstadoBL _estadoBL;

        public EstadosController(RuteoBusesDbcontext context)
        {
            _estadoBL = new EstadoBL(context);
        }

        // GET: api/Estados
        [HttpGet]
        public ICollection<Estado> ListaEstados()
        {
          if (_estadoBL.ListaEstados() == null)
          {
              return null;
          }
            return _estadoBL.ListaEstados();
        }

        // GET: api/Estados/5
        [HttpGet("{id}")]
        public Estado GetEstado(int id)
        {
          if (_estadoBL.ListaEstados() == null)
          {
                return null;
          }
            var estado = _estadoBL.BuscarEstadoId(id);

            if (estado == null)
            {
                return null;
            }

            return estado;
        }

        // PUT: api/Estados/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public bool ModificarEstado(int id, Estado estado)
        {
           return _estadoBL.ModificarEstado(id,estado);
        }

        // POST: api/Estados
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public bool AgregarEstado(Estado estado)
        {
          return _estadoBL.AgregarEstado(estado);
        }

        // DELETE: api/Estados/5
        [HttpDelete("{id}")]
        public bool EliminarEstado(int id)
        {
            return _estadoBL.EliminarEstado(id);
        }

        
    }
}
