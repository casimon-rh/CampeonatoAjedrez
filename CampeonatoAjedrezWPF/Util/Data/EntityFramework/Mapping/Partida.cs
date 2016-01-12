using System;
using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EntityFramework.Mapping
{
    [Table("partida")]
    public partial class Partida
    {
        public Partida(){
            PartidaJugador = new HashSet<PartidaJugador>();
        }
        [Key]
        public int idpartida { get; set; }
        public int idarbitro {get; set;}
        [Required]
        public DateTime hora { get; set;}
        
        public virtual Arbitro Arbitro{get;set;}

        public virtual ICollection<PartidaJugador> PartidaJugador { get; set; }
    }
}
