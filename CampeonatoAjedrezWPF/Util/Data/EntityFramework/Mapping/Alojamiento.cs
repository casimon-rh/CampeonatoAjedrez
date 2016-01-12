using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EntityFramework.Mapping
{
    [Table("hotel_participante")]
    public partial class Alojamiento
    {
        public int id_participante { get; set; }
        public int id_hotel { get; set; }
        public DateTime? fecha_inicio { get; set; }
        public DateTime? fecha_final { get; set; }

        public virtual Hotel Hotel {get;set;}
        public virtual Participante Participante {get;set;}

    }
}
