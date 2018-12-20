namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HOAHONG")]
    public partial class HOAHONG
    {
        [Key]
        [Display(Name = "Mã Hoa Hồng")]
        public int MAHH { get; set; }

       
        [Display(Name = "Ngày")]
        public DateTime? NGAY { get; set; }
        [Display(Name = "Tỉ lệ")]
        public float TILE { get; set; }
        [Display(Name = "Tình Trạng")]
        public int? TINHTRANG { get; set; }

       
    }
}
