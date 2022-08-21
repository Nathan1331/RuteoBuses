using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuteoBusesDAL
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int userId { get; set; }
        public string nombre { get; set; }
        public string Identificacion { get; set; }
        public int rolId { get; set; }

        [ForeignKey("rolId")] //Se define cual de los buses asignados a la ruta la hara
        public virtual Rol? rol { get; set; }
    }
}
