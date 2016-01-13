using Data.Interfaz;
using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Linq.Mapping
{
    [Table(Name = "hotel_telefono")]
    public class Telefono:IEntidad
    {
        [Column(IsDbGenerated = true, CanBeNull = false, IsPrimaryKey = true)]
        public int id_telefono { get; set; }

        [Column]
        public int id_hotel { get; set; }

        [Column]
        public string telefono { get; set; }

        public string NombreTabla
        {
            get
            {
                return "HOTEL_TELEFONO";
            }
        }

        public int? llavePrimaria
        {
            get
            {
                return id_telefono;
            }
        }
    }
}
