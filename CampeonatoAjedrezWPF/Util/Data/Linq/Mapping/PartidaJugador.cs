using Data.Interfaz;
using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Linq.Mapping
{
    [Table(Name = "partida_jugador")]
    public class PartidaJugador : IEntidad
    {
        [Column]
        public int idpartida { get; set; }
        [Column]
        public int idjugador { get; set; }
        [Column]
        public bool color { get; set; }

        public string NombreTabla
        {
            get
            {
                return "PARTIDA_JUGADOR";
            }
        }

        public int? llavePrimaria
        {
            get
            {
                return idpartida;
            }
        }
    }
}
