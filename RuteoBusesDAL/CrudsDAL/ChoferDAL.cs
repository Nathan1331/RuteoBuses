using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuteoBusesDAL.CrudsDAL
{
    public class ChoferDAL
    {
        private RuteoBusesDbcontext _ruteoDbcontextAccess;
        public ChoferDAL(RuteoBusesDbcontext dbcontext)
        {
            _ruteoDbcontextAccess = dbcontext;
        }

        #region CRUD

        public ICollection<Chofer> ListaChoferes()
        {
            return _ruteoDbcontextAccess.choferes.ToList();
        }
        public void AgregarChofer(Chofer chofer)
        {
            _ruteoDbcontextAccess.choferes.Add(chofer);
            _ruteoDbcontextAccess.SaveChanges();
        }
        public void EliminarChofer(int Id)
        {
            Chofer? chofer = BuscarChoferId(Id);
            _ruteoDbcontextAccess.choferes.Remove(chofer);
            _ruteoDbcontextAccess.SaveChanges();
        }
        public bool ModificarChofer(int id, Chofer chofer)
        {
            if (chofer != null)
            {
                Chofer? modificar = BuscarChoferId(id);
                modificar.nombre = chofer.nombre;
                modificar.cedula = chofer.cedula;
                _ruteoDbcontextAccess.SaveChanges();

                return true;
            }
            return false;
        }
        public Chofer? BuscarChoferId(int id)
        {
            return _ruteoDbcontextAccess.choferes.Find(id);
        }
        public Chofer? BuscarChoferEnt(Chofer chofer)
        {
            var buscar = _ruteoDbcontextAccess.choferes.Find(chofer.choferId);
            return buscar;
        }

        #endregion


    }
}
