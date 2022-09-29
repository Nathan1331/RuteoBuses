using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuteoBusesDAL.CrudsDAL
{
    public class RutaDAL
    {
        private RuteoBusesDbcontext _ruteoDbcontextAccess;
        public RutaDAL(RuteoBusesDbcontext dbcontext)
        {
            _ruteoDbcontextAccess = dbcontext;
        }

        #region CRUD

        public ICollection<Ruta> ListaRuta()
        {
            return _ruteoDbcontextAccess.rutas.ToList();
        }
        public void AgregarRuta(Ruta ruta)
        {
            _ruteoDbcontextAccess.rutas.Add(ruta);
            _ruteoDbcontextAccess.SaveChanges();
        }
        public void EliminarRuta(int Id)
        {
            Ruta? Ruta = BuscarRutaId(Id);
            _ruteoDbcontextAccess.rutas.Remove(Ruta);
            _ruteoDbcontextAccess.SaveChanges();
        }
        public bool ModificarRuta(int id, Ruta ruta)
        {
            if (ruta != null)
            {
                Ruta? modificar = BuscarRutaId(id);
                modificar.nombreRuta = ruta.nombreRuta;
                modificar.montoEstimado = ruta.montoEstimado;
                modificar.montoRecibido = ruta.montoRecibido;
                
                _ruteoDbcontextAccess.SaveChanges();

                return true;
            }
            return false;
        }
        public Ruta? BuscarRutaId(int id)
        {
            return _ruteoDbcontextAccess.rutas.Find(id);
        }
        public Ruta? BuscarRutaEnt(Ruta ruta)
        {
            var buscar = _ruteoDbcontextAccess.rutas.Find(ruta.rutaId);
            return buscar;
        }

        #endregion

    }
}
