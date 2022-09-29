using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RuteoBusesDAL
{
    public class Bus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int busId { get; set; }
        public int? estadoId { get; set; } // el usuario debera elegir de una lista de la tabla estados 
        [ForeignKey("estadoId")]
        public virtual Estado? estadoUnidad{ get; set; }
        public int? rutaId { get; set; }

        [ForeignKey("rutaId")]
        public virtual Ruta? ruta { get; set; } //Puede ser null se asigna a la hora de asignar ruta
        public int? choferId { get; set; }

        [ForeignKey("choferId")] //Puede ser null se agrega a la hora de asignar ruta
        public virtual Chofer? chofer { get; set; }

        public virtual ICollection<ParadaRuta>? paradas { get; set; }

    }
}