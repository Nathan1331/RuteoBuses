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
    [Route("api/Choferes")]
    [ApiController]
    public class ChoferesController : ControllerBase
    {
        private readonly ChoferBL _choferBL;

        public ChoferesController(RuteoBusesDbcontext context)
        {
            _choferBL = new ChoferBL(context);
        }

        // GET: api/Choferes
        [HttpGet]
        public ICollection<Chofer> Getchoferes()
        {
          if (_choferBL.listaChoferes() == null)
          {
              return null;
          }
            return _choferBL.listaChoferes();
        }

        // GET: api/Chofers/5
        [HttpGet("{id}")]
        public Chofer GetChofer(int id)
        {
          if (_choferBL.listaChoferes == null)
          {
              return null;
          }
            var chofer = _choferBL.BuscarChoferId(id);

            if (chofer == null)
            {
                return null;
            }

            return chofer;
        }

        // PUT: api/Chofers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public bool ModificarChofer(int id, Chofer chofer)
        {
           return _choferBL.ModificarChofer(id,chofer);
        }

        // POST: api/Chofers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public bool AgregarChofer(Chofer chofer)
        {
            return _choferBL.AgregarChofer(chofer);
        }

        // DELETE: api/Chofers/5
        [HttpDelete("{id}")]
        public bool EliminarChofer(int id)
        {
            return _choferBL.EliminarChofer(id);
        }

        
    }
}
