namespace CSDL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TBL_Lop
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_Lop()
        {
            TBL_ChiTietThoiKhoaBieu = new HashSet<TBL_ChiTietThoiKhoaBieu>();
            TBL_ChuongTrinhKhung = new HashSet<TBL_ChuongTrinhKhung>();
            TBL_PhanCongDay = new HashSet<TBL_PhanCongDay>();
        }

        [Key]
        public long MaLop { get; set; }

        [StringLength(50)]
        public string TenLop { get; set; }

        public int? SoLuong { get; set; }

        public long MaKhoa { get; set; }

        public long MaChuyenNganh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_ChiTietThoiKhoaBieu> TBL_ChiTietThoiKhoaBieu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_ChuongTrinhKhung> TBL_ChuongTrinhKhung { get; set; }

        public virtual TBL_ChuyenNganh TBL_ChuyenNganh { get; set; }

        public virtual TBL_Khoa TBL_Khoa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_PhanCongDay> TBL_PhanCongDay { get; set; }
    }
}
