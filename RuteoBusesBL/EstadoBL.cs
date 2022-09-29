using RuteoBusesDAL.CrudsDAL;
using RuteoBusesDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuteoBusesBL
{
    public class EstadoBL
    {
        private readonly EstadoDAL _estadoDAL;
        public EstadoBL(RuteoBusesDbcontext context)
        {
            _estadoDAL = new EstadoDAL(context);

        }
        #region CRUD
        public ICollection<Estado> ListaEstados()
        {
            return _estadoDAL.ListaEstados();
        }
        public bool AgregarEstado(Estado estado)
        {
            if (estado != null && _estadoDAL.BuscarEstadoEnt(estado) == null)
            {
                _estadoDAL.AgregarEstado(estado);
                return true;
            }

            return false;
        }
        public Estado? BuscarEstadoId(int id)
        {
            if (_estadoDAL.ListaEstados == null)
            {
                return null;
            }
            return _estadoDAL.BuscarEstadoId(id);
        }
        public bool ModificarEstado(int id, Estado estado)
        {
            if (_estadoDAL.BuscarEstadoId(id) != null && estado != null)
            {
                return _estadoDAL.ModificarEstado(id, estado);
            }
            return false;
        }

        public bool EliminarEstado(int id)
        {
            if (_estadoDAL.BuscarEstadoId(id) != null)
            {
                _estadoDAL.EliminarEstado(id);
                return true;
            }
            return false;
        }
        #endregion
    }
}
