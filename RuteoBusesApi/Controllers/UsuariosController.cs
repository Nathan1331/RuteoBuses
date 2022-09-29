using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RuteoBusesBL;
using RuteoBusesDAL;

namespace RuteoBusesApi.Controllers
{
    [Route("api/Usuarios")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioBL _usuarioBL;

        public UsuariosController(RuteoBusesDbcontext context)
        {
            _usuarioBL = new UsuarioBL(context);
        }

        // GET: api/Usuarios
        [HttpGet]
        public ICollection<Usuario> Getusuarios()
        {
            return _usuarioBL.listaUsuario();
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public Usuario? GetUsuario(int id)
        {
            return _usuarioBL.BuscarUsuarioId(id);
        }

        // PUT: api/Usuarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public bool ModificarUsuario(int id, Usuario usuario)
        {
            return _usuarioBL.ModificarUsuario(id, usuario);
        }

        // POST: api/Usuarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public bool AgregarUsuario(Usuario usuario)
        {
            return _usuarioBL.AgregarUsuario(usuario);
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public bool EliminarUsuario(int id)
        {
            return _usuarioBL.EliminarUsuario(id);    
        }


    }
}
