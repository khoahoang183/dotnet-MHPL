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
        [Display(Name = "Mã Phân Phối")]
        public int MAPP { get; set; }

        [Display(Name = "Mã Vé")]
        public int? MAVS { get; set; }

        [Display(Name = "Mã Đại Lý")]
        public int? MADL { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Ngày")]
        public DateTime? NGAY { get; set; }

        [Display(Name = "Số lượng giao")]
        public int? SLGIAO { get; set; }

        [Display(Name = "Số lượng bán")]
        public int? SLBAN { get; set; }

        [Display(Name = "Tình Trạng")]
        public int? TINHTRANG { get; set; }

        public virtual DAILY DAILY { get; set; }

        public virtual VESO VESO { get; set; }
    }
}
