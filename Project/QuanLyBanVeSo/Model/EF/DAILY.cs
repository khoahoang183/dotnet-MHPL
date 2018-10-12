namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DAILY")]
    public partial class DAILY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DAILY()
        {
            PHANPHOIs = new HashSet<PHANPHOI>();
            PHIEUTHUs = new HashSet<PHIEUTHU>();
            SOLUONGDANGKies = new HashSet<SOLUONGDANGKY>();
        }

        [Key]
        [Display(Name = "Mã Đại Lí")]
        public int MADL { get; set; }

        [StringLength(100)]
        [Display(Name = "Tên")]
        public string TEN { get; set; }
        [Display(Name = "Tình Trạng")]
        public int? TINHTRANG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHANPHOI> PHANPHOIs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUTHU> PHIEUTHUs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SOLUONGDANGKY> SOLUONGDANGKies { get; set; }
    }
}
