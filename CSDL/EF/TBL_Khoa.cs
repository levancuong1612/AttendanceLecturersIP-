namespace CSDL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TBL_Khoa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_Khoa()
        {
            TBL_GiangVien = new HashSet<TBL_GiangVien>();
            TBL_Lop = new HashSet<TBL_Lop>();
        }

        [Key]
        public long MaKhoa { get; set; }

        [StringLength(50)]
        public string TenKhoa { get; set; }

        public long MaPhong { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_GiangVien> TBL_GiangVien { get; set; }

        public virtual TBL_PhongHoc TBL_PhongHoc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_Lop> TBL_Lop { get; set; }
    }
}
