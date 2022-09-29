using RuteoBusesDAL.CrudsDAL;
using RuteoBusesDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuteoBusesBL
{
    public class RutaBL
    {
        private readonly RutaDAL _rutaDAL;
        private readonly ParadaRutaBL _paradaRutaBL;
        public RutaBL(RuteoBusesDbcontext context)
        {
            _rutaDAL = new RutaDAL(context);
            _paradaRutaBL = new ParadaRutaBL(context);

        }
        #region CRUD
        public ICollection<Ruta> listaRuta()
        {
            return _rutaDAL.ListaRuta();
        }
        public bool AgregarRuta(Ruta ruta)
        {
            if (ruta != null && _rutaDAL.BuscarRutaEnt(ruta) == null)
            {
                int e = 1;
                _rutaDAL.AgregarRuta(ruta);
                for (int i = 0; i<ruta.cantidadDeParadas; i++) 
                {
                    ParadaRuta par = new ParadaRuta();
                    par.rutaId = ruta.rutaId;
                    e++;
                    par.nombreParadaRuta = "Parada " + e;
                    _paradaRutaBL.AgregarParadaRuta(par);

                }
                
                return true;
            }

            return false;
        }
        public Ruta? BuscarRutaId(int id)
        {
            if (_rutaDAL.ListaRuta == null)
            {
                return null;
            }
            return _rutaDAL.BuscarRutaId(id);
        }
        public bool ModificarRuta(int id, Ruta ruta)
        {
            if (_rutaDAL.BuscarRutaId(id) != null && ruta != null)
            {
                return _rutaDAL.ModificarRuta(id, ruta);
            }
            return false;
        }

        public bool EliminarRuta(int id)
        {
            if (_rutaDAL.BuscarRutaId(id) != null)
            {
                _rutaDAL.EliminarRuta(id);
                return true;
            }
            return false;
        }
        #endregion

    }
}
