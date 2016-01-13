using Data.Interfaz;
using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Linq.Mapping
{
    [Table(Name ="hotel_participante")]
    public class Alojamiento:IEntidad
    {
        [Column]
        public int id_participante { get; set; }
        [Column]
        public int id_hotel { get; set; }
        [Column]
        public DateTime? fecha_inicio { get; set; }
        [Column]
        public DateTime? fecha_final { get; set; }

        public string NombreTabla
        {
            get
            {
                return "HOTEL_PARTICIPANTE";
            }
        }

        public int? llavePrimaria
        {
            get
            {
                return null;
            }
        }
    }
}
