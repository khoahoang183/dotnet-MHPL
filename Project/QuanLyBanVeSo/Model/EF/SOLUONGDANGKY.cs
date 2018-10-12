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
        [Display(Name = "Mã Số Lượng")]
        public int MASLDK { get; set; }
        [Display(Name = "Mã Đại Lý")]
        public int? MADL { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Ngày")]
        public DateTime? NGAY { get; set; }
        [Display(Name = "Số Lượng")]
        public int? SLDANGKY { get; set; }

        public virtual DAILY DAILY { get; set; }
    }
}
