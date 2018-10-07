namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHIEUTHU")]
    public partial class PHIEUTHU
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MAPT { get; set; }

        public int? MADL { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NGAY { get; set; }

        [Column(TypeName = "money")]
        public decimal? TIEN { get; set; }

        public int? TINHTRANG { get; set; }

        public virtual DAILY DAILY { get; set; }
    }
}
