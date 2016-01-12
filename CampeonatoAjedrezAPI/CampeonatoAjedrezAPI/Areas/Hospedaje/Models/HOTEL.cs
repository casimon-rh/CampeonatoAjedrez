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
    [Table("HOTEL")]
    public partial class HOTEL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HOTEL()
        {
            HOTEL_PARTICIPANTE = new HashSet<HOTEL_PARTICIPANTE>();
            HOTEL_TELEFONO = new HashSet<HOTEL_TELEFONO>();
        }

        [Key]
        [DataMember]
        public int ID_HOTEL { get; set; }

        [Required]
        [StringLength(40)]
        [DataMember]
        public string NOMBREHOTEL { get; set; }

        [StringLength(10)]
        [DataMember]
        public string DIRNUM { get; set; }

        [StringLength(30)]
        [DataMember]
        public string DIRCALLE { get; set; }

        [StringLength(10)]
        [DataMember]
        public string DIRCP { get; set; }

        [ScriptIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOTEL_PARTICIPANTE> HOTEL_PARTICIPANTE { get; set; }

        [ScriptIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOTEL_TELEFONO> HOTEL_TELEFONO { get; set; }
    }
}
