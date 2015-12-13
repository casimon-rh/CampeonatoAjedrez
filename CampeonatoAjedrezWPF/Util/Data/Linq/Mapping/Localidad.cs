using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Linq.Mapping
{
    [Table(Name ="localidad")]
    public class Localidad
    {
        [Column(IsDbGenerated =true,IsPrimaryKey =true,CanBeNull =false)]
        public int idlocalidad;

        [Column]
        public string nombrelocalidad;
    }

}
