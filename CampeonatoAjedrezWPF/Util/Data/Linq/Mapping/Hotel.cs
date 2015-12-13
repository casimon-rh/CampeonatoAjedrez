using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Linq.Mapping
{
    [Table(Name = "hotel")]
    public class Hotel
    {
        [Column(IsDbGenerated = true, CanBeNull = false, IsPrimaryKey = true)]
        public int id_hotel { get; set; }
        [Column]
        public string nombrehotel;
        [Column]
        public string dirnum;
        [Column]
        public string dircalle;
        [Column]
        public string dircp;
    }
}
