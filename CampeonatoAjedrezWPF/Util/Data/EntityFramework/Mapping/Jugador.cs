using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EntityFramework.Mapping
{
    [Table("Jugador")]
    public virtual class Jugador//:Participante
    {
    	public Jugador(){
    		PartidaJugador = new HashSet<PartidaJugador>();
    	}

        [Key]
        public int idjugador { get; set; }
        [Required]
        public int nivel { get; set; }

        public virtual Participante participante { get; set; }

        public virtual ICollection<PartidaJugador> PartidaJugador { get; set; }
    }
}
