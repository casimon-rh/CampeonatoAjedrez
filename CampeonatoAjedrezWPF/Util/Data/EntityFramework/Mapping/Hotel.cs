using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EntityFramework.Mapping
{
    [Table("hotel")]
    public partial class Hotel
    {
        public Hotel()
        {
            Telefonos = new HashSet<Telefono>();
            Alojados = new HashSet<Alojamiento>();
        }
        [Key]
        [Display(Name="Id")]
        public int id_hotel { get; set; }
        [Required]
        [Display(Name="Nombre")]
        public string nombrehotel{ get; set; }
        [Required]
        [Display(Name="Numero")]
        public string dirnum{ get; set; }
        [Required]
        [Display(Name="Calle")]
        public string dircalle{ get; set; }
        [Required]
        [Display(Name="Codigo Postal")]
        public string dircp{ get; set; }

        public virtual ICollection<Telefono> Telefonos { get; set; }
        public virtual ICollection<Alojamiento> Alojados { get; set; }
    }
}
