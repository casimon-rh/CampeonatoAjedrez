using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EntityFramework.Mapping
{
    [Table("partida_jugador")]
    public partial class PartidaJugador
    {
        
        public int idpartida { get; set; }
        
        public int idjugador { get; set; }
        [Required]
        public bool color { get; set; }

        public virtual Partida Partida{get;set;}

        public virtual Jugador Jugador{get;set;}
    }
}
