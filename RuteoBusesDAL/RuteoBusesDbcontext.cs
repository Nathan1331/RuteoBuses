using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuteoBusesDAL
{
    public class RuteoBusesDbcontext : DbContext
    {
        public RuteoBusesDbcontext(DbContextOptions<RuteoBusesDbcontext> options) : base(options)
        {

        }
        #region test
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=.; Database=RuteoBuses; Trusted_Connection=True; ");
        //}
        #endregion
        public DbSet<Bus> buses { get; set; }
        public DbSet<Chofer> choferes { get; set; }
        public DbSet<Estado> estados { get; set; }
        public DbSet<ParadaRuta> paradarutas { get; set; }
        public DbSet<Ruta> rutas { get; set; }
        public DbSet<Rol> roles { get; set; }
        public DbSet<Usuario> usuarios { get; set; }

    }
}
