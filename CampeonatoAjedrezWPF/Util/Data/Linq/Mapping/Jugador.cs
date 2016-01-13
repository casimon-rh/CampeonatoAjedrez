using Data.Interfaz;
using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Linq.Mapping
{
    [Table]
    public class Jugador :IEntidad//:Participante
    {
        [Column]
        public int idjugador { get; set; }

        public int? llavePrimaria
        {
            get
            {
                return idjugador;
            }
        }

        [Column]
        public int nivel { get; set; }

        public string NombreTabla
        {
            get
            {
                return "JUGADOR";
            }
        }

        //public Participante participante { get; set; }
    }
}
