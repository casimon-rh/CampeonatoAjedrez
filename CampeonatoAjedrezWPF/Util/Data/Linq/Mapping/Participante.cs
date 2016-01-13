using Data.Interfaz;
using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Linq.Mapping
{
    [Table(Name ="participante")]
    public class Participante:IEntidad
    {
        [Column(IsDbGenerated =true,CanBeNull =false,IsPrimaryKey =true)]
        public int id_participante { get; set; }

        [Column]
        public string nombre { get; set; }

        [Column]
        public string appaterno { get; set; }

        [Column] 
        public string apmaterno { get; set; }

        [Column]
        public int idlocalidad { get; set; }

        public Localidad localidad { get; set; }

        public string NombreTabla
        {
            get
            {
                return "PARTICIPANTE";
            }
        }

        public int? llavePrimaria
        {
            get
            {
                return id_participante;
            }
        }
    }
}
