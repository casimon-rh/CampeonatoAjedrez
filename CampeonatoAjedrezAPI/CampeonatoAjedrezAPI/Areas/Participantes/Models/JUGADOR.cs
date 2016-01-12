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
    [Table("JUGADOR")]
    public partial class JUGADOR
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public JUGADOR()
        {
            PARTIDA_JUGADOR = new HashSet<PARTIDA_JUGADOR>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DataMember]
        public int IDJUGADOR { get; set; }

        [DataMember]
        public int NIVEL { get; set; }

        [ScriptIgnore]
        public virtual PARTICIPANTE PARTICIPANTE { get; set; }

        [ScriptIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PARTIDA_JUGADOR> PARTIDA_JUGADOR { get; set; }
    }
}
