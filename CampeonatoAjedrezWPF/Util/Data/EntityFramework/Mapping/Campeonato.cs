using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EntityFramework.Mapping
{
    [Table("campeonato_anterior")]
    public partial class Campeonato
    {
        public Campeonato(){
            Historial = new HashSet<Historial>();
        }

        [Column(IsDbGenerated =true,IsPrimaryKey =true,CanBeNull =false)]
        public int idcampeonato { get; set; }
        [Column]
        public DateTime? fecha { get; set; }
        [Column]
        public string nombre { get; set; }


        public virtual ICollection<Historial> Historial { get; set; }
    }
}
