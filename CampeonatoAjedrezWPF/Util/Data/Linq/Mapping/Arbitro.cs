using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Linq.Mapping
{
    [Table(Name = "Arbitro")]
    public class Arbitro//:Participante
    {
        [Column]
        public int idarbitro { get; set; }

        public Participante participante { get; set; }
    }
}
