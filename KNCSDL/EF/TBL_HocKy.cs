namespace KNCSDL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TBL_HocKy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_HocKy()
        {
            TBL_DiemDanh = new HashSet<TBL_DiemDanh>();
            TBL_PhanCongDay = new HashSet<TBL_PhanCongDay>();
        }

        [Key]
        [StringLength(10)]
        public string MaHocKy { get; set; }

        [StringLength(50)]
        public string TenHocKy { get; set; }

        public int? Nam { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_DiemDanh> TBL_DiemDanh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_PhanCongDay> TBL_PhanCongDay { get; set; }
    }
}
