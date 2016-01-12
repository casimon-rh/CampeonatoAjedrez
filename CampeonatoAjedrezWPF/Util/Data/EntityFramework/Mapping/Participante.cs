using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EntityFramework.Mapping
{
    [Table("participante")]
    public partial class Participante
    {
        public Participante(){
            Alojados = new HashSet<Alojamiento>();
            Historial = new HashSet<Historial>();
            Jugador = new HashSet<Jugador>();
            Arbitro = new HashSet<Arbitro>();
        }
        [Key]
        public int id_participante { get; set; }

        [Required]
        public string nombre { get; set; }

        [Required]
        [Display(Name="Apellido Paterno")]
        public string appaterno { get; set; }

        [Display(Name="Apellido Materno")]
        public string apmaterno { get; set; }

        public int idlocalidad { get; set; }

        public virtual Localidad localidad { get; set; }

        public virtual ICollection<Alojamiento> Alojados { get; set; }
        public virtual ICollection<Historial> Historial { get; set; }

        public virtual ICollection<Arbitro> Arbitro { get; set; }
        public virtual ICollection<Jugador> Jugador { get; set; }
    }
}

