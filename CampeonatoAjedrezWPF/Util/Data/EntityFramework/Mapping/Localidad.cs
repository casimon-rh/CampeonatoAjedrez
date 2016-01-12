using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EntityFramework.Mapping
{
    [Table("localidad")]
    public partial class Localidad
    {
    	public Localidad(){
    		Participantes = new HashSet<Participante>();
    	}
        [Key]
        public int idlocalidad;

        [Required]
        public string nombrelocalidad;

        public virtual ICollection<Participante> Participantes { get; set; }
    }

}
