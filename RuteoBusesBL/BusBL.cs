using Microsoft.EntityFrameworkCore;
using RuteoBusesDAL;
using RuteoBusesDAL.CrudsDAL;

namespace RuteoBusesBL
{
    public class BusBl
    {
        #region variables
        private BusDAL busDAL;
        #endregion
        public BusBl(RuteoBusesDbcontext context)
        {
            busDAL = new BusDAL(context);
                
        }


        #region CRUD
        public ICollection<Bus> listaBuses() 
        {
            return busDAL.ListaBuses();
        }
        public bool AgregarBus(Bus bus) 
        {
            if(bus != null && busDAL.BuscarBusEnt(bus)==null) 
            {
                busDAL.AgregarBus(bus);
                return true;
            }

            return false;
        }
        public Bus? BuscarBusId(int id) 
        {
            if (busDAL.ListaBuses == null)
            {
                return null;
            }
            return busDAL.BuscarBusId(id);
        }
        public bool ModificarBus(int id, Bus bus) 
        {
            if(busDAL.BuscarBusId(id)!=null && bus!= null) 
            {
                return busDAL.ModificarBus(id, bus);
            }
            return false;
        }

        public bool EliminarBus(int id) 
        {
            if (busDAL.BuscarBusId(id)!= null) 
            {
               busDAL.EliminarBus(id);
                return true;
            }
                return false;
        }
        #endregion
    }
}