namespace CSDL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TBL_BoMon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_BoMon()
        {
            TBL_GiangVien = new HashSet<TBL_GiangVien>();
        }

        [Key]
        public long MaBoMon { get; set; }

        [StringLength(50)]
        public string TenBoMon { get; set; }

        [StringLength(50)]
        public string TruongBoMon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_GiangVien> TBL_GiangVien { get; set; }
    }
}
