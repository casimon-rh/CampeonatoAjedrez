using Data.Interfaz;
using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Linq.Mapping
{
    [Table(Name ="partida")]
    public class Partida:IEntidad
    {
        [Column(IsDbGenerated =true,CanBeNull =false,IsPrimaryKey =true)]
        public int idpartida { get; set; }
        [Column]
        public int idarbitro {get; set;}
        [Column]
        public DateTime hora { get; set;}

        public string NombreTabla
        {
            get
            {
                return "PARTIDA";
            }
        }

        public int? llavePrimaria
        {
            get
            {
                return idpartida;
            }
        }
    }
}
