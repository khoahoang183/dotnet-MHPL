namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHIEUCHI")]
    public partial class PHIEUCHI
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MAPC { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NGAY { get; set; }

        [Column(TypeName = "money")]
        public decimal? TIEN { get; set; }

        public int? TINHTRANG { get; set; }
    }
}
