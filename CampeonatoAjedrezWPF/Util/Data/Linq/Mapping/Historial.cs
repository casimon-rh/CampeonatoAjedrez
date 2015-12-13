using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Linq.Mapping
{
    [Table(Name ="campeonato_anterior_participante")]
    public class Historial
    {
        [Column]
        public int idcampeonato;
        [Column]
        public int id_participante;
        [Column]
        public string tipo;
    }
}
