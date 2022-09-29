using RuteoBusesDAL.CrudsDAL;
using RuteoBusesDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuteoBusesBL
{
    public class RolBL
    {
        private readonly RolDAL _rolDAL;
        public RolBL(RuteoBusesDbcontext context)
        {
            _rolDAL = new RolDAL(context);

        }
        #region CRUD
        public ICollection<Rol> listaRoles()
        {
            return _rolDAL.ListaRoles();
        }
      
        #endregion

    }
}
