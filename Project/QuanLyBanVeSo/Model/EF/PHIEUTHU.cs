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
        [Display(Name = "Mã Phiếu Thu")]
        public int MAPT { get; set; }

        [Display(Name = "Mã Đại Lí")]
        public int? MADL { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Ngày")]
        public DateTime? NGAY { get; set; }

        [Column(TypeName = "money")]
        [Display(Name = "Số Tiền")]
        public decimal? TIEN { get; set; }

        [Display(Name = "Tình Trạng")]
        public int? TINHTRANG { get; set; }

        public virtual DAILY DAILY { get; set; }
    }
}
