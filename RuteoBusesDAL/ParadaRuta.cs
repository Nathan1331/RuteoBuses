using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuteoBusesDAL
{
    public class ParadaRuta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int paradaRutaId { get; set; }
        public string? nombreParadaRuta { get; set; }
        //-----------------------------------------------
        public int?  rutaId { get; set; }// se define a cual ruta pertenece
       
        [ForeignKey("rutaId")]
        public virtual Ruta? ruta { get; set; }

        public int? busId { get; set; }

        [ForeignKey("busId")] //Se define cual de los buses asignados a la ruta la hara
        public virtual Bus? bus { get; set; }


    }
}
