namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GIAI")]
    public partial class GIAI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GIAI()
        {
            KETQUAs = new HashSet<KETQUA>();
        }

        [Key]
        [Display(Name ="Mã Giải")]
        
        public int MAGIAI { get; set; }

        [StringLength(50)]
        [Display(Name = "Tên Giải")]
        public string TEN { get; set; }

        [Display(Name = "Tình Trạng")]
        public int? TINHTRANG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KETQUA> KETQUAs { get; set; }
    }
}
