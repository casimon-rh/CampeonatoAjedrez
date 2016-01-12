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
    [Table("LOCALIDAD")]
    public partial class LOCALIDAD
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LOCALIDAD()
        {
            PARTICIPANTE = new HashSet<PARTICIPANTE>();
        }

        [Key]
        [DataMember]
        public int IDLOCALIDAD { get; set; }

        [StringLength(20)]
        [DataMember]
        public string NOMLOCALIDAD { get; set; }

        [ScriptIgnore]
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PARTICIPANTE> PARTICIPANTE { get; set; }
    }
}
