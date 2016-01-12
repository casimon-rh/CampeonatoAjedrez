using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EntityFramework.Mapping
{
    [Table("hotel_telefono")]
    public partial class Telefono
    {
        [Key]
        [Display(Name="Id")]
        public int id_telefono { get; set; }

        public int id_hotel { get; set; }

        [Required]
        public string telefono { get; set; }

        public virtual Hotel Hotel{get;set;}
    }
}
