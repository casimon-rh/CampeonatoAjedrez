using Data.Interfaz;
using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Linq.Mapping
{
    [Table(Name ="campeonato_anterior_participante")]
    public class Historial:IEntidad
    {
        [Column]
        public int idcampeonato;
        [Column]
        public int id_participante;
        [Column]
        public string tipo;

        public int? llavePrimaria
        {
            get
            {
                return null;
            }
        }

        public string NombreTabla
        {
            get
            {
                return "CAMPEONATO_ANTERIOR_PARTICIPANTE";
            }
        }
    }
}
