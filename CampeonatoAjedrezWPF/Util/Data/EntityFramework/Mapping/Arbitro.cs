using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EntityFramework.Mapping
{
    [Table("Arbitro")]
    public partial class Arbitro//:Participante
    {
        public Arbitro(){
        	Partida = new HashSet<Partida>();
        }


        public int idarbitro { get; set; }

        public virtual Participante participante { get; set; }

        public virtual ICollection<Partida> Partida { get; set; }
    }
}
