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
    public partial class CAMPEONATO_ANTERIOR
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CAMPEONATO_ANTERIOR()
        {
            CAMPEONATO_ANTERIOR_PARTICIPANTE = new HashSet<CAMPEONATO_ANTERIOR_PARTICIPANTE>();
        }

        [Key]
        [DataMember]
        public int IDCAMPEONATO { get; set; }

        [DataMember]
        public DateTime? FECHA { get; set; }

        [StringLength(20)]
        [DataMember]
        public string NOMBRE { get; set; }

        [ScriptIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CAMPEONATO_ANTERIOR_PARTICIPANTE> CAMPEONATO_ANTERIOR_PARTICIPANTE { get; set; }
    }
}
