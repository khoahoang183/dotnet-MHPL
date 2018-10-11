namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SOLUONGDANGKY")]
    public partial class SOLUONGDANGKY
    {
        [Key]
        public int MASLDK { get; set; }

        public int? MADL { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NGAY { get; set; }

        public int? SLDANGKY { get; set; }

        public virtual DAILY DAILY { get; set; }
    }
}
