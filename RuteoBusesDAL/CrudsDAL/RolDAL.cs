using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuteoBusesDAL.CrudsDAL
{
    public class RolDAL
    {
        private RuteoBusesDbcontext _ruteoDbcontextAccess;
        public RolDAL(RuteoBusesDbcontext dbcontext)
        {
            _ruteoDbcontextAccess = dbcontext;
        }

        public ICollection<Rol> ListaRoles()
        {
            return _ruteoDbcontextAccess.roles.ToList();
        }
    }
}
