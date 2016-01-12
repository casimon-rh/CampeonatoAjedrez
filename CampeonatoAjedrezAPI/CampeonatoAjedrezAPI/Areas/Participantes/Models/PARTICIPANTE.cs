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
    [Table("PARTICIPANTE")]
    public partial class PARTICIPANTE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PARTICIPANTE()
        {
            CAMPEONATO_ANTERIOR_PARTICIPANTE = new HashSet<CAMPEONATO_ANTERIOR_PARTICIPANTE>();
            HOTEL_PARTICIPANTE = new HashSet<HOTEL_PARTICIPANTE>();
        }

        [Key]
        [DataMember]
        public int ID_PARTICIPANTE { get; set; }

        [StringLength(20)]
        [DataMember]
        public string NOMBRE { get; set; }

        [StringLength(20)]
        [DataMember]
        public string APPATERNO { get; set; }

        [StringLength(20)]
        [DataMember]
        public string APMATERNO { get; set; }

        [DataMember]
        public int IDLOCALIDAD { get; set; }

        
        [ScriptIgnore]
        public virtual ARBITRO ARBITRO { get; set; }

        [ScriptIgnore]
        public virtual JUGADOR JUGADOR { get; set; }

        [ScriptIgnore]
        public virtual LOCALIDAD LOCALIDAD { get; set; }

        [ScriptIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CAMPEONATO_ANTERIOR_PARTICIPANTE> CAMPEONATO_ANTERIOR_PARTICIPANTE { get; set; }

        [ScriptIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOTEL_PARTICIPANTE> HOTEL_PARTICIPANTE { get; set; }
    }
}
