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
    public partial class HOTEL_PARTICIPANTE
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DataMember]
        public int ID_PARTICIPANTE { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DataMember]
        public int ID_HOTEL { get; set; }

        [DataMember]
        public DateTime? FECHA_INICIO { get; set; }

        [DataMember]
        public DateTime? FECHA_FINAL { get; set; }

        [ScriptIgnore]
        public virtual HOTEL HOTEL { get; set; }

        [ScriptIgnore]
        public virtual PARTICIPANTE PARTICIPANTE { get; set; }
    }
}
