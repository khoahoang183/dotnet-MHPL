namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHANPHOI")]
    public partial class PHANPHOI
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MAPP { get; set; }

        public int? MAVS { get; set; }

        public int? MADL { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NGAY { get; set; }

        public int? SLGIAO { get; set; }

        public int? SLBAN { get; set; }

        public int? TINHTRANG { get; set; }

        public virtual DAILY DAILY { get; set; }

        public virtual VESO VESO { get; set; }
    }
}
