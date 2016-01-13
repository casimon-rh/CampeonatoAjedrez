using Data.Interfaz;
using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Linq.Mapping
{
    [Table(Name = "Arbitro")]
    public class Arbitro:IEntidad//:Participante
    {
        [Column]
        public int idarbitro { get; set; }

        public int? llavePrimaria
        {
            get
            {
                return idarbitro;
            }
        }

        public string NombreTabla
        {
            get
            {
                return "ARBITRO";
            }
        }

        //public Participante participante { get; set; }
    }
}
