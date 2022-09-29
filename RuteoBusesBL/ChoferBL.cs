using Microsoft.EntityFrameworkCore;
using RuteoBusesDAL;
using RuteoBusesDAL.CrudsDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuteoBusesBL
{
    public class ChoferBL
    {
        private readonly ChoferDAL _choferDAL;
        public ChoferBL(RuteoBusesDbcontext context)
        {
            _choferDAL = new ChoferDAL(context);

        }
        #region CRUD
        public ICollection<Chofer> listaChoferes()
        {
            return _choferDAL.ListaChoferes();
        }
        public bool AgregarChofer(Chofer chofer)
        {
            if (chofer != null && _choferDAL.BuscarChoferEnt(chofer) == null)
            {
                _choferDAL.AgregarChofer(chofer);
                return true;
            }

            return false;
        }
        public Chofer? BuscarChoferId(int id)
        {
            if (_choferDAL.ListaChoferes == null)
            {
                return null;
            }
            return _choferDAL.BuscarChoferId(id);
        }
        public bool ModificarChofer(int id, Chofer chofer)
        {
            if (_choferDAL.BuscarChoferId(id) != null && chofer != null)
            {
                return _choferDAL.ModificarChofer(id, chofer);
            }
            return false;
        }

        public bool EliminarChofer(int id)
        {
            if (_choferDAL.BuscarChoferId(id) != null)
            {
                _choferDAL.EliminarChofer(id);
                return true;
            }
            return false;
        }
        #endregion


    }
}
