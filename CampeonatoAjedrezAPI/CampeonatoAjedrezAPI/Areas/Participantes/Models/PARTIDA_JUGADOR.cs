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
    public partial class PARTIDA_JUGADOR
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DataMember]
        public int IDPARTIDA { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DataMember]
        public int IDJUGADOR { get; set; }

        [DataMember]
        public bool? COLOR { get; set; }

        [ScriptIgnore]
        public virtual JUGADOR JUGADOR { get; set; }

        [ScriptIgnore]
        public virtual PARTIDA PARTIDA { get; set; }
    }
}
