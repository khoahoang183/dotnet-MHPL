namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VESO")]
    public partial class VESO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VESO()
        {
            KETQUAs = new HashSet<KETQUA>();
            PHANPHOIs = new HashSet<PHANPHOI>();
        }
        
        [Key]
        [Display(Name = "Mã Vé")]
        public int MAVS { get; set; }
        
        [StringLength(100)]
        [Display(Name = "Tỉnh")]
        public string TINH { get; set; }
        [Display(Name = "Tình Trạng")]
        public int? TINHTRANG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KETQUA> KETQUAs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHANPHOI> PHANPHOIs { get; set; }
    }
}
