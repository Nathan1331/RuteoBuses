using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuteoBusesDAL.CrudsDAL
{
    public class EstadoDAL
    {
        private RuteoBusesDbcontext _ruteoDbcontextAccess;
        public EstadoDAL(RuteoBusesDbcontext dbcontext)
        {
            _ruteoDbcontextAccess = dbcontext;
        }

        #region CRUD

        public ICollection<Estado> ListaEstados()
        {
            return _ruteoDbcontextAccess.estados.ToList();
        }
        public void AgregarEstado(Estado estado)
        {
            _ruteoDbcontextAccess.estados.Add(estado);
            _ruteoDbcontextAccess.SaveChanges();
        }
        public void EliminarEstado(int Id)
        {
            Estado? estado = BuscarEstadoId(Id);
            _ruteoDbcontextAccess.estados.Remove(estado);
            _ruteoDbcontextAccess.SaveChanges();
        }
        public bool ModificarEstado(int id, Estado estado)
        {
            if (estado != null)
            {
                Estado? modificar = BuscarEstadoId(id);
                modificar.Description = estado.Description;
                _ruteoDbcontextAccess.SaveChanges();

                return true;
            }
            return false;
        }
        public Estado? BuscarEstadoId(int id)
        {
            return _ruteoDbcontextAccess.estados.Find(id);
        }
        public Estado? BuscarEstadoEnt(Estado estado)
        {
            var buscar = _ruteoDbcontextAccess.estados.Find(estado.EstadoId);
            return buscar;
        }

        #endregion

    }
}
