using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuteoBusesDAL.CrudsDAL
{
    public class BusDAL
    {
        private RuteoBusesDbcontext RuteoDbcontextAccess;
        public BusDAL( RuteoBusesDbcontext dbcontext)
        {
            RuteoDbcontextAccess = dbcontext;
        }

        #region CRUD

        public ICollection<Bus> ListaBuses() 
        {
            return RuteoDbcontextAccess.buses.ToList();
        }
        public void AgregarBus(Bus bus) 
        {
            RuteoDbcontextAccess.buses.Add(bus);
            RuteoDbcontextAccess.SaveChanges();
        }
        public void EliminarBus(int Id)
        {
            Bus bus=BuscarBusId(Id);
            RuteoDbcontextAccess.buses.Remove(bus);
            RuteoDbcontextAccess.SaveChanges();
        }
        public bool ModificarBus(int id,Bus bus)
        {
            if (bus != null) 
            {
                Bus modificar=BuscarBusId(id);
                modificar.rutaId=bus.rutaId;
                modificar.busId=bus.busId;
                modificar.choferId=bus.choferId;
                modificar.estadoId=bus.estadoId;                
                RuteoDbcontextAccess.SaveChanges();

                return true;
            }
            return false;
        }
        public Bus? BuscarBusId(int id) 
        {
            return RuteoDbcontextAccess.buses.Find(id) ;
        }
        public Bus? BuscarBusEnt(Bus bus)
        {
            var buscar = RuteoDbcontextAccess.buses.Find(bus);
            return buscar;
        }

        #endregion
    }
}
