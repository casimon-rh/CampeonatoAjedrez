namespace CampeonatoAjedrezAPI.Areas
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.Serialization;
    using System.Web.Script.Serialization;

    [DataContract(IsReference = true)]
    [Table("PARTIDA")]
    public partial class PARTIDA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PARTIDA()
        {
            PARTIDA_JUGADOR = new HashSet<PARTIDA_JUGADOR>();
        }

        [Key]
        [DataMember]
        public int IDPARTIDA { get; set; }

        [DataMember]
        public int IDARBITRO { get; set; }

        [DataMember]
        public DateTime? HORA { get; set; }

        [ScriptIgnore]
        public virtual ARBITRO ARBITRO { get; set; }

        [ScriptIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PARTIDA_JUGADOR> PARTIDA_JUGADOR { get; set; }
    }
}
