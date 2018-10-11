namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KETQUA")]
    public partial class KETQUA
    {
        [Key]
        public int MAKQ { get; set; }

        public int? MAVS { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NGAY { get; set; }

        public int? MAGIAI { get; set; }

        [StringLength(6)]
        public string SOTRUNG { get; set; }

        public int? TINHTRANG { get; set; }

        public virtual GIAI GIAI { get; set; }

        public virtual VESO VESO { get; set; }
    }
}
