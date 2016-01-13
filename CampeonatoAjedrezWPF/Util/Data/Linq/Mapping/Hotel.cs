using Data.Interfaz;
using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Linq.Mapping
{
    [Table(Name = "hotel")]
    public class Hotel:IEntidad
    {
        [Column(IsDbGenerated = true, CanBeNull = false, IsPrimaryKey = true)]
        public int id_hotel { get; set; }
        [Column]
        public string nombrehotel { get; set; }
        [Column]
        public string dirnum { get; set; }
        [Column]
        public string dircalle { get; set; }
        [Column]
        public string dircp { get; set; }

        public string NombreTabla
        {
            get
            {
                return "HOTEL";
            }
        }

        public int? llavePrimaria
        {
            get
            {
                return id_hotel;
            }
        }
    }
}
