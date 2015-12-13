using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Linq.Mapping
{
    [Table(Name ="partida")]
    public class Partida
    {
        [Column(IsDbGenerated =true,CanBeNull =false,IsPrimaryKey =true)]
        public int idpartida { get; set; }
        [Column]
        public int idarbitro {get; set;}
        [Column]
        public DateTime hora { get; set;}
        
    }
}
