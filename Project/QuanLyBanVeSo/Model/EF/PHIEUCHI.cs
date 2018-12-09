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
        [Display(Name = "Mã Phiếu Chi")]
        public int MAPC { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Ngày")]
        public DateTime? NGAY { get; set; }

        [Column(TypeName = "money")]
        [Display(Name = "Số tiền")]
        public decimal? TIEN { get; set; }

        [Display(Name = "Tình Trạng")]
        public int? TINHTRANG { get; set; }
    }
}
