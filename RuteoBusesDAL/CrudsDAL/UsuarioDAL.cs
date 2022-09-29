using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuteoBusesDAL.CrudsDAL
{
    public class UsuarioDAL
    {
        private RuteoBusesDbcontext RuteoDbcontextAccess;
        public UsuarioDAL(RuteoBusesDbcontext dbcontext)
        {
            RuteoDbcontextAccess = dbcontext;
        }

        #region CRUD

        public ICollection<Usuario> ListaUsuario()
        {
            return RuteoDbcontextAccess.usuarios.ToList();
        }
        public void AgregarUsuario(Usuario usuario)
        {
            RuteoDbcontextAccess.usuarios.Add(usuario);
            RuteoDbcontextAccess.SaveChanges();
        }
        public void EliminarUsuario(int Id)
        {
            Usuario usuario = BuscarUsuarioId(Id);
            RuteoDbcontextAccess.usuarios.Remove(usuario);
            RuteoDbcontextAccess.SaveChanges();
        }
        public bool ModificarUsuario(int id, Usuario usuario)
        {
            if (usuario != null)
            {
                Usuario? modificar = BuscarUsuarioId(id);
                modificar.Identificacion = usuario.Identificacion;
                modificar.rolId = usuario.rolId;
                modificar.nombre = usuario.nombre;
                modificar.clave = usuario.clave;
                RuteoDbcontextAccess.SaveChanges();

                return true;
            }
            return false;
        }
        public Usuario? BuscarUsuarioId(int id)
        {
            return RuteoDbcontextAccess.usuarios.Find(id);
        }
        public Usuario? BuscarUsuarioEnt(Usuario usuario)
        {
            var buscar = RuteoDbcontextAccess.usuarios.Find(usuario.userId);
            return buscar;
        }

        #endregion

    }
}
