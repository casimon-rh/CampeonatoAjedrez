using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Linq.Mapping
{
    [Table(Name ="partida_jugador")]
    public class PartidaJugador
    {
        [Column]
        public int idpartida { get; set; }
        [Column]
        public int idjugador { get; set; }
        [Column]
        public bool color { get; set; }
    }
}
