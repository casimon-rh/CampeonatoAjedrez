using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Linq.Mapping
{
    [Table(Name ="campeonato_anterior")]
    public class Campeonato
    {
        [Column(IsDbGenerated =true,IsPrimaryKey =true,CanBeNull =false)]
        public int idcampeonato { get; set; }
        [Column]
        public DateTime? fecha { get; set; }
        [Column]
        public string nombre { get; set; }
    }
}
