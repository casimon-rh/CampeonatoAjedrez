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
    public partial class HOTEL_TELEFONO
    {
        [DataMember]
        public int ID_HOTEL { get; set; }

        [Key]
        [DataMember]
        public int ID_TELEFONO { get; set; }

        [StringLength(30)]
        [DataMember]
        public string TELEFONO { get; set; }

        [ScriptIgnore]
        public virtual HOTEL HOTEL { get; set; }
    }
}
