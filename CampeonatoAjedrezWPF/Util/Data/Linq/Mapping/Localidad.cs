using Data.Interfaz;
using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Linq.Mapping
{
    [Table(Name ="localidad")]
    public class Localidad:IEntidad
    {
        [Column(IsDbGenerated =true,IsPrimaryKey =true,CanBeNull =false)]
        public int idlocalidad { get; set; }

        public int? llavePrimaria
        {
            get
            {
                return idlocalidad;
            }
        }

        public string NombreTabla
        {
            get
            {
                return "LOCALIDAD";
            }
        }

        [Column]
        public string nomlocalidad { get; set; }
    }

}
