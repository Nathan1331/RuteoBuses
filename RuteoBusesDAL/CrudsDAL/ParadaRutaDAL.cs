using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuteoBusesDAL.CrudsDAL
{
    public class ParadaRutaDAL
    {

        private RuteoBusesDbcontext _ruteoDbcontextAccess;
        public ParadaRutaDAL(RuteoBusesDbcontext dbcontext)
        {
            _ruteoDbcontextAccess = dbcontext;
        }

        #region CRUD

        public ICollection<ParadaRuta> ListaParadas()
        {
            return _ruteoDbcontextAccess.paradarutas.ToList();
        }
        public void AgregarParadaRuta(ParadaRuta paradaRuta)
        {
            _ruteoDbcontextAccess.paradarutas.Add(paradaRuta);
            _ruteoDbcontextAccess.SaveChanges();
        }
        public void EliminarParadaRuta(int Id)
        {
            ParadaRuta? paradaRuta = BuscarParadaRutaId(Id);
            _ruteoDbcontextAccess.paradarutas.Remove(paradaRuta);
            _ruteoDbcontextAccess.SaveChanges();
        }
        public bool ModificarParadaRuta(int id, ParadaRuta paradaRuta)
        {
            if (paradaRuta != null)
            {
                ParadaRuta? modificar = BuscarParadaRutaId(id);
                modificar.nombreParadaRuta = paradaRuta.nombreParadaRuta;
                modificar.busId = paradaRuta.busId;
                modificar.rutaId = paradaRuta.rutaId;
                _ruteoDbcontextAccess.SaveChanges();

                return true;
            }
            return false;
        }
        public ParadaRuta? BuscarParadaRutaId(int id)
        {
            return _ruteoDbcontextAccess.paradarutas.Find(id);
        }
        public ParadaRuta? BuscarParadaRutaEnt(ParadaRuta paradaRuta)
        {
            var buscar = _ruteoDbcontextAccess.paradarutas.Find(paradaRuta.paradaRutaId);
            return buscar;
        }

        #endregion
    }
}
