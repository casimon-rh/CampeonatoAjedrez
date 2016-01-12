using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EntityFramework.Mapping
{
    [Table("campeonato_anterior_participante")]
    public partial class Historial
    {
        public int idcampeonato { get; set; }
        public int id_participante { get; set; }
        [Required]
        public string tipo { get; set; }

        public virtual Campeonato Campeonato { get; set; }
        public virtual Participante Participante { get; set; }
    }
}
