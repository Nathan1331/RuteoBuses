using RuteoBusesDAL.CrudsDAL;
using RuteoBusesDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuteoBusesBL
{
    public class ParadaRutaBL
    {
        #region variables
        private ParadaRutaDAL _paradaRutaDAL;
        #endregion
        public ParadaRutaBL(RuteoBusesDbcontext context)
        {
            _paradaRutaDAL = new ParadaRutaDAL(context);

        }


        #region CRUD
        public ICollection<ParadaRuta> listaParadaRuta()
        {
            return _paradaRutaDAL.ListaParadas();
        }
        public bool AgregarParadaRuta(ParadaRuta paradaRuta)
        {
            if (paradaRuta != null && _paradaRutaDAL.BuscarParadaRutaEnt(paradaRuta) == null)
            {
                _paradaRutaDAL.AgregarParadaRuta(paradaRuta);
                
                return true;
            }

            return false;
        }
        public ParadaRuta? BuscarParadaRutaId(int id)
        {
            if (_paradaRutaDAL.ListaParadas == null)
            {
                return null;
            }
            return _paradaRutaDAL.BuscarParadaRutaId(id);
        }
        public bool ModificarParadaRuta(int id, ParadaRuta paradaRuta)
        {
            if (_paradaRutaDAL.BuscarParadaRutaId(id) != null && paradaRuta != null)
            {
                return _paradaRutaDAL.ModificarParadaRuta(id, paradaRuta);
            }
            return false;
        }

        public bool EliminarBus(int id)
        {
            if (_paradaRutaDAL.BuscarParadaRutaId(id) != null)
            {
                _paradaRutaDAL.EliminarParadaRuta(id);
                return true;
            }
            return false;
        }
        #endregion
    }
}
