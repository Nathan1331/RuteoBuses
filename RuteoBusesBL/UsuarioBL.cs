using RuteoBusesDAL.CrudsDAL;
using RuteoBusesDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuteoBusesBL
{
    public class UsuarioBL
    {
        #region variables
        private UsuarioDAL _usuarioDAL;
        #endregion
        public UsuarioBL(RuteoBusesDbcontext context)
        {
            _usuarioDAL = new UsuarioDAL(context);

        }


        #region CRUD
        public ICollection<Usuario> listaUsuario()
        {
            return _usuarioDAL.ListaUsuario();
        }
        public bool AgregarUsuario(Usuario usuario)
        {
            if (usuario != null && _usuarioDAL.BuscarUsuarioEnt(usuario) == null)
            {
                _usuarioDAL.AgregarUsuario(usuario);
                return true;
            }

            return false;
        }
        public Usuario? BuscarUsuarioId(int id)
        {
            if (_usuarioDAL.ListaUsuario == null)
            {
                return null;
            }
            return _usuarioDAL.BuscarUsuarioId(id);
        }
        public bool ModificarUsuario(int id, Usuario usuario)
        {
            if (_usuarioDAL.BuscarUsuarioId(id) != null && usuario != null)
            {
                return _usuarioDAL.ModificarUsuario(id, usuario);
            }
            return false;
        }

        public bool EliminarUsuario(int id)
        {
            if (_usuarioDAL.BuscarUsuarioId(id) != null)
            {
                _usuarioDAL.EliminarUsuario(id);
                return true;
            }
            return false;
        }
        #endregion

    }
}
