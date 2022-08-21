using System;
using System.Collections;
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
    [Route("api/Buses")]
    [ApiController]
    public class BusesController : ControllerBase
    {
        private readonly BusBl _busBL;

        public BusesController(RuteoBusesDbcontext context)
        {
            _busBL = new BusBl(context);
        }

        // GET: api/Buses
        [HttpGet]
        public ICollection<Bus> Getbuses()
        {
          if (_busBL.listaBuses == null)
          {
              return null;
          }

            return  _busBL.listaBuses();
        }

        // GET: api/Buses/5
        [HttpGet("{id}")]
        public Bus? BuscarBusId(int id)
        {
            return _busBL.BuscarBusId(id);
        }

        // PUT: api/Buses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public bool ModificarBus(int id, Bus bus)
        {
            return _busBL.ModificarBus(id, bus);
        }

        // POST: api/Buses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public bool AgregarBus(Bus bus)
        {
            return _busBL.AgregarBus(bus);
        }

        // DELETE: api/Buses/5
        [HttpDelete("{id}")]
        public bool DeleteBus(int id)
        {
            return _busBL.EliminarBus(id);
        }

        
    }
}
