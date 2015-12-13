using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Linq.Mapping
{
    [Table]
    public class Jugador//:Participante
    {
        [Column]
        public int idjugador { get; set; }
        [Column]
        public int nivel { get; set; }

        public Participante participante { get; set; }
    }
}
