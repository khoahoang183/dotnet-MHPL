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
        [Display(Name = "Mã Kết Quả")]
        public int MAKQ { get; set; }
        [Display(Name = "Mã Vé")]
        public int? MAVS { get; set; }
       
        [Column(TypeName = "date")]
        [Display(Name = "Ngày")]
        public DateTime? NGAY { get; set; }
        [Display(Name = "Mã Giải")]
        public int? MAGIAI { get; set; }

        [StringLength(6)]
        [Display(Name = "Số trúng")]
        public string SOTRUNG { get; set; }
        [Display(Name = "Tình Trạng")]
        public int? TINHTRANG { get; set; }

        public virtual GIAI GIAI { get; set; }

        public virtual VESO VESO { get; set; }
    }
}
