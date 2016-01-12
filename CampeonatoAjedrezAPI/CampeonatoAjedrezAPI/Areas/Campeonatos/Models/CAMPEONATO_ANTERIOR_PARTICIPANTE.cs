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
    public partial class CAMPEONATO_ANTERIOR_PARTICIPANTE
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DataMember]
        public int IDCAMPEONATO { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DataMember]
        public int ID_PARTICIPANTE { get; set; }

        [StringLength(30)]
        [DataMember]
        public string TIPO { get; set; }

        [ScriptIgnore]
        public virtual CAMPEONATO_ANTERIOR CAMPEONATO_ANTERIOR { get; set; }

        [ScriptIgnore]
        public virtual PARTICIPANTE PARTICIPANTE { get; set; }
    }
}
