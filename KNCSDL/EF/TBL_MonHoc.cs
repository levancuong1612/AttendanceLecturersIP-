namespace KNCSDL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TBL_MonHoc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_MonHoc()
        {
            TBL_PhanCongDay = new HashSet<TBL_PhanCongDay>();
            TBL_ThoiKhoaBieuGiangVien = new HashSet<TBL_ThoiKhoaBieuGiangVien>();
        }

        [Key]
        [StringLength(10)]
        public string MaMonHoc { get; set; }

        [StringLength(50)]
        public string TenMonHoc { get; set; }

        public int? SoTinChi { get; set; }

        [Required]
        [StringLength(10)]
        public string MaChuyenNganh { get; set; }

        [StringLength(50)]
        public string Loai { get; set; }

        public virtual TBL_ChuyenNganh TBL_ChuyenNganh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_PhanCongDay> TBL_PhanCongDay { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_ThoiKhoaBieuGiangVien> TBL_ThoiKhoaBieuGiangVien { get; set; }
    }
}
